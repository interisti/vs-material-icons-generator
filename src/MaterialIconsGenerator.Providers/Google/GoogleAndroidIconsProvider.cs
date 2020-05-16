using System.Collections.Generic;
using MaterialIconsGenerator.Core;

namespace MaterialIconsGenerator.Providers.Google
{
    public class GoogleAndroidIconsProvider : GoogleIconsProvider
    {
        private IEnumerable<ISize> _sizes = new List<ISize>()
        {
            new GoogleSize{ Id = "18dp", Name ="18dp" },
            new GoogleSize{ Id = "24dp", Name ="24dp" },
            new GoogleSize{ Id = "36dp", Name ="36dp" },
            new GoogleSize{ Id = "48dp", Name ="48dp" }
        };

        private IEnumerable<string> _densities = new List<string>()
        {
            "mdpi",
            "hdpi",
            "xhdpi",
            "xxhdpi",
            "xxxhdpi",
            "drawable",
            "drawable-v21"
        };

        public override IEnumerable<ISize> GetSizes() =>
            this._sizes;

        public override IEnumerable<string> GetDensities() =>
            this._densities;

        public override IProjectIcon CreateProjectIcon(IIcon icon, IIconTheme theme, IIconColor color, ISize size, string density) =>
            new GoogleAndroidProjectIcon(icon, theme, color, size, density);
    }
}
