using System.Collections.Generic;
using MaterialIconsGenerator.Core;

namespace MaterialIconsGenerator.Providers.Google
{
    public class GoogleIcon : IIcon
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public IIconCategory Category { get; set; }

        public IEnumerable<string> Keywords { get; set; } = new List<string>();

        public string PreviewUrl =>
            $"https://www.vs-material-icons-generator.com/icon-providers/google/assets/{this.Category.Id}/drawable-hdpi/material-icons/{this.Id}_24dp.png";

        public IIconProvider Provider { get; set; }
    }
}
