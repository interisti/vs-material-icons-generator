using System.Drawing;
using System.IO;

namespace MaterialIconsGenerator.Core.Utils
{
    public class ColorUtils
    {
        public static byte[] Tint(byte[] data, Color color)
        {
            var ignoredColor = OSUtils.ISRunningOnWindows() ? Color.FromArgb(0, 0, 0, 0) : Color.FromArgb(255, 0, 0, 0);
            using (var ms = new MemoryStream(data))
            {
                var bitmap = new Bitmap(ms);
                for (var y = 0; y < bitmap.Height; y++)
                {
                    for (var x = 0; x < bitmap.Width; x++)
                    {
                        var originalPixel = bitmap.GetPixel(x, y);
                        if (originalPixel != ignoredColor)
                        {
                            bitmap.SetPixel(x, y, Color.FromArgb(originalPixel.A, color));
                        }
                    }
                }
                var converter = new ImageConverter();
                return (byte[])converter.ConvertTo(bitmap, typeof(byte[]));
            }
        }
    }
}
