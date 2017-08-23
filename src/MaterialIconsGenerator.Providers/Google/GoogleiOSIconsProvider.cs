using System.Collections.Generic;

namespace MaterialIconsGenerator.Providers.Google
{
    public class GoogleiOSIconsProvider : GoogleIconsProvider
    {
        public override IEnumerable<string> GetSizes()
        {
            return new List<string>()
            {
                "",
                "18pt",
                "36pt",
                "48pt"
            };
        }

        public override IEnumerable<string> GetDensities()
        {
            return new List<string>()
            {
                "",
                "2X",
                "3X"
            };
        }
    }
}
