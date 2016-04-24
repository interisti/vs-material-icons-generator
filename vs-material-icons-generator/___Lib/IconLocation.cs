using System.IO;

namespace VSMaterialIcons
{
    public static class IconLocation
    {
        public const string RESOURCES_FOLDER = "Resources";
        public const string ICON_EXTENSION = ".png";
        public const string DRAWABLE_MDPI_FOLDER = "drawable-mdpi";
        public const string DRAWABLE_HDPI_FOLDER = "drawable-hdpi";
        public const string DRAWABLE_XHDPI_FOLDER = "drawable-xhdpi";
        public const string DRAWABLE_XXHDPI_FOLDER = "drawable-xxhdpi";
        public const string DRAWABLE_XXXHDPI_FOLDER = "drawable-xxxhdpi";

        public static string NormalizeFileName(string icon, string color, string size)
        {
            return string.Format("{0}_{1}_{2}",
                icon.Split('/')[1],
                color,
                size
            );
        }

        public static void SaveIcon(byte[] data, string filepath)
        {
            if (!Directory.Exists(Path.GetDirectoryName(filepath)))
                Directory.CreateDirectory(Path.GetDirectoryName(filepath));
            File.WriteAllBytes(filepath, data);
        }
    }
}

