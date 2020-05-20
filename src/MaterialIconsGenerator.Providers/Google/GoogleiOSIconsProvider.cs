using System.Collections.Generic;
using MaterialIconsGenerator.Core;

namespace MaterialIconsGenerator.Providers.Google
{
    public class GoogleiOSIconsProvider : GoogleIconsProvider
    {
        private List<ISize> _sizes = new List<ISize>()
        {
            new GoogleSize{ Id = "18pt", Name ="18pt" },
            new GoogleSize{ Id = "24pt", Name ="24pt" },
            new GoogleSize{ Id = "36pt", Name ="36pt" },
            new GoogleSize{ Id = "48pt", Name ="48pt" }
        };

        private IEnumerable<string> _densities = new List<string>()
        {
            "1x",
            "2x",
            "3x"
        };
        
        public override IEnumerable<ISize> GetSizes() =>
            this._sizes;

        public override IEnumerable<string> GetDensities() =>
            this._densities;

        public override IProjectIcon CreateProjectIcon(IIcon icon, IIconTheme theme, IIconColor color, ISize size, string density) =>
            new GoogleiOSProjectIcon(icon, theme, color, size, density);
    }
}
