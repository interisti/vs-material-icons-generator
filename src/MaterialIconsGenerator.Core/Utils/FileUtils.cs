using System.IO;

namespace MaterialIconsGenerator.Core.Utils
{
    public class FileUtils
    {
        public static void WriteAllBytes(byte[] data, string filepath)
        {
            if (!Directory.Exists(Path.GetDirectoryName(filepath)))
                Directory.CreateDirectory(Path.GetDirectoryName(filepath));
            File.WriteAllBytes(filepath, data);
        }
    }
}
