using System.Collections.Generic;
using MaterialIconsGenerator.Core;

namespace MaterialIconsGenerator.Providers.Google
{
    public class GoogleiOSIconsProvider : GoogleIconsProvider
    {
        public override IEnumerable<string> GetSizes()
        {
            return new List<string>()
            {
                "18pt",
                "24pt",
                "36pt",
                "48pt"
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

        public override IProjectIcon CreateProjectIcon(IIcon icon, IIconColor color, string size, string density)
        {
            return new GoogleiOSProjectIcon(icon, color, size, density);
        }
    }
}
