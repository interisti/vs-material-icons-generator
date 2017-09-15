using System.Collections.Generic;
using MaterialIconsGenerator.Core;

namespace MaterialIconsGenerator.Providers.Google
{
    public class GoogleUWPIconsProvider : GoogleIconsProvider
    {
        public override IEnumerable<string> GetSizes()
        {
            return new List<string>()
            {
                "18dp",
                "24dp",
                "36dp",
                "48dp"
            };
        }

        public override IEnumerable<string> GetDensities()
        {
            return new List<string>();
        }

        public override IProjectIcon CreateProjectIcon(IIcon icon, IIconColor color, string size, string density)
        {
            return new GoogleUWPProjectIcon(icon, color, size, density);
        }
    }
}
