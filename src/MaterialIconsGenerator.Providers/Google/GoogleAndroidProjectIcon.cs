using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using MaterialIconsGenerator.Core;

namespace MaterialIconsGenerator.Providers.Google
{
    public class GoogleAndroidProjectIcon : GoogleProjectIcon
    {
        public GoogleAndroidProjectIcon(IIcon icon, IIconTheme theme, IIconColor color, ISize size, string density)
            : base(icon, theme, color, size, density)
        { }

        public override bool IsVector => Density == "drawable" ||
            Density == "drawable-v21" ||
            Density == "drawable-v24" ||
            Density == "mipmap-anydpi-v26" ||
            Density == "drawable-anydpi";

        public override async Task<byte[]> Get()
        {
            return this.IsVector
                ? await this.GetVector()
                : await base.Get();
        }

        protected override string GenerateUrl()
        {
            var theme = this.Theme.Id;
            var category = this.Icon.Category.Id;
            var density = (this.IsVector ? "drawable" : this.Density).Replace("mipmap", "drawable");
            var id = this.Icon.Id;
            var size = this.IsVector ? "24dp" : this.Size.Id;
            var extension = this.IsVector ? "xml" : "png";

            return $"icon-providers/google/assets/{category}/{density}/{theme}/{id}_{size}.{extension}";
        }

        private async Task<byte[]> GetVector()
        {
            var response = await this.Download(this.GenerateUrl());

            // update xml
            var xml = new XmlDocument();
            xml.LoadXml(Encoding.ASCII.GetString(response));
            xml.FirstChild.Attributes["android:width"].Value = this.Size.Name;
            xml.FirstChild.Attributes["android:height"].Value = this.Size.Name;
            xml.FirstChild.FirstChild.Attributes["android:fillColor"].Value = this.ToHexColor(this.Color.Color);

            return Encoding.ASCII.GetBytes(xml.OuterXml);
        }

        private string ToHexColor(Color color)
        {
            return string.Format("#{0}{1}{2}{3}",
                color.A != 0 ? color.A.ToString("X2") : "",
                color.R.ToString("X2"),
                color.G.ToString("X2"),
                color.B.ToString("X2"));
        }
    }
}
