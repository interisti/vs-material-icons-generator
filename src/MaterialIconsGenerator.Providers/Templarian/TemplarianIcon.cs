using System.Collections.Generic;
using MaterialIconsGenerator.Core;

namespace MaterialIconsGenerator.Providers.Templarian
{
    public class TemplarianIcon : IIcon
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public IIconCategory Category { get; set; }

        public IEnumerable<string> Keywords { get; set; } = new List<string>();

        public string Author { get; set; }

        public string Badge { get; set; }

        public string PreviewUrl
        {
            get { return $"https://materialdesignicons.com/api/download/{this.Id}/000000/1/FFFFFF/0/36"; }
        }

        public IIconProvider Provider { get; set; }
    }
}
