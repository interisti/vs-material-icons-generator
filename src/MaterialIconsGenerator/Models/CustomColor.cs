using System.Drawing;
using System.Globalization;
using MaterialIconsGenerator.Core;

namespace MaterialIconsGenerator.Models
{
    class CustomColor : IIconColor
    {
        public string Name => "custom";

        public Color Color { get; set; }

        public static CustomColor FromHex(string hex)
        {
            try
            {
                if (string.IsNullOrEmpty(hex)) return null;

                var code = hex.TrimStart('#');
                if (false == "68".Contains(code.Length.ToString())) return null;

                Color color;
                if (code.Length == 6)
                {
                    // from System.Drawing or System.Windows.Media
                    color = Color.FromArgb(255, // hardcoded opaque
                                int.Parse(code.Substring(0, 2), NumberStyles.HexNumber),
                                int.Parse(code.Substring(2, 2), NumberStyles.HexNumber),
                                int.Parse(code.Substring(4, 2), NumberStyles.HexNumber));
                }
                else
                {
                    // assuming length of 8
                    color = Color.FromArgb(
                                int.Parse(code.Substring(0, 2), NumberStyles.HexNumber),
                                int.Parse(code.Substring(2, 2), NumberStyles.HexNumber),
                                int.Parse(code.Substring(4, 2), NumberStyles.HexNumber),
                                int.Parse(code.Substring(6, 2), NumberStyles.HexNumber));
                }

                return new CustomColor() { Color = color };
            }
            catch
            {
                return null;
            }
        }
    }
}
