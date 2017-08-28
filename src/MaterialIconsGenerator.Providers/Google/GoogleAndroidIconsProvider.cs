using System.Collections.Generic;
using MaterialIconsGenerator.Core;

namespace MaterialIconsGenerator.Providers.Google
{
    public class GoogleAndroidIconsProvider : GoogleIconsProvider
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
            return new List<string>()
            {
                "mdpi",
                "hdpi",
                "xhdpi",
                "xxhdpi",
                "xxxhdpi",
                "drawable",
                "drawable-v21"
            };
        }

        public override IProjectIcon CreateProjectIcon(IIcon icon, IIconColor color, string size, string density)
        {
            return new GoogleAndroidProjectIcon(icon, color, size, density);
        }
    }
}
