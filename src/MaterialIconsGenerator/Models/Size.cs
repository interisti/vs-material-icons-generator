using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialIconsGenerator.Models
{
    public class Size
    {
        public string Name { get; set; }

        public string Value { get; set; }


        public static Size Dp18 = new Size() { Name = "18dp", Value = "18dp" };
        public static Size Dp24 = new Size() { Name = "24dp", Value = "24dp" };
        public static Size Dp36 = new Size() { Name = "36dp", Value = "36dp" };
        public static Size Dp48 = new Size() { Name = "48dp", Value = "48dp" };

        public static List<Size> GetDefault()
        {
            return new List<Size>()
            {
                Dp18, Dp24, Dp36, Dp48
            };
        }
    }
}
