using System.Collections.Generic;
using MaterialIconsGenerator.Core;

namespace MaterialIconsGenerator.Providers.Templarian
{
    public class TemplarianAndroidIconsProvider : TemplarianIconsProvider
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
            return new TemplarianAndroidProjectIcon(icon, color, size, density);
        }
    }
}
