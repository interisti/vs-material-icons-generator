using System.Collections.Generic;
using System.Drawing;

namespace MaterialIconsGenerator.Core
{
    public class MaterialIconColor : IIconColor
    {
        public string Name { get; set; }

        public Color Color { get; set; }

        public static List<MaterialIconColor> Get()
        {
            return new List<MaterialIconColor>()
            {
                #region Black & White
                new MaterialIconColor() { Name = "white", Color = Color.White },
                new MaterialIconColor() { Name = "black", Color = Color.Black },
                #endregion

                #region Custom
                new MaterialIconColor() { Name = "blue_dark", Color = Color.FromArgb (0, 153, 204) },
                new MaterialIconColor() { Name = "blue_light", Color = Color.FromArgb (51, 181, 229) },
                new MaterialIconColor() { Name = "green_dark", Color = Color.FromArgb (102, 153, 0) },
                new MaterialIconColor() { Name = "green_light", Color = Color.FromArgb (153, 204, 0) },
                new MaterialIconColor() { Name = "purple_dark", Color = Color.FromArgb (153, 51, 204) },
                new MaterialIconColor() { Name = "purple_light", Color = Color.FromArgb (170, 102, 204) },
                new MaterialIconColor() { Name = "red_dark", Color = Color.FromArgb (204, 0, 0) },
                new MaterialIconColor() { Name = "red_light", Color = Color.FromArgb (255, 68, 68) },
                new MaterialIconColor() { Name = "yellow_dark", Color = Color.FromArgb (255, 136, 0) },
                new MaterialIconColor() { Name = "yellow_light", Color = Color.FromArgb (255, 187, 51) },
                #endregion

                #region Amber
                new MaterialIconColor() { Name = "amber_50", Color = ColorTranslator.FromHtml ("#fff8e1") },
                new MaterialIconColor() { Name = "amber_100", Color = ColorTranslator.FromHtml ("#ffecb3") },
                new MaterialIconColor() { Name = "amber_200", Color = ColorTranslator.FromHtml ("#ffe082") },
                new MaterialIconColor() { Name = "amber_300", Color = ColorTranslator.FromHtml ("#ffd54f") },
                new MaterialIconColor() { Name = "amber_400", Color = ColorTranslator.FromHtml ("#ffca28") },
                new MaterialIconColor() { Name = "amber_500", Color = ColorTranslator.FromHtml ("#ffc107") },
                new MaterialIconColor() { Name = "amber_600", Color = ColorTranslator.FromHtml ("#ffb300") },
                new MaterialIconColor() { Name = "amber_700", Color = ColorTranslator.FromHtml ("#ffa000") },
                new MaterialIconColor() { Name = "amber_800", Color = ColorTranslator.FromHtml ("#ff8f00") },
                new MaterialIconColor() { Name = "amber_900", Color = ColorTranslator.FromHtml ("#ff6f00") },
                new MaterialIconColor() { Name = "amber_A100", Color = ColorTranslator.FromHtml ("#ffe57f") },
                new MaterialIconColor() { Name = "amber_A200", Color = ColorTranslator.FromHtml ("#ffd740") },
                new MaterialIconColor() { Name = "amber_A400", Color = ColorTranslator.FromHtml ("#ffc400") },
                new MaterialIconColor() { Name = "amber_A700", Color = ColorTranslator.FromHtml ("#ffab00") },
                #endregion

                #region Blue
                new MaterialIconColor() { Name = "blue_50", Color = ColorTranslator.FromHtml ("#e7e9fd") },
                new MaterialIconColor() { Name = "blue_100", Color = ColorTranslator.FromHtml ("#d0d9ff") },
                new MaterialIconColor() { Name = "blue_200", Color = ColorTranslator.FromHtml ("#afbfff") },
                new MaterialIconColor() { Name = "blue_300", Color = ColorTranslator.FromHtml ("#91a7ff") },
                new MaterialIconColor() { Name = "blue_400", Color = ColorTranslator.FromHtml ("#738ffe") },
                new MaterialIconColor() { Name = "blue_500", Color = ColorTranslator.FromHtml ("#5677fc") },
                new MaterialIconColor() { Name = "blue_600", Color = ColorTranslator.FromHtml ("#4e6cef") },
                new MaterialIconColor() { Name = "blue_700", Color = ColorTranslator.FromHtml ("#455ede") },
                new MaterialIconColor() { Name = "blue_800", Color = ColorTranslator.FromHtml ("#3b50ce") },
                new MaterialIconColor() { Name = "blue_900", Color = ColorTranslator.FromHtml ("#2a36b1") },
                new MaterialIconColor() { Name = "blue_A100", Color = ColorTranslator.FromHtml ("#a6baff") },
                new MaterialIconColor() { Name = "blue_A200", Color = ColorTranslator.FromHtml ("#6889ff") },
                new MaterialIconColor() { Name = "blue_A400", Color = ColorTranslator.FromHtml ("#4d73ff") },
                new MaterialIconColor() { Name = "blue_A700", Color = ColorTranslator.FromHtml ("#4d69ff") },
                #endregion
                
                #region Blue Gray
                new MaterialIconColor() { Name = "blue_grey_50", Color = ColorTranslator.FromHtml ("#eceff1") },
                new MaterialIconColor() { Name = "blue_grey_100", Color = ColorTranslator.FromHtml ("#cfd8dc") },
                new MaterialIconColor() { Name = "blue_grey_200", Color = ColorTranslator.FromHtml ("#b0bec5") },
                new MaterialIconColor() { Name = "blue_grey_300", Color = ColorTranslator.FromHtml ("#90a4ae") },
                new MaterialIconColor() { Name = "blue_grey_400", Color = ColorTranslator.FromHtml ("#78909c") },
                new MaterialIconColor() { Name = "blue_grey_500", Color = ColorTranslator.FromHtml ("#607d8b") },
                new MaterialIconColor() { Name = "blue_grey_600", Color = ColorTranslator.FromHtml ("#546e7a") },
                new MaterialIconColor() { Name = "blue_grey_700", Color = ColorTranslator.FromHtml ("#455a64") },
                new MaterialIconColor() { Name = "blue_grey_800", Color = ColorTranslator.FromHtml ("#37474f") },
                new MaterialIconColor() { Name = "blue_grey_900", Color = ColorTranslator.FromHtml ("#263238") },
                #endregion
                
                #region Brown
                new MaterialIconColor() { Name = "brown_50", Color = ColorTranslator.FromHtml ("#efebe9") },
                new MaterialIconColor() { Name = "brown_100", Color = ColorTranslator.FromHtml ("#d7ccc8") },
                new MaterialIconColor() { Name = "brown_200", Color = ColorTranslator.FromHtml ("#bcaaa4") },
                new MaterialIconColor() { Name = "brown_300", Color = ColorTranslator.FromHtml ("#a1887f") },
                new MaterialIconColor() { Name = "brown_400", Color = ColorTranslator.FromHtml ("#8d6e63") },
                new MaterialIconColor() { Name = "brown_500", Color = ColorTranslator.FromHtml ("#795548") },
                new MaterialIconColor() { Name = "brown_600", Color = ColorTranslator.FromHtml ("#6d4c41") },
                new MaterialIconColor() { Name = "brown_700", Color = ColorTranslator.FromHtml ("#5d4037") },
                new MaterialIconColor() { Name = "brown_800", Color = ColorTranslator.FromHtml ("#4e342e") },
                new MaterialIconColor() { Name = "brown_900", Color = ColorTranslator.FromHtml ("#3e2723") },
                #endregion
                
                #region Cyan
                new MaterialIconColor() { Name = "cyan_50", Color = ColorTranslator.FromHtml ("#e0f7fa") },
                new MaterialIconColor() { Name = "cyan_100", Color = ColorTranslator.FromHtml ("#b2ebf2") },
                new MaterialIconColor() { Name = "cyan_200", Color = ColorTranslator.FromHtml ("#80deea") },
                new MaterialIconColor() { Name = "cyan_300", Color = ColorTranslator.FromHtml ("#4dd0e1") },
                new MaterialIconColor() { Name = "cyan_400", Color = ColorTranslator.FromHtml ("#26c6da") },
                new MaterialIconColor() { Name = "cyan_500", Color = ColorTranslator.FromHtml ("#00bcd4") },
                new MaterialIconColor() { Name = "cyan_600", Color = ColorTranslator.FromHtml ("#00acc1") },
                new MaterialIconColor() { Name = "cyan_700", Color = ColorTranslator.FromHtml ("#0097a7") },
                new MaterialIconColor() { Name = "cyan_800", Color = ColorTranslator.FromHtml ("#00838f") },
                new MaterialIconColor() { Name = "cyan_900", Color = ColorTranslator.FromHtml ("#006064") },
                new MaterialIconColor() { Name = "cyan_A100", Color = ColorTranslator.FromHtml ("#84ffff") },
                new MaterialIconColor() { Name = "cyan_A200", Color = ColorTranslator.FromHtml ("#18ffff") },
                new MaterialIconColor() { Name = "cyan_A400", Color = ColorTranslator.FromHtml ("#00e5ff") },
                new MaterialIconColor() { Name = "cyan_A700", Color = ColorTranslator.FromHtml ("#00b8d4") },
                #endregion
                
                #region Dark Purple
                new MaterialIconColor() { Name = "dark_purple_50", Color = ColorTranslator.FromHtml ("#ede7f6") },
                new MaterialIconColor() { Name = "dark_purple_100", Color = ColorTranslator.FromHtml ("#d1c4e9") },
                new MaterialIconColor() { Name = "dark_purple_200", Color = ColorTranslator.FromHtml ("#b39ddb") },
                new MaterialIconColor() { Name = "dark_purple_300", Color = ColorTranslator.FromHtml ("#9575cd") },
                new MaterialIconColor() { Name = "dark_purple_400", Color = ColorTranslator.FromHtml ("#7e57c2") },
                new MaterialIconColor() { Name = "dark_purple_500", Color = ColorTranslator.FromHtml ("#673ab7") },
                new MaterialIconColor() { Name = "dark_purple_600", Color = ColorTranslator.FromHtml ("#5e35b1") },
                new MaterialIconColor() { Name = "dark_purple_700", Color = ColorTranslator.FromHtml ("#512da8") },
                new MaterialIconColor() { Name = "dark_purple_800", Color = ColorTranslator.FromHtml ("#4527a0") },
                new MaterialIconColor() { Name = "dark_purple_900", Color = ColorTranslator.FromHtml ("#311b92") },
                new MaterialIconColor() { Name = "dark_purple_A100", Color = ColorTranslator.FromHtml ("#b388ff") },
                new MaterialIconColor() { Name = "dark_purple_A200", Color = ColorTranslator.FromHtml ("#7c4dff") },
                new MaterialIconColor() { Name = "dark_purple_A400", Color = ColorTranslator.FromHtml ("#651fff") },
                new MaterialIconColor() { Name = "dark_purple_A700", Color = ColorTranslator.FromHtml ("#6200ea") },
                #endregion
                
                #region Deep Orange
                new MaterialIconColor() { Name = "deep_orange_50", Color = ColorTranslator.FromHtml ("#fbe9e7") },
                new MaterialIconColor() { Name = "deep_orange_100", Color = ColorTranslator.FromHtml ("#ffccbc") },
                new MaterialIconColor() { Name = "deep_orange_200", Color = ColorTranslator.FromHtml ("#ffab91") },
                new MaterialIconColor() { Name = "deep_orange_300", Color = ColorTranslator.FromHtml ("#ff8a65") },
                new MaterialIconColor() { Name = "deep_orange_400", Color = ColorTranslator.FromHtml ("#ff7043") },
                new MaterialIconColor() { Name = "deep_orange_500", Color = ColorTranslator.FromHtml ("#ff5722") },
                new MaterialIconColor() { Name = "deep_orange_600", Color = ColorTranslator.FromHtml ("#f4511e") },
                new MaterialIconColor() { Name = "deep_orange_700", Color = ColorTranslator.FromHtml ("#e64a19") },
                new MaterialIconColor() { Name = "deep_orange_800", Color = ColorTranslator.FromHtml ("#d84315") },
                new MaterialIconColor() { Name = "deep_orange_900", Color = ColorTranslator.FromHtml ("#bf360c") },
                new MaterialIconColor() { Name = "deep_orange_A100", Color = ColorTranslator.FromHtml ("#ff9e80") },
                new MaterialIconColor() { Name = "deep_orange_A200", Color = ColorTranslator.FromHtml ("#ff6e40") },
                new MaterialIconColor() { Name = "deep_orange_A400", Color = ColorTranslator.FromHtml ("#ff3d00") },
                new MaterialIconColor() { Name = "deep_orange_A700", Color = ColorTranslator.FromHtml ("#dd2c00") },
                #endregion
                
                #region Green
                new MaterialIconColor() { Name = "green_50", Color = ColorTranslator.FromHtml ("#d0f8ce") },
                new MaterialIconColor() { Name = "green_100", Color = ColorTranslator.FromHtml ("#a3e9a4") },
                new MaterialIconColor() { Name = "green_200", Color = ColorTranslator.FromHtml ("#72d572") },
                new MaterialIconColor() { Name = "green_300", Color = ColorTranslator.FromHtml ("#42bd41") },
                new MaterialIconColor() { Name = "green_400", Color = ColorTranslator.FromHtml ("#2baf2b") },
                new MaterialIconColor() { Name = "green_500", Color = ColorTranslator.FromHtml ("#259b24") },
                new MaterialIconColor() { Name = "green_600", Color = ColorTranslator.FromHtml ("#0a8f08") },
                new MaterialIconColor() { Name = "green_700", Color = ColorTranslator.FromHtml ("#0a7e07") },
                new MaterialIconColor() { Name = "green_800", Color = ColorTranslator.FromHtml ("#056f00") },
                new MaterialIconColor() { Name = "green_900", Color = ColorTranslator.FromHtml ("#0d5302") },
                new MaterialIconColor() { Name = "green_A100", Color = ColorTranslator.FromHtml ("#a2f78d") },
                new MaterialIconColor() { Name = "green_A200", Color = ColorTranslator.FromHtml ("#5af158") },
                new MaterialIconColor() { Name = "green_A400", Color = ColorTranslator.FromHtml ("#14e715") },
                new MaterialIconColor() { Name = "green_A700", Color = ColorTranslator.FromHtml ("#12c700") },
                #endregion
                
                #region Grey
                new MaterialIconColor() { Name = "grey_50", Color = ColorTranslator.FromHtml ("#fafafa") },
                new MaterialIconColor() { Name = "grey_100", Color = ColorTranslator.FromHtml ("#f5f5f5") },
                new MaterialIconColor() { Name = "grey_200", Color = ColorTranslator.FromHtml ("#eeeeee") },
                new MaterialIconColor() { Name = "grey_300", Color = ColorTranslator.FromHtml ("#e0e0e0") },
                new MaterialIconColor() { Name = "grey_400", Color = ColorTranslator.FromHtml ("#bdbdbd") },
                new MaterialIconColor() { Name = "grey_500", Color = ColorTranslator.FromHtml ("#9e9e9e") },
                new MaterialIconColor() { Name = "grey_600", Color = ColorTranslator.FromHtml ("#757575") },
                new MaterialIconColor() { Name = "grey_700", Color = ColorTranslator.FromHtml ("#616161") },
                new MaterialIconColor() { Name = "grey_800", Color = ColorTranslator.FromHtml ("#424242") },
                new MaterialIconColor() { Name = "grey_900", Color = ColorTranslator.FromHtml ("#212121") },
                new MaterialIconColor() { Name = "grey_black_1000", Color = ColorTranslator.FromHtml ("#000000") },
                new MaterialIconColor() { Name = "grey_white_1000", Color = ColorTranslator.FromHtml ("#ffffff") },
                #endregion
                
                #region Indigo
                new MaterialIconColor() { Name = "indigo_50", Color = ColorTranslator.FromHtml ("#e8eaf6") },
                new MaterialIconColor() { Name = "indigo_100", Color = ColorTranslator.FromHtml ("#c5cae9") },
                new MaterialIconColor() { Name = "indigo_200", Color = ColorTranslator.FromHtml ("#9fa8da") },
                new MaterialIconColor() { Name = "indigo_300", Color = ColorTranslator.FromHtml ("#7986cb") },
                new MaterialIconColor() { Name = "indigo_400", Color = ColorTranslator.FromHtml ("#5c6bc0") },
                new MaterialIconColor() { Name = "indigo_500", Color = ColorTranslator.FromHtml ("#3f51b5") },
                new MaterialIconColor() { Name = "indigo_600", Color = ColorTranslator.FromHtml ("#3949ab") },
                new MaterialIconColor() { Name = "indigo_700", Color = ColorTranslator.FromHtml ("#303f9f") },
                new MaterialIconColor() { Name = "indigo_800", Color = ColorTranslator.FromHtml ("#283593") },
                new MaterialIconColor() { Name = "indigo_900", Color = ColorTranslator.FromHtml ("#1a237e") },
                new MaterialIconColor() { Name = "indigo_A100", Color = ColorTranslator.FromHtml ("#8c9eff") },
                new MaterialIconColor() { Name = "indigo_A200", Color = ColorTranslator.FromHtml ("#536dfe") },
                new MaterialIconColor() { Name = "indigo_A400", Color = ColorTranslator.FromHtml ("#3d5afe") },
                new MaterialIconColor() { Name = "indigo_A700", Color = ColorTranslator.FromHtml ("#304ffe") },
                #endregion
                
                #region Light Blue
                new MaterialIconColor() { Name = "light_blue_50", Color = ColorTranslator.FromHtml ("#e1f5fe") },
                new MaterialIconColor() { Name = "light_blue_100", Color = ColorTranslator.FromHtml ("#b3e5fc") },
                new MaterialIconColor() { Name = "light_blue_200", Color = ColorTranslator.FromHtml ("#81d4fa") },
                new MaterialIconColor() { Name = "light_blue_300", Color = ColorTranslator.FromHtml ("#4fc3f7") },
                new MaterialIconColor() { Name = "light_blue_400", Color = ColorTranslator.FromHtml ("#29b6f6") },
                new MaterialIconColor() { Name = "light_blue_500", Color = ColorTranslator.FromHtml ("#03a9f4") },
                new MaterialIconColor() { Name = "light_blue_600", Color = ColorTranslator.FromHtml ("#039be5") },
                new MaterialIconColor() { Name = "light_blue_700", Color = ColorTranslator.FromHtml ("#0288d1") },
                new MaterialIconColor() { Name = "light_blue_800", Color = ColorTranslator.FromHtml ("#0277bd") },
                new MaterialIconColor() { Name = "light_blue_900", Color = ColorTranslator.FromHtml ("#01579b") },
                new MaterialIconColor() { Name = "light_blue_A100", Color = ColorTranslator.FromHtml ("#80d8ff") },
                new MaterialIconColor() { Name = "light_blue_A200", Color = ColorTranslator.FromHtml ("#40c4ff") },
                new MaterialIconColor() { Name = "light_blue_A400", Color = ColorTranslator.FromHtml ("#00b0ff") },
                new MaterialIconColor() { Name = "light_blue_A700", Color = ColorTranslator.FromHtml ("#0091ea") },
                #endregion
                
                #region Light Green
                new MaterialIconColor() { Name = "light_green_50", Color = ColorTranslator.FromHtml ("#f1f8e9") },
                new MaterialIconColor() { Name = "light_green_100", Color = ColorTranslator.FromHtml ("#dcedc8") },
                new MaterialIconColor() { Name = "light_green_200", Color = ColorTranslator.FromHtml ("#c5e1a5") },
                new MaterialIconColor() { Name = "light_green_300", Color = ColorTranslator.FromHtml ("#aed581") },
                new MaterialIconColor() { Name = "light_green_400", Color = ColorTranslator.FromHtml ("#9ccc65") },
                new MaterialIconColor() { Name = "light_green_500", Color = ColorTranslator.FromHtml ("#8bc34a") },
                new MaterialIconColor() { Name = "light_green_600", Color = ColorTranslator.FromHtml ("#7cb342") },
                new MaterialIconColor() { Name = "light_green_700", Color = ColorTranslator.FromHtml ("#689f38") },
                new MaterialIconColor() { Name = "light_green_800", Color = ColorTranslator.FromHtml ("#558b2f") },
                new MaterialIconColor() { Name = "light_green_900", Color = ColorTranslator.FromHtml ("#33691e") },
                new MaterialIconColor() { Name = "light_green_A100", Color = ColorTranslator.FromHtml ("#ccff90") },
                new MaterialIconColor() { Name = "light_green_A200", Color = ColorTranslator.FromHtml ("#b2ff59") },
                new MaterialIconColor() { Name = "light_green_A400", Color = ColorTranslator.FromHtml ("#76ff03") },
                new MaterialIconColor() { Name = "light_green_A700", Color = ColorTranslator.FromHtml ("#64dd17") },
                #endregion

                #region Lime
                new MaterialIconColor() { Name = "lime_50", Color = ColorTranslator.FromHtml ("#f9fbe7") },
                new MaterialIconColor() { Name = "lime_100", Color = ColorTranslator.FromHtml ("#f0f4c3") },
                new MaterialIconColor() { Name = "lime_200", Color = ColorTranslator.FromHtml ("#e6ee9c") },
                new MaterialIconColor() { Name = "lime_300", Color = ColorTranslator.FromHtml ("#dce775") },
                new MaterialIconColor() { Name = "lime_400", Color = ColorTranslator.FromHtml ("#d4e157") },
                new MaterialIconColor() { Name = "lime_500", Color = ColorTranslator.FromHtml ("#cddc39") },
                new MaterialIconColor() { Name = "lime_600", Color = ColorTranslator.FromHtml ("#c0ca33") },
                new MaterialIconColor() { Name = "lime_700", Color = ColorTranslator.FromHtml ("#afb42b") },
                new MaterialIconColor() { Name = "lime_800", Color = ColorTranslator.FromHtml ("#9e9d24") },
                new MaterialIconColor() { Name = "lime_900", Color = ColorTranslator.FromHtml ("#827717") },
                new MaterialIconColor() { Name = "lime_A100", Color = ColorTranslator.FromHtml ("#f4ff81") },
                new MaterialIconColor() { Name = "lime_A200", Color = ColorTranslator.FromHtml ("#eeff41") },
                new MaterialIconColor() { Name = "lime_A400", Color = ColorTranslator.FromHtml ("#c6ff00") },
                new MaterialIconColor() { Name = "lime_A700", Color = ColorTranslator.FromHtml ("#aeea00") },
                #endregion
                
                #region Orange
                new MaterialIconColor() { Name = "orange_50", Color = ColorTranslator.FromHtml ("#fff3e0") },
                new MaterialIconColor() { Name = "orange_100", Color = ColorTranslator.FromHtml ("#ffe0b2") },
                new MaterialIconColor() { Name = "orange_200", Color = ColorTranslator.FromHtml ("#ffcc80") },
                new MaterialIconColor() { Name = "orange_300", Color = ColorTranslator.FromHtml ("#ffb74d") },
                new MaterialIconColor() { Name = "orange_400", Color = ColorTranslator.FromHtml ("#ffa726") },
                new MaterialIconColor() { Name = "orange_500", Color = ColorTranslator.FromHtml ("#ff9800") },
                new MaterialIconColor() { Name = "orange_600", Color = ColorTranslator.FromHtml ("#fb8c00") },
                new MaterialIconColor() { Name = "orange_700", Color = ColorTranslator.FromHtml ("#f57c00") },
                new MaterialIconColor() { Name = "orange_800", Color = ColorTranslator.FromHtml ("#ef6c00") },
                new MaterialIconColor() { Name = "orange_900", Color = ColorTranslator.FromHtml ("#e65100") },
                new MaterialIconColor() { Name = "orange_A100", Color = ColorTranslator.FromHtml ("#ffd180") },
                new MaterialIconColor() { Name = "orange_A200", Color = ColorTranslator.FromHtml ("#ffab40") },
                new MaterialIconColor() { Name = "orange_A400", Color = ColorTranslator.FromHtml ("#ff9100") },
                new MaterialIconColor() { Name = "orange_A700", Color = ColorTranslator.FromHtml ("#ff6d00") },
                #endregion
                
                #region Pink
                new MaterialIconColor() { Name = "pink_50", Color = ColorTranslator.FromHtml ("#fce4ec") },
                new MaterialIconColor() { Name = "pink_100", Color = ColorTranslator.FromHtml ("#f8bbd0") },
                new MaterialIconColor() { Name = "pink_200", Color = ColorTranslator.FromHtml ("#f48fb1") },
                new MaterialIconColor() { Name = "pink_300", Color = ColorTranslator.FromHtml ("#f06292") },
                new MaterialIconColor() { Name = "pink_400", Color = ColorTranslator.FromHtml ("#ec407a") },
                new MaterialIconColor() { Name = "pink_500", Color = ColorTranslator.FromHtml ("#e91e63") },
                new MaterialIconColor() { Name = "pink_600", Color = ColorTranslator.FromHtml ("#d81b60") },
                new MaterialIconColor() { Name = "pink_700", Color = ColorTranslator.FromHtml ("#c2185b") },
                new MaterialIconColor() { Name = "pink_800", Color = ColorTranslator.FromHtml ("#ad1457") },
                new MaterialIconColor() { Name = "pink_900", Color = ColorTranslator.FromHtml ("#880e4f") },
                new MaterialIconColor() { Name = "pink_A100", Color = ColorTranslator.FromHtml ("#ff80ab") },
                new MaterialIconColor() { Name = "pink_A200", Color = ColorTranslator.FromHtml ("#ff4081") },
                new MaterialIconColor() { Name = "pink_A400", Color = ColorTranslator.FromHtml ("#f50057") },
                new MaterialIconColor() { Name = "pink_A700", Color = ColorTranslator.FromHtml ("#c51162") },
                #endregion
                
                #region Purple
                new MaterialIconColor() { Name = "purple_50", Color = ColorTranslator.FromHtml ("#f3e5f5") },
                new MaterialIconColor() { Name = "purple_100", Color = ColorTranslator.FromHtml ("#e1bee7") },
                new MaterialIconColor() { Name = "purple_200", Color = ColorTranslator.FromHtml ("#ce93d8") },
                new MaterialIconColor() { Name = "purple_300", Color = ColorTranslator.FromHtml ("#ba68c8") },
                new MaterialIconColor() { Name = "purple_400", Color = ColorTranslator.FromHtml ("#ab47bc") },
                new MaterialIconColor() { Name = "purple_500", Color = ColorTranslator.FromHtml ("#9c27b0") },
                new MaterialIconColor() { Name = "purple_600", Color = ColorTranslator.FromHtml ("#8e24aa") },
                new MaterialIconColor() { Name = "purple_700", Color = ColorTranslator.FromHtml ("#7b1fa2") },
                new MaterialIconColor() { Name = "purple_800", Color = ColorTranslator.FromHtml ("#6a1b9a") },
                new MaterialIconColor() { Name = "purple_900", Color = ColorTranslator.FromHtml ("#4a148c") },
                new MaterialIconColor() { Name = "purple_A100", Color = ColorTranslator.FromHtml ("#ea80fc") },
                new MaterialIconColor() { Name = "purple_A200", Color = ColorTranslator.FromHtml ("#e040fb") },
                new MaterialIconColor() { Name = "purple_A400", Color = ColorTranslator.FromHtml ("#d500f9") },
                new MaterialIconColor() { Name = "purple_A700", Color = ColorTranslator.FromHtml ("#aa00ff") },
                #endregion
                
                #region Red
                new MaterialIconColor() { Name = "red_50", Color = ColorTranslator.FromHtml ("#fde0dc") },
                new MaterialIconColor() { Name = "red_100", Color = ColorTranslator.FromHtml ("#f9bdbb") },
                new MaterialIconColor() { Name = "red_200", Color = ColorTranslator.FromHtml ("#f69988") },
                new MaterialIconColor() { Name = "red_300", Color = ColorTranslator.FromHtml ("#f36c60") },
                new MaterialIconColor() { Name = "red_400", Color = ColorTranslator.FromHtml ("#e84e40") },
                new MaterialIconColor() { Name = "red_500", Color = ColorTranslator.FromHtml ("#e51c23") },
                new MaterialIconColor() { Name = "red_600", Color = ColorTranslator.FromHtml ("#dd191d") },
                new MaterialIconColor() { Name = "red_700", Color = ColorTranslator.FromHtml ("#d01716") },
                new MaterialIconColor() { Name = "red_800", Color = ColorTranslator.FromHtml ("#c41411") },
                new MaterialIconColor() { Name = "red_900", Color = ColorTranslator.FromHtml ("#b0120a") },
                new MaterialIconColor() { Name = "red_A100", Color = ColorTranslator.FromHtml ("#ff7997") },
                new MaterialIconColor() { Name = "red_A200", Color = ColorTranslator.FromHtml ("#ff5177") },
                new MaterialIconColor() { Name = "red_A400", Color = ColorTranslator.FromHtml ("#ff2d6f") },
                new MaterialIconColor() { Name = "red_A700", Color = ColorTranslator.FromHtml ("#e00032") },
                #endregion
                
                #region Teal
                new MaterialIconColor() { Name = "teal_50", Color = ColorTranslator.FromHtml ("#e0f2f1") },
                new MaterialIconColor() { Name = "teal_100", Color = ColorTranslator.FromHtml ("#b2dfdb") },
                new MaterialIconColor() { Name = "teal_200", Color = ColorTranslator.FromHtml ("#80cbc4") },
                new MaterialIconColor() { Name = "teal_300", Color = ColorTranslator.FromHtml ("#4db6ac") },
                new MaterialIconColor() { Name = "teal_400", Color = ColorTranslator.FromHtml ("#26a69a") },
                new MaterialIconColor() { Name = "teal_500", Color = ColorTranslator.FromHtml ("#9688") },
                new MaterialIconColor() { Name = "teal_600", Color = ColorTranslator.FromHtml ("#00897b") },
                new MaterialIconColor() { Name = "teal_700", Color = ColorTranslator.FromHtml ("#00796b") },
                new MaterialIconColor() { Name = "teal_800", Color = ColorTranslator.FromHtml ("#00695c") },
                new MaterialIconColor() { Name = "teal_900", Color = ColorTranslator.FromHtml ("#004d40") },
                new MaterialIconColor() { Name = "teal_A100", Color = ColorTranslator.FromHtml ("#a7ffeb") },
                new MaterialIconColor() { Name = "teal_A200", Color = ColorTranslator.FromHtml ("#64ffda") },
                new MaterialIconColor() { Name = "teal_A400", Color = ColorTranslator.FromHtml ("#1de9b6") },
                new MaterialIconColor() { Name = "teal_A700", Color = ColorTranslator.FromHtml ("#00bfa5") },
                #endregion
                
                #region Yellow
                new MaterialIconColor() { Name = "yellow_50", Color = ColorTranslator.FromHtml ("#fffde7") },
                new MaterialIconColor() { Name = "yellow_100", Color = ColorTranslator.FromHtml ("#fff9c4") },
                new MaterialIconColor() { Name = "yellow_200", Color = ColorTranslator.FromHtml ("#fff59d") },
                new MaterialIconColor() { Name = "yellow_300", Color = ColorTranslator.FromHtml ("#fff176") },
                new MaterialIconColor() { Name = "yellow_400", Color = ColorTranslator.FromHtml ("#ffee58") },
                new MaterialIconColor() { Name = "yellow_500", Color = ColorTranslator.FromHtml ("#ffeb3b") },
                new MaterialIconColor() { Name = "yellow_600", Color = ColorTranslator.FromHtml ("#fdd835") },
                new MaterialIconColor() { Name = "yellow_700", Color = ColorTranslator.FromHtml ("#fbc02d") },
                new MaterialIconColor() { Name = "yellow_800", Color = ColorTranslator.FromHtml ("#f9a825") },
                new MaterialIconColor() { Name = "yellow_900", Color = ColorTranslator.FromHtml ("#f57f17") },
                new MaterialIconColor() { Name = "yellow_A100", Color = ColorTranslator.FromHtml ("#ffff8d") },
                new MaterialIconColor() { Name = "yellow_A200", Color = ColorTranslator.FromHtml ("#ffff00") },
                new MaterialIconColor() { Name = "yellow_A400", Color = ColorTranslator.FromHtml ("#ffea00") },
                new MaterialIconColor() { Name = "yellow_A700", Color = ColorTranslator.FromHtml ("#ffd600") }
                #endregion
            };
        }
    }
}
