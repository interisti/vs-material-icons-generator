using System.Collections.Generic;
using MaterialIconsGenerator.Core;

namespace MaterialIconsGenerator.Providers.Google
{
    public class GoogleUWPIconsProvider : GoogleIconsProvider
    {
        private IEnumerable<ISize> _sizes = new List<ISize>()
        {
            new GoogleSize{ Id = "18dp", Name ="18dp" },
            new GoogleSize{ Id = "24dp", Name ="24dp" },
            new GoogleSize{ Id = "36dp", Name ="36dp" },
            new GoogleSize{ Id = "48dp", Name ="48dp" }
        };

        public override IEnumerable<ISize> GetSizes() =>
            this._sizes;

        public override IEnumerable<string> GetDensities() =>
            new List<string>();

        public override IProjectIcon CreateProjectIcon(IIcon icon, IIconTheme theme, IIconColor color, ISize size, string density) =>
            new GoogleUWPProjectIcon(icon, theme, color, size, density);
    }
}
