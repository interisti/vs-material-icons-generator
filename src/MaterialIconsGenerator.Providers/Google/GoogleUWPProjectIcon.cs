using MaterialIconsGenerator.Core;

namespace MaterialIconsGenerator.Providers.Google
{
    public class GoogleUWPProjectIcon : GoogleProjectIcon
    {
        public GoogleUWPProjectIcon(IIcon icon, IIconColor color, ISize size, string density)
            : base(icon, color, size, density)
        { }

        public override string FullName
        {
            get { return $"{this.Icon.Id}_{this.Color.Name}_{this.Size.Name}"; }
        }

        protected override string GenerateUrl()
        {
            var category = this.Icon.Category.Id;
            var id = this.Icon.Id;
            var color = this.Color.Color == System.Drawing.Color.White ? "white" : "black";
            var size = this.Size.Name;
            var extension = "png";

            return $"google/material-design-icons/master/{category}/2x_web/{id}_{color}_{size}.{extension}";
        }
    }
}
