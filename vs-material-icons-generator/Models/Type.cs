
namespace VSMaterialIcons.Models
{
    public class Type
    {
        public const string RESOURCES_FOLDER = "Resources";

        public string Name { get; set; }

        public string Folder { get; set; }

        public string Extension { get; set; }
        

        public static Type GetMDPI()
        {
            return new Type()
            {
                Name = "mdpi",
                Folder = "drawable-mdpi",
                Extension = ".png"
            };
        }

        public static Type GetHDPI()
        {
            return new Type()
            {
                Name = "hdpi",
                Folder = "drawable-hdpi",
                Extension = ".png"
            };
        }

        public static Type GetXHDPI()
        {
            return new Type()
            {
                Name = "xhdpi",
                Folder = "drawable-xhdpi",
                Extension = ".png"
            };
        }

        public static Type GetXXHDPI()
        {
            return new Type()
            {
                Name = "xxhdpi",
                Folder = "drawable-xxhdpi",
                Extension = ".png"
            };
        }

        public static Type GetXXXHDPI()
        {
            return new Type()
            {
                Name = "xxxhdpi",
                Folder = "drawable-xxxhdpi",
                Extension = ".png"
            };
        }
    }
}
