using MaterialIconsGenerator.Core;

namespace MaterialIconsGenerator.Providers.Google
{
    public class GoogleiOSProjectIcon : GoogleProjectIcon
    {
        public GoogleiOSProjectIcon(IIcon icon, IIconColor color, ISize size, string density)
            : base(icon, color, size, density)
        { }

        public override string FullName =>
            $"{this.Icon.Id}_{this.Color.Name}_{this.Size.Name}";

        protected override string GenerateUrl()
        {
            var category = this.Icon.Category.Id;
            var density = this.Density == "1x" ? "" : $"_{this.Density}";
            var id = this.Icon.Id;
            var color = this.Color.Color == System.Drawing.Color.White ? "_white" : "";
            var size = this.Size.Name == "24pt" ? "" : $"_{this.Size.Name}";
            var extension = "png";

            return $"google/material-design-icons/master/{category}/ios/{id}{color}{size}.imageset/{id}{color}{size}{density}.{extension}";
        }
    }
}
