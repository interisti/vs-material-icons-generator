using System.Collections.Generic;
using MaterialIconsGenerator.Core;

namespace MaterialIconsGenerator.Providers.Google
{
    public class GoogleiOSIconsProvider : GoogleIconsProvider
    {
        public override IEnumerable<ISize> GetSizes()
        {
            return new List<ISize>()
            {
                new GoogleSize{ Id = "18", Name ="18pt" },
                new GoogleSize{ Id = "24", Name ="24pt" },
                new GoogleSize{ Id = "36", Name ="36pt" },
                new GoogleSize{ Id = "48", Name ="48pt" }
            };
        }

        public override IEnumerable<string> GetDensities()
        {
            return new List<string>()
            {
                "1x",
                "2x",
                "3x"
            };
        }

        public override IProjectIcon CreateProjectIcon(IIcon icon, IIconColor color, ISize size, string density)
        {
            return new GoogleiOSProjectIcon(icon, color, size, density);
        }
    }
}
