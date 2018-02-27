using System.Collections.Generic;
using MaterialIconsGenerator.Core;

namespace MaterialIconsGenerator.Providers.Google
{
    public class GoogleAndroidIconsProvider : GoogleIconsProvider
    {
        private IEnumerable<ISize> _sizes = new List<ISize>()
        {
            new GoogleSize{ Id = "18", Name ="18dp" },
            new GoogleSize{ Id = "24", Name ="24dp" },
            new GoogleSize{ Id = "36", Name ="36dp" },
            new GoogleSize{ Id = "48", Name ="48dp" }
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

        public override IProjectIcon CreateProjectIcon(IIcon icon, IIconColor color, ISize size, string density) =>
            new GoogleAndroidProjectIcon(icon, color, size, density);
    }
}
