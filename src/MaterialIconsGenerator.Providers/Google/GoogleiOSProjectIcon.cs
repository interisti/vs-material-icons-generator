using MaterialIconsGenerator.Core;

namespace MaterialIconsGenerator.Providers.Google
{
    public class GoogleiOSProjectIcon : GoogleProjectIcon
    {
        public GoogleiOSProjectIcon(IIcon icon, IIconTheme theme, IIconColor color, ISize size, string density)
            : base(icon, theme, color, size, density)
        { }

        protected override string GenerateUrl()
        {
            var theme = this.Theme.Id;
            var category = this.Icon.Category.Id;
            
            var id = this.Icon.Id;
            var size = this.Size.Id;
            var density = this.Density;
            var extension = "png";


            return $"icon-providers/google/assets/{category}/ios/{theme}/{id}_{size}_{density}.{extension}";
        }
    }
}
