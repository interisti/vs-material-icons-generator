using MaterialIconsGenerator.Core;

namespace MaterialIconsGenerator.Providers.Google
{
    public class GoogleiOSProjectIcon : GoogleProjectIcon
    {
        public GoogleiOSProjectIcon(IIcon icon, IIconColor color, string size, string density)
            : base(icon, color, size, density)
        { }

        public override string FullName
        {
            get { return $"{this.Icon.Id}_{this.Color.Name}_{this.Size}"; }
        }

        protected override string GenerateUrl()
        {
            var category = this.Icon.Category.Id;
            var density = this.Density == "1x" ? "" : $"_{this.Density}";
            var id = this.Icon.Id;
            var size = this.Size == "24pt" ? "" : $"_{this.Size}";
            var extension = "png";

            return $"google/material-design-icons/master/{category}/ios/{id}{size}.imageset/{id}{size}{density}.{extension}";
        }
    }
}
