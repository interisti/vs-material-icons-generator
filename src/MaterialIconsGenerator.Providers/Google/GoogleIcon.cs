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

        public string PreviewUrl => $"https://raw.githubusercontent.com/google/material-design-icons/master/{this.Category.Id}/drawable-hdpi/{this.Id}_black_24dp.png";

        public IIconProvider Provider { get; set; }
    }
}
