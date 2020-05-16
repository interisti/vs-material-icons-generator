using MaterialIconsGenerator.Core;

namespace MaterialIconsGenerator.Providers.Google
{
    public class GoogleUWPProjectIcon : GoogleProjectIcon
    {
        public GoogleUWPProjectIcon(IIcon icon, IIconTheme theme, IIconColor color, ISize size, string density)
            : base(icon, theme, color, size, density)
        { }

        protected override string GenerateUrl()
        {
            var theme = this.Theme.Id;
            var category = this.Icon.Category.Id;
            var id = this.Icon.Id;
            var size = this.Size.Id;
            var extension = "png";

            return $"icon-providers/google/assets/{category}/2x_web/{theme}/{id}_{size}.{extension}";
        }
    }
}
