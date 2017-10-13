using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using MaterialIconsGenerator.Core;

namespace MaterialIconsGenerator.Providers.Templarian
{
    public class TemplarianAndroidProjectIcon : TemplarianProjectIcon
    {
        public TemplarianAndroidProjectIcon(IIcon icon, IIconColor color, string size, string density)
            : base(icon, color, size, density)
        { }

        public override string FullName
        {
            get { return $"{this.Icon.Name}_{this.Color.Name}_{this.Size}"; }
        }

        public override async Task<byte[]> Get()
        {
            return (this.Density == "drawable" || this.Density == "drawable-v21")
                ? await this.GetVector()
                : await base.Get();
        }

        protected override string GenerateUrl()
        {
            var category = this.Icon.Category.Id;
            var density = (this.Density == "drawable" || this.Density == "drawable-v21")
                ? "anydpi-v21"
                : this.Density;
            var id = this.Icon.Id;
            var color = (this.Density == "drawable" || this.Density == "drawable-v21")
                ? "black"
                : this.Color.Color == System.Drawing.Color.White ? "white" : "black";
            var size = (this.Density == "drawable" || this.Density == "drawable-v21")
                ? "24dp"
                : this.Size;
            var extension = (this.Density == "drawable" || this.Density == "drawable-v21")
                ? "xml"
                : "png";

            return $"google/material-design-icons/master/{category}/drawable-{density}/{id}_{color}_{size}.{extension}";
        }

        private async Task<byte[]> GetVector()
        {
            var response = await this.Download(this.GenerateUrl());

            // update xml
            var xml = new XmlDocument();
            xml.LoadXml(Encoding.ASCII.GetString(response));
            xml.FirstChild.Attributes["android:width"].Value = this.Size;
            xml.FirstChild.Attributes["android:height"].Value = this.Size;
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
