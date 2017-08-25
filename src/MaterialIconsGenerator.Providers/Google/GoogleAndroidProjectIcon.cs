using MaterialIconsGenerator.Core;

namespace MaterialIconsGenerator.Providers.Google
{
    public class GoogleAndroidProjectIcon : GoogleProjectIcon
    {
        public GoogleAndroidProjectIcon(IIcon icon, IIconColor color, string size, string density)
            : base(icon, color, size, density)
        { }

        public override string FullName => $"{this.Icon.Name}_{this.Color.Name}_{this.Density}";

        protected override  string GenerateUrl()
        {
            var downloadColor = this.Color.Color == System.Drawing.Color.White ? "white" : "black";

            return $"https://raw.githubusercontent.com/google/material-design-icons/master/{this.Icon.Category.Id}/drawable-{this.Density}/{this.Icon.Id}_{downloadColor}_{this.Size}.png";
        }
    }
}
