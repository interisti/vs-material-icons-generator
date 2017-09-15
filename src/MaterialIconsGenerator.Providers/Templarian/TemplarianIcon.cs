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

        public string PreviewUrl
        {
            get { return $"https://raw.githubusercontent.com/Templarian/MaterialDesign-SVG/master/svg/{this.Id}.svg"; }
        }

        public IIconProvider Provider { get; set; }
    }
}
