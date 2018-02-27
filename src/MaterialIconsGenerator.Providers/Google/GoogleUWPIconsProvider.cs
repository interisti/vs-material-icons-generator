using System.Collections.Generic;
using MaterialIconsGenerator.Core;

namespace MaterialIconsGenerator.Providers.Google
{
    public class GoogleUWPIconsProvider : GoogleIconsProvider
    {
        private IEnumerable<ISize> _sizes = new List<ISize>()
        {
            new GoogleSize{ Id = "18", Name ="18dp" },
            new GoogleSize{ Id = "24", Name ="24dp" },
            new GoogleSize{ Id = "36", Name ="36dp" },
            new GoogleSize{ Id = "48", Name ="48dp" }
        };

        public override IEnumerable<ISize> GetSizes() =>
            this._sizes;

        public override IEnumerable<string> GetDensities() =>
            new List<string>();

        public override IProjectIcon CreateProjectIcon(IIcon icon, IIconColor color, ISize size, string density) =>
            new GoogleUWPProjectIcon(icon, color, size, density);
    }
}
