using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;

namespace VSMaterialIcons
{
    public static class IconColors
    {
        private static bool ISRunningOnWindows()
        {
            int p = (int)Environment.OSVersion.Platform;
            if ((p == 4) || (p == 6) || (p == 128))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static byte[] ReplaceColor(byte[] data, Color replacementColor)
        {
            var ignoredColor = ISRunningOnWindows() ? Color.FromArgb(0, 0, 0, 0) : Color.FromArgb(255, 0, 0, 0);
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
                            bitmap.SetPixel(x, y, Color.FromArgb(originalPixel.A, replacementColor));
                        }
                    }
                }
                var converter = new ImageConverter();
                return (byte[])converter.ConvertTo(bitmap, typeof(byte[]));
            }
        }

        public static string NormalizeColor(string color)
        {
            return color.ToLower().Replace(" ", "");
        }

        public static string FixColor(string color)
        {
            return IsKnownColor(color) ? color : "black";
        }

        public static bool IsKnownColor(string color)
        {
            color = NormalizeColor(color);
            return (color == "black" || color == "white" || color == "grey600");
        }

        public static Color GetColor(string name)
        {
            var colorName = NormalizeColor(name);
            return Colors.ContainsKey(colorName) ? Colors[colorName] : Color.Black;
        }

        public static List<string> KnownColors = new List<string>() {
            "white",
            "black",
            "grey600"
        };

        public static Dictionary<string, Color> Colors = new Dictionary<string, Color>() {
            { "blue_dark", Color.FromArgb (0, 153, 204) },
            { "blue_light", Color.FromArgb (51, 181, 229) },
            { "green_dark", Color.FromArgb (102, 153, 0) },
            { "green_light", Color.FromArgb (153, 204, 0) },
            { "purple_dark", Color.FromArgb (153, 51, 204) },
            { "purple_light", Color.FromArgb (170, 102, 204) },
            { "red_dark", Color.FromArgb (204, 0, 0) },
            { "red_light", Color.FromArgb (255, 68, 68) },
            { "yellow_dark", Color.FromArgb (255, 136, 0) },
            { "yellow_light", Color.FromArgb (255, 187, 51) },

            { "amber_50", ColorTranslator.FromHtml ("#fff8e1") },
            { "amber_100", ColorTranslator.FromHtml ("#ffecb3") },
            { "amber_200", ColorTranslator.FromHtml ("#ffe082") },
            { "amber_300", ColorTranslator.FromHtml ("#ffd54f") },
            { "amber_400", ColorTranslator.FromHtml ("#ffca28") },
            { "amber_500", ColorTranslator.FromHtml ("#ffc107") },
            { "amber_600", ColorTranslator.FromHtml ("#ffb300") },
            { "amber_700", ColorTranslator.FromHtml ("#ffa000") },
            { "amber_800", ColorTranslator.FromHtml ("#ff8f00") },
            { "amber_900", ColorTranslator.FromHtml ("#ff6f00") },
            { "amber_A100", ColorTranslator.FromHtml ("#ffe57f") },
            { "amber_A200", ColorTranslator.FromHtml ("#ffd740") },
            { "amber_A400", ColorTranslator.FromHtml ("#ffc400") },
            { "amber_A700", ColorTranslator.FromHtml ("#ffab00") },

            { "blue_50", ColorTranslator.FromHtml ("#e7e9fd") },
            { "blue_100", ColorTranslator.FromHtml ("#d0d9ff") },
            { "blue_200", ColorTranslator.FromHtml ("#afbfff") },
            { "blue_300", ColorTranslator.FromHtml ("#91a7ff") },
            { "blue_400", ColorTranslator.FromHtml ("#738ffe") },
            { "blue_500", ColorTranslator.FromHtml ("#5677fc") },
            { "blue_600", ColorTranslator.FromHtml ("#4e6cef") },
            { "blue_700", ColorTranslator.FromHtml ("#455ede") },
            { "blue_800", ColorTranslator.FromHtml ("#3b50ce") },
            { "blue_900", ColorTranslator.FromHtml ("#2a36b1") },
            { "blue_A100", ColorTranslator.FromHtml ("#a6baff") },
            { "blue_A200", ColorTranslator.FromHtml ("#6889ff") },
            { "blue_A400", ColorTranslator.FromHtml ("#4d73ff") },
            { "blue_A700", ColorTranslator.FromHtml ("#4d69ff") },

            { "blue_grey_50", ColorTranslator.FromHtml ("#eceff1") },
            { "blue_grey_100", ColorTranslator.FromHtml ("#cfd8dc") },
            { "blue_grey_200", ColorTranslator.FromHtml ("#b0bec5") },
            { "blue_grey_300", ColorTranslator.FromHtml ("#90a4ae") },
            { "blue_grey_400", ColorTranslator.FromHtml ("#78909c") },
            { "blue_grey_500", ColorTranslator.FromHtml ("#607d8b") },
            { "blue_grey_600", ColorTranslator.FromHtml ("#546e7a") },
            { "blue_grey_700", ColorTranslator.FromHtml ("#455a64") },
            { "blue_grey_800", ColorTranslator.FromHtml ("#37474f") },
            { "blue_grey_900", ColorTranslator.FromHtml ("#263238") },

            { "brown_50", ColorTranslator.FromHtml ("#efebe9") },
            { "brown_100", ColorTranslator.FromHtml ("#d7ccc8") },
            { "brown_200", ColorTranslator.FromHtml ("#bcaaa4") },
            { "brown_300", ColorTranslator.FromHtml ("#a1887f") },
            { "brown_400", ColorTranslator.FromHtml ("#8d6e63") },
            { "brown_500", ColorTranslator.FromHtml ("#795548") },
            { "brown_600", ColorTranslator.FromHtml ("#6d4c41") },
            { "brown_700", ColorTranslator.FromHtml ("#5d4037") },
            { "brown_800", ColorTranslator.FromHtml ("#4e342e") },
            { "brown_900", ColorTranslator.FromHtml ("#3e2723") },

            { "cyan_50", ColorTranslator.FromHtml ("#e0f7fa") },
            { "cyan_100", ColorTranslator.FromHtml ("#b2ebf2") },
            { "cyan_200", ColorTranslator.FromHtml ("#80deea") },
            { "cyan_300", ColorTranslator.FromHtml ("#4dd0e1") },
            { "cyan_400", ColorTranslator.FromHtml ("#26c6da") },
            { "cyan_500", ColorTranslator.FromHtml ("#00bcd4") },
            { "cyan_600", ColorTranslator.FromHtml ("#00acc1") },
            { "cyan_700", ColorTranslator.FromHtml ("#0097a7") },
            { "cyan_800", ColorTranslator.FromHtml ("#00838f") },
            { "cyan_900", ColorTranslator.FromHtml ("#006064") },
            { "cyan_A100", ColorTranslator.FromHtml ("#84ffff") },
            { "cyan_A200", ColorTranslator.FromHtml ("#18ffff") },
            { "cyan_A400", ColorTranslator.FromHtml ("#00e5ff") },
            { "cyan_A700", ColorTranslator.FromHtml ("#00b8d4") },

            { "dark_purple_50", ColorTranslator.FromHtml ("#ede7f6") },
            { "dark_purple_100", ColorTranslator.FromHtml ("#d1c4e9") },
            { "dark_purple_200", ColorTranslator.FromHtml ("#b39ddb") },
            { "dark_purple_300", ColorTranslator.FromHtml ("#9575cd") },
            { "dark_purple_400", ColorTranslator.FromHtml ("#7e57c2") },
            { "dark_purple_500", ColorTranslator.FromHtml ("#673ab7") },
            { "dark_purple_600", ColorTranslator.FromHtml ("#5e35b1") },
            { "dark_purple_700", ColorTranslator.FromHtml ("#512da8") },
            { "dark_purple_800", ColorTranslator.FromHtml ("#4527a0") },
            { "dark_purple_900", ColorTranslator.FromHtml ("#311b92") },
            { "dark_purple_A100", ColorTranslator.FromHtml ("#b388ff") },
            { "dark_purple_A200", ColorTranslator.FromHtml ("#7c4dff") },
            { "dark_purple_A400", ColorTranslator.FromHtml ("#651fff") },
            { "dark_purple_A700", ColorTranslator.FromHtml ("#6200ea") },

            { "deep_orange_50", ColorTranslator.FromHtml ("#fbe9e7") },
            { "deep_orange_100", ColorTranslator.FromHtml ("#ffccbc") },
            { "deep_orange_200", ColorTranslator.FromHtml ("#ffab91") },
            { "deep_orange_300", ColorTranslator.FromHtml ("#ff8a65") },
            { "deep_orange_400", ColorTranslator.FromHtml ("#ff7043") },
            { "deep_orange_500", ColorTranslator.FromHtml ("#ff5722") },
            { "deep_orange_600", ColorTranslator.FromHtml ("#f4511e") },
            { "deep_orange_700", ColorTranslator.FromHtml ("#e64a19") },
            { "deep_orange_800", ColorTranslator.FromHtml ("#d84315") },
            { "deep_orange_900", ColorTranslator.FromHtml ("#bf360c") },
            { "deep_orange_A100", ColorTranslator.FromHtml ("#ff9e80") },
            { "deep_orange_A200", ColorTranslator.FromHtml ("#ff6e40") },
            { "deep_orange_A400", ColorTranslator.FromHtml ("#ff3d00") },
            { "deep_orange_A700", ColorTranslator.FromHtml ("#dd2c00") },

            { "green_50", ColorTranslator.FromHtml ("#d0f8ce") },
            { "green_100", ColorTranslator.FromHtml ("#a3e9a4") },
            { "green_200", ColorTranslator.FromHtml ("#72d572") },
            { "green_300", ColorTranslator.FromHtml ("#42bd41") },
            { "green_400", ColorTranslator.FromHtml ("#2baf2b") },
            { "green_500", ColorTranslator.FromHtml ("#259b24") },
            { "green_600", ColorTranslator.FromHtml ("#0a8f08") },
            { "green_700", ColorTranslator.FromHtml ("#0a7e07") },
            { "green_800", ColorTranslator.FromHtml ("#056f00") },
            { "green_900", ColorTranslator.FromHtml ("#0d5302") },
            { "green_A100", ColorTranslator.FromHtml ("#a2f78d") },
            { "green_A200", ColorTranslator.FromHtml ("#5af158") },
            { "green_A400", ColorTranslator.FromHtml ("#14e715") },
            { "green_A700", ColorTranslator.FromHtml ("#12c700") },

            { "grey_50", ColorTranslator.FromHtml ("#fafafa") },
            { "grey_100", ColorTranslator.FromHtml ("#f5f5f5") },
            { "grey_200", ColorTranslator.FromHtml ("#eeeeee") },
            { "grey_300", ColorTranslator.FromHtml ("#e0e0e0") },
            { "grey_400", ColorTranslator.FromHtml ("#bdbdbd") },
            { "grey_500", ColorTranslator.FromHtml ("#9e9e9e") },
            { "grey_600", ColorTranslator.FromHtml ("#757575") },
            { "grey_700", ColorTranslator.FromHtml ("#616161") },
            { "grey_800", ColorTranslator.FromHtml ("#424242") },
            { "grey_900", ColorTranslator.FromHtml ("#212121") },
            { "grey_black_1000", ColorTranslator.FromHtml ("#000000") },
            { "grey_white_1000", ColorTranslator.FromHtml ("#ffffff") },

            { "indigo_50", ColorTranslator.FromHtml ("#e8eaf6") },
            { "indigo_100", ColorTranslator.FromHtml ("#c5cae9") },
            { "indigo_200", ColorTranslator.FromHtml ("#9fa8da") },
            { "indigo_300", ColorTranslator.FromHtml ("#7986cb") },
            { "indigo_400", ColorTranslator.FromHtml ("#5c6bc0") },
            { "indigo_500", ColorTranslator.FromHtml ("#3f51b5") },
            { "indigo_600", ColorTranslator.FromHtml ("#3949ab") },
            { "indigo_700", ColorTranslator.FromHtml ("#303f9f") },
            { "indigo_800", ColorTranslator.FromHtml ("#283593") },
            { "indigo_900", ColorTranslator.FromHtml ("#1a237e") },
            { "indigo_A100", ColorTranslator.FromHtml ("#8c9eff") },
            { "indigo_A200", ColorTranslator.FromHtml ("#536dfe") },
            { "indigo_A400", ColorTranslator.FromHtml ("#3d5afe") },
            { "indigo_A700", ColorTranslator.FromHtml ("#304ffe") },

            { "light_blue_50", ColorTranslator.FromHtml ("#e1f5fe") },
            { "light_blue_100", ColorTranslator.FromHtml ("#b3e5fc") },
            { "light_blue_200", ColorTranslator.FromHtml ("#81d4fa") },
            { "light_blue_300", ColorTranslator.FromHtml ("#4fc3f7") },
            { "light_blue_400", ColorTranslator.FromHtml ("#29b6f6") },
            { "light_blue_500", ColorTranslator.FromHtml ("#03a9f4") },
            { "light_blue_600", ColorTranslator.FromHtml ("#039be5") },
            { "light_blue_700", ColorTranslator.FromHtml ("#0288d1") },
            { "light_blue_800", ColorTranslator.FromHtml ("#0277bd") },
            { "light_blue_900", ColorTranslator.FromHtml ("#01579b") },
            { "light_blue_A100", ColorTranslator.FromHtml ("#80d8ff") },
            { "light_blue_A200", ColorTranslator.FromHtml ("#40c4ff") },
            { "light_blue_A400", ColorTranslator.FromHtml ("#00b0ff") },
            { "light_blue_A700", ColorTranslator.FromHtml ("#0091ea") },

            { "light_green_50", ColorTranslator.FromHtml ("#f1f8e9") },
            { "light_green_100", ColorTranslator.FromHtml ("#dcedc8") },
            { "light_green_200", ColorTranslator.FromHtml ("#c5e1a5") },
            { "light_green_300", ColorTranslator.FromHtml ("#aed581") },
            { "light_green_400", ColorTranslator.FromHtml ("#9ccc65") },
            { "light_green_500", ColorTranslator.FromHtml ("#8bc34a") },
            { "light_green_600", ColorTranslator.FromHtml ("#7cb342") },
            { "light_green_700", ColorTranslator.FromHtml ("#689f38") },
            { "light_green_800", ColorTranslator.FromHtml ("#558b2f") },
            { "light_green_900", ColorTranslator.FromHtml ("#33691e") },
            { "light_green_A100", ColorTranslator.FromHtml ("#ccff90") },
            { "light_green_A200", ColorTranslator.FromHtml ("#b2ff59") },
            { "light_green_A400", ColorTranslator.FromHtml ("#76ff03") },
            { "light_green_A700", ColorTranslator.FromHtml ("#64dd17") },

            { "lime_50", ColorTranslator.FromHtml ("#f9fbe7") },
            { "lime_100", ColorTranslator.FromHtml ("#f0f4c3") },
            { "lime_200", ColorTranslator.FromHtml ("#e6ee9c") },
            { "lime_300", ColorTranslator.FromHtml ("#dce775") },
            { "lime_400", ColorTranslator.FromHtml ("#d4e157") },
            { "lime_500", ColorTranslator.FromHtml ("#cddc39") },
            { "lime_600", ColorTranslator.FromHtml ("#c0ca33") },
            { "lime_700", ColorTranslator.FromHtml ("#afb42b") },
            { "lime_800", ColorTranslator.FromHtml ("#9e9d24") },
            { "lime_900", ColorTranslator.FromHtml ("#827717") },
            { "lime_A100", ColorTranslator.FromHtml ("#f4ff81") },
            { "lime_A200", ColorTranslator.FromHtml ("#eeff41") },
            { "lime_A400", ColorTranslator.FromHtml ("#c6ff00") },
            { "lime_A700", ColorTranslator.FromHtml ("#aeea00") },

            { "orange_50", ColorTranslator.FromHtml ("#fff3e0") },
            { "orange_100", ColorTranslator.FromHtml ("#ffe0b2") },
            { "orange_200", ColorTranslator.FromHtml ("#ffcc80") },
            { "orange_300", ColorTranslator.FromHtml ("#ffb74d") },
            { "orange_400", ColorTranslator.FromHtml ("#ffa726") },
            { "orange_500", ColorTranslator.FromHtml ("#ff9800") },
            { "orange_600", ColorTranslator.FromHtml ("#fb8c00") },
            { "orange_700", ColorTranslator.FromHtml ("#f57c00") },
            { "orange_800", ColorTranslator.FromHtml ("#ef6c00") },
            { "orange_900", ColorTranslator.FromHtml ("#e65100") },
            { "orange_A100", ColorTranslator.FromHtml ("#ffd180") },
            { "orange_A200", ColorTranslator.FromHtml ("#ffab40") },
            { "orange_A400", ColorTranslator.FromHtml ("#ff9100") },
            { "orange_A700", ColorTranslator.FromHtml ("#ff6d00") },

            { "pink_50", ColorTranslator.FromHtml ("#fce4ec") },
            { "pink_100", ColorTranslator.FromHtml ("#f8bbd0") },
            { "pink_200", ColorTranslator.FromHtml ("#f48fb1") },
            { "pink_300", ColorTranslator.FromHtml ("#f06292") },
            { "pink_400", ColorTranslator.FromHtml ("#ec407a") },
            { "pink_500", ColorTranslator.FromHtml ("#e91e63") },
            { "pink_600", ColorTranslator.FromHtml ("#d81b60") },
            { "pink_700", ColorTranslator.FromHtml ("#c2185b") },
            { "pink_800", ColorTranslator.FromHtml ("#ad1457") },
            { "pink_900", ColorTranslator.FromHtml ("#880e4f") },
            { "pink_A100", ColorTranslator.FromHtml ("#ff80ab") },
            { "pink_A200", ColorTranslator.FromHtml ("#ff4081") },
            { "pink_A400", ColorTranslator.FromHtml ("#f50057") },
            { "pink_A700", ColorTranslator.FromHtml ("#c51162") },

            { "purple_50", ColorTranslator.FromHtml ("#f3e5f5") },
            { "purple_100", ColorTranslator.FromHtml ("#e1bee7") },
            { "purple_200", ColorTranslator.FromHtml ("#ce93d8") },
            { "purple_300", ColorTranslator.FromHtml ("#ba68c8") },
            { "purple_400", ColorTranslator.FromHtml ("#ab47bc") },
            { "purple_500", ColorTranslator.FromHtml ("#9c27b0") },
            { "purple_600", ColorTranslator.FromHtml ("#8e24aa") },
            { "purple_700", ColorTranslator.FromHtml ("#7b1fa2") },
            { "purple_800", ColorTranslator.FromHtml ("#6a1b9a") },
            { "purple_900", ColorTranslator.FromHtml ("#4a148c") },
            { "purple_A100", ColorTranslator.FromHtml ("#ea80fc") },
            { "purple_A200", ColorTranslator.FromHtml ("#e040fb") },
            { "purple_A400", ColorTranslator.FromHtml ("#d500f9") },
            { "purple_A700", ColorTranslator.FromHtml ("#aa00ff") },

            { "red_50", ColorTranslator.FromHtml ("#fde0dc") },
            { "red_100", ColorTranslator.FromHtml ("#f9bdbb") },
            { "red_200", ColorTranslator.FromHtml ("#f69988") },
            { "red_300", ColorTranslator.FromHtml ("#f36c60") },
            { "red_400", ColorTranslator.FromHtml ("#e84e40") },
            { "red_500", ColorTranslator.FromHtml ("#e51c23") },
            { "red_600", ColorTranslator.FromHtml ("#dd191d") },
            { "red_700", ColorTranslator.FromHtml ("#d01716") },
            { "red_800", ColorTranslator.FromHtml ("#c41411") },
            { "red_900", ColorTranslator.FromHtml ("#b0120a") },
            { "red_A100", ColorTranslator.FromHtml ("#ff7997") },
            { "red_A200", ColorTranslator.FromHtml ("#ff5177") },
            { "red_A400", ColorTranslator.FromHtml ("#ff2d6f") },
            { "red_A700", ColorTranslator.FromHtml ("#e00032") },

            { "teal_50", ColorTranslator.FromHtml ("#e0f2f1") },
            { "teal_100", ColorTranslator.FromHtml ("#b2dfdb") },
            { "teal_200", ColorTranslator.FromHtml ("#80cbc4") },
            { "teal_300", ColorTranslator.FromHtml ("#4db6ac") },
            { "teal_400", ColorTranslator.FromHtml ("#26a69a") },
            { "teal_500", ColorTranslator.FromHtml ("#9688") },
            { "teal_600", ColorTranslator.FromHtml ("#00897b") },
            { "teal_700", ColorTranslator.FromHtml ("#00796b") },
            { "teal_800", ColorTranslator.FromHtml ("#00695c") },
            { "teal_900", ColorTranslator.FromHtml ("#004d40") },
            { "teal_A100", ColorTranslator.FromHtml ("#a7ffeb") },
            { "teal_A200", ColorTranslator.FromHtml ("#64ffda") },
            { "teal_A400", ColorTranslator.FromHtml ("#1de9b6") },
            { "teal_A700", ColorTranslator.FromHtml ("#00bfa5") },

            { "yellow_50", ColorTranslator.FromHtml ("#fffde7") },
            { "yellow_100", ColorTranslator.FromHtml ("#fff9c4") },
            { "yellow_200", ColorTranslator.FromHtml ("#fff59d") },
            { "yellow_300", ColorTranslator.FromHtml ("#fff176") },
            { "yellow_400", ColorTranslator.FromHtml ("#ffee58") },
            { "yellow_500", ColorTranslator.FromHtml ("#ffeb3b") },
            { "yellow_600", ColorTranslator.FromHtml ("#fdd835") },
            { "yellow_700", ColorTranslator.FromHtml ("#fbc02d") },
            { "yellow_800", ColorTranslator.FromHtml ("#f9a825") },
            { "yellow_900", ColorTranslator.FromHtml ("#f57f17") },
            { "yellow_A100", ColorTranslator.FromHtml ("#ffff8d") },
            { "yellow_A200", ColorTranslator.FromHtml ("#ffff00") },
            { "yellow_A400", ColorTranslator.FromHtml ("#ffea00") },
            { "yellow_A700", ColorTranslator.FromHtml ("#ffd600") }
        };
    }
}

