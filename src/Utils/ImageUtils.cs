using System.IO;
using System.Windows.Media.Imaging;

namespace VSMaterialIcons.Utils
{
    public class ImageUtils
    {
        public static BitmapImage BitmapFromByteArray(byte[] data)
        {
            var image = new BitmapImage();
            using (var mem = new MemoryStream(data))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }
    }
}
