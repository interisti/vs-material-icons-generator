using System.Collections.Generic;
using System.Drawing;
using MaterialIconsGenerator.Core;

namespace MaterialIconsGenerator.Models
{
    public class MaterialIconColor : IIconColor
    {
        public string Name { get; set; }

        public Color Color { get; set; }

        public bool IsEditable { get => false; }

        public bool Edit(string hex) => false;

        #region Black & White
        public static MaterialIconColor White = new MaterialIconColor() { Name = "white", Color = Color.White };
        public static MaterialIconColor Black = new MaterialIconColor() { Name = "black", Color = Color.Black };
        #endregion

        #region Custom
        public static MaterialIconColor BlueDark = new MaterialIconColor() { Name = "blue_dark", Color = Color.FromArgb(0, 153, 204) };
        public static MaterialIconColor BlueLight = new MaterialIconColor() { Name = "blue_light", Color = Color.FromArgb(51, 181, 229) };
        public static MaterialIconColor GreenDark = new MaterialIconColor() { Name = "green_dark", Color = Color.FromArgb(102, 153, 0) };
        public static MaterialIconColor GreenLight = new MaterialIconColor() { Name = "green_light", Color = Color.FromArgb(153, 204, 0) };
        public static MaterialIconColor PurpleDark = new MaterialIconColor() { Name = "purple_dark", Color = Color.FromArgb(153, 51, 204) };
        public static MaterialIconColor PurpleLight = new MaterialIconColor() { Name = "purple_light", Color = Color.FromArgb(170, 102, 204) };
        public static MaterialIconColor RedDark = new MaterialIconColor() { Name = "red_dark", Color = Color.FromArgb(204, 0, 0) };
        public static MaterialIconColor RedLight = new MaterialIconColor() { Name = "red_light", Color = Color.FromArgb(255, 68, 68) };
        public static MaterialIconColor YellowDark = new MaterialIconColor() { Name = "yellow_dark", Color = Color.FromArgb(255, 136, 0) };
        public static MaterialIconColor YellowLight = new MaterialIconColor() { Name = "yellow_light", Color = Color.FromArgb(255, 187, 51) };
        #endregion

        #region Amber
        public static MaterialIconColor Amber50 = new MaterialIconColor() { Name = "amber_50", Color = ColorTranslator.FromHtml("#fff8e1") };
        public static MaterialIconColor Amber100 = new MaterialIconColor() { Name = "amber_100", Color = ColorTranslator.FromHtml("#ffecb3") };
        public static MaterialIconColor Amber200 = new MaterialIconColor() { Name = "amber_200", Color = ColorTranslator.FromHtml("#ffe082") };
        public static MaterialIconColor Amber300 = new MaterialIconColor() { Name = "amber_300", Color = ColorTranslator.FromHtml("#ffd54f") };
        public static MaterialIconColor Amber400 = new MaterialIconColor() { Name = "amber_400", Color = ColorTranslator.FromHtml("#ffca28") };
        public static MaterialIconColor Amber500 = new MaterialIconColor() { Name = "amber_500", Color = ColorTranslator.FromHtml("#ffc107") };
        public static MaterialIconColor Amber600 = new MaterialIconColor() { Name = "amber_600", Color = ColorTranslator.FromHtml("#ffb300") };
        public static MaterialIconColor Amber700 = new MaterialIconColor() { Name = "amber_700", Color = ColorTranslator.FromHtml("#ffa000") };
        public static MaterialIconColor Amber800 = new MaterialIconColor() { Name = "amber_800", Color = ColorTranslator.FromHtml("#ff8f00") };
        public static MaterialIconColor Amber900 = new MaterialIconColor() { Name = "amber_900", Color = ColorTranslator.FromHtml("#ff6f00") };
        public static MaterialIconColor AmberA100 = new MaterialIconColor() { Name = "amber_A100", Color = ColorTranslator.FromHtml("#ffe57f") };
        public static MaterialIconColor AmberA200 = new MaterialIconColor() { Name = "amber_A200", Color = ColorTranslator.FromHtml("#ffd740") };
        public static MaterialIconColor AmberA400 = new MaterialIconColor() { Name = "amber_A400", Color = ColorTranslator.FromHtml("#ffc400") };
        public static MaterialIconColor AmberA700 = new MaterialIconColor() { Name = "amber_A700", Color = ColorTranslator.FromHtml("#ffab00") };
        #endregion

        #region Blue
        public static MaterialIconColor Blue50 = new MaterialIconColor() { Name = "blue_50", Color = ColorTranslator.FromHtml("#e7e9fd") };
        public static MaterialIconColor Blue100 = new MaterialIconColor() { Name = "blue_100", Color = ColorTranslator.FromHtml("#d0d9ff") };
        public static MaterialIconColor Blue200 = new MaterialIconColor() { Name = "blue_200", Color = ColorTranslator.FromHtml("#afbfff") };
        public static MaterialIconColor Blue300 = new MaterialIconColor() { Name = "blue_300", Color = ColorTranslator.FromHtml("#91a7ff") };
        public static MaterialIconColor Blue400 = new MaterialIconColor() { Name = "blue_400", Color = ColorTranslator.FromHtml("#738ffe") };
        public static MaterialIconColor Blue500 = new MaterialIconColor() { Name = "blue_500", Color = ColorTranslator.FromHtml("#5677fc") };
        public static MaterialIconColor Blue600 = new MaterialIconColor() { Name = "blue_600", Color = ColorTranslator.FromHtml("#4e6cef") };
        public static MaterialIconColor Blue700 = new MaterialIconColor() { Name = "blue_700", Color = ColorTranslator.FromHtml("#455ede") };
        public static MaterialIconColor Blue800 = new MaterialIconColor() { Name = "blue_800", Color = ColorTranslator.FromHtml("#3b50ce") };
        public static MaterialIconColor Blue900 = new MaterialIconColor() { Name = "blue_900", Color = ColorTranslator.FromHtml("#2a36b1") };
        public static MaterialIconColor BlueA100 = new MaterialIconColor() { Name = "blue_A100", Color = ColorTranslator.FromHtml("#a6baff") };
        public static MaterialIconColor BlueA200 = new MaterialIconColor() { Name = "blue_A200", Color = ColorTranslator.FromHtml("#6889ff") };
        public static MaterialIconColor BlueA400 = new MaterialIconColor() { Name = "blue_A400", Color = ColorTranslator.FromHtml("#4d73ff") };
        public static MaterialIconColor BlueA700 = new MaterialIconColor() { Name = "blue_A700", Color = ColorTranslator.FromHtml("#4d69ff") };
        #endregion

        #region Blue Gray
        public static MaterialIconColor BlueGrey50 = new MaterialIconColor() { Name = "blue_grey_50", Color = ColorTranslator.FromHtml("#eceff1") };
        public static MaterialIconColor BlueGrey100 = new MaterialIconColor() { Name = "blue_grey_100", Color = ColorTranslator.FromHtml("#cfd8dc") };
        public static MaterialIconColor BlueGrey200 = new MaterialIconColor() { Name = "blue_grey_200", Color = ColorTranslator.FromHtml("#b0bec5") };
        public static MaterialIconColor BlueGrey300 = new MaterialIconColor() { Name = "blue_grey_300", Color = ColorTranslator.FromHtml("#90a4ae") };
        public static MaterialIconColor BlueGrey400 = new MaterialIconColor() { Name = "blue_grey_400", Color = ColorTranslator.FromHtml("#78909c") };
        public static MaterialIconColor BlueGrey500 = new MaterialIconColor() { Name = "blue_grey_500", Color = ColorTranslator.FromHtml("#607d8b") };
        public static MaterialIconColor BlueGrey600 = new MaterialIconColor() { Name = "blue_grey_600", Color = ColorTranslator.FromHtml("#546e7a") };
        public static MaterialIconColor BlueGrey700 = new MaterialIconColor() { Name = "blue_grey_700", Color = ColorTranslator.FromHtml("#455a64") };
        public static MaterialIconColor BlueGrey800 = new MaterialIconColor() { Name = "blue_grey_800", Color = ColorTranslator.FromHtml("#37474f") };
        public static MaterialIconColor BlueGrey900 = new MaterialIconColor() { Name = "blue_grey_900", Color = ColorTranslator.FromHtml("#263238") };
        #endregion

        #region Brown
        public static MaterialIconColor Brown50 = new MaterialIconColor() { Name = "brown_50", Color = ColorTranslator.FromHtml("#efebe9") };
        public static MaterialIconColor Brown100 = new MaterialIconColor() { Name = "brown_100", Color = ColorTranslator.FromHtml("#d7ccc8") };
        public static MaterialIconColor Brown200 = new MaterialIconColor() { Name = "brown_200", Color = ColorTranslator.FromHtml("#bcaaa4") };
        public static MaterialIconColor Brown300 = new MaterialIconColor() { Name = "brown_300", Color = ColorTranslator.FromHtml("#a1887f") };
        public static MaterialIconColor Brown400 = new MaterialIconColor() { Name = "brown_400", Color = ColorTranslator.FromHtml("#8d6e63") };
        public static MaterialIconColor Brown500 = new MaterialIconColor() { Name = "brown_500", Color = ColorTranslator.FromHtml("#795548") };
        public static MaterialIconColor Brown600 = new MaterialIconColor() { Name = "brown_600", Color = ColorTranslator.FromHtml("#6d4c41") };
        public static MaterialIconColor Brown700 = new MaterialIconColor() { Name = "brown_700", Color = ColorTranslator.FromHtml("#5d4037") };
        public static MaterialIconColor Brown800 = new MaterialIconColor() { Name = "brown_800", Color = ColorTranslator.FromHtml("#4e342e") };
        public static MaterialIconColor Brown900 = new MaterialIconColor() { Name = "brown_900", Color = ColorTranslator.FromHtml("#3e2723") };
        #endregion

        #region Cyan
        public static MaterialIconColor Cyan50 = new MaterialIconColor() { Name = "cyan_50", Color = ColorTranslator.FromHtml("#e0f7fa") };
        public static MaterialIconColor Cyan100 = new MaterialIconColor() { Name = "cyan_100", Color = ColorTranslator.FromHtml("#b2ebf2") };
        public static MaterialIconColor Cyan200 = new MaterialIconColor() { Name = "cyan_200", Color = ColorTranslator.FromHtml("#80deea") };
        public static MaterialIconColor Cyan300 = new MaterialIconColor() { Name = "cyan_300", Color = ColorTranslator.FromHtml("#4dd0e1") };
        public static MaterialIconColor Cyan400 = new MaterialIconColor() { Name = "cyan_400", Color = ColorTranslator.FromHtml("#26c6da") };
        public static MaterialIconColor Cyan500 = new MaterialIconColor() { Name = "cyan_500", Color = ColorTranslator.FromHtml("#00bcd4") };
        public static MaterialIconColor Cyan600 = new MaterialIconColor() { Name = "cyan_600", Color = ColorTranslator.FromHtml("#00acc1") };
        public static MaterialIconColor Cyan700 = new MaterialIconColor() { Name = "cyan_700", Color = ColorTranslator.FromHtml("#0097a7") };
        public static MaterialIconColor Cyan800 = new MaterialIconColor() { Name = "cyan_800", Color = ColorTranslator.FromHtml("#00838f") };
        public static MaterialIconColor Cyan900 = new MaterialIconColor() { Name = "cyan_900", Color = ColorTranslator.FromHtml("#006064") };
        public static MaterialIconColor CyanA100 = new MaterialIconColor() { Name = "cyan_A100", Color = ColorTranslator.FromHtml("#84ffff") };
        public static MaterialIconColor CyanA200 = new MaterialIconColor() { Name = "cyan_A200", Color = ColorTranslator.FromHtml("#18ffff") };
        public static MaterialIconColor CyanA400 = new MaterialIconColor() { Name = "cyan_A400", Color = ColorTranslator.FromHtml("#00e5ff") };
        public static MaterialIconColor CyanA700 = new MaterialIconColor() { Name = "cyan_A700", Color = ColorTranslator.FromHtml("#00b8d4") };
        #endregion

        #region Dark Purple
        public static MaterialIconColor DarkPurple50 = new MaterialIconColor() { Name = "dark_purple_50", Color = ColorTranslator.FromHtml("#ede7f6") };
        public static MaterialIconColor DarkPurple100 = new MaterialIconColor() { Name = "dark_purple_100", Color = ColorTranslator.FromHtml("#d1c4e9") };
        public static MaterialIconColor DarkPurple200 = new MaterialIconColor() { Name = "dark_purple_200", Color = ColorTranslator.FromHtml("#b39ddb") };
        public static MaterialIconColor DarkPurple300 = new MaterialIconColor() { Name = "dark_purple_300", Color = ColorTranslator.FromHtml("#9575cd") };
        public static MaterialIconColor DarkPurple400 = new MaterialIconColor() { Name = "dark_purple_400", Color = ColorTranslator.FromHtml("#7e57c2") };
        public static MaterialIconColor DarkPurple500 = new MaterialIconColor() { Name = "dark_purple_500", Color = ColorTranslator.FromHtml("#673ab7") };
        public static MaterialIconColor DarkPurple600 = new MaterialIconColor() { Name = "dark_purple_600", Color = ColorTranslator.FromHtml("#5e35b1") };
        public static MaterialIconColor DarkPurple700 = new MaterialIconColor() { Name = "dark_purple_700", Color = ColorTranslator.FromHtml("#512da8") };
        public static MaterialIconColor DarkPurple800 = new MaterialIconColor() { Name = "dark_purple_800", Color = ColorTranslator.FromHtml("#4527a0") };
        public static MaterialIconColor DarkPurple900 = new MaterialIconColor() { Name = "dark_purple_900", Color = ColorTranslator.FromHtml("#311b92") };
        public static MaterialIconColor DarkPurpleA100 = new MaterialIconColor() { Name = "dark_purple_A100", Color = ColorTranslator.FromHtml("#b388ff") };
        public static MaterialIconColor DarkPurpleA200 = new MaterialIconColor() { Name = "dark_purple_A200", Color = ColorTranslator.FromHtml("#7c4dff") };
        public static MaterialIconColor DarkPurpleA400 = new MaterialIconColor() { Name = "dark_purple_A400", Color = ColorTranslator.FromHtml("#651fff") };
        public static MaterialIconColor DarkPurpleA700 = new MaterialIconColor() { Name = "dark_purple_A700", Color = ColorTranslator.FromHtml("#6200ea") };
        #endregion

        #region Deep Orange
        public static MaterialIconColor DeepOrange50 = new MaterialIconColor() { Name = "deep_orange_50", Color = ColorTranslator.FromHtml("#fbe9e7") };
        public static MaterialIconColor DeepOrange100 = new MaterialIconColor() { Name = "deep_orange_100", Color = ColorTranslator.FromHtml("#ffccbc") };
        public static MaterialIconColor DeepOrange200 = new MaterialIconColor() { Name = "deep_orange_200", Color = ColorTranslator.FromHtml("#ffab91") };
        public static MaterialIconColor DeepOrange300 = new MaterialIconColor() { Name = "deep_orange_300", Color = ColorTranslator.FromHtml("#ff8a65") };
        public static MaterialIconColor DeepOrange400 = new MaterialIconColor() { Name = "deep_orange_400", Color = ColorTranslator.FromHtml("#ff7043") };
        public static MaterialIconColor DeepOrange500 = new MaterialIconColor() { Name = "deep_orange_500", Color = ColorTranslator.FromHtml("#ff5722") };
        public static MaterialIconColor DeepOrange600 = new MaterialIconColor() { Name = "deep_orange_600", Color = ColorTranslator.FromHtml("#f4511e") };
        public static MaterialIconColor DeepOrange700 = new MaterialIconColor() { Name = "deep_orange_700", Color = ColorTranslator.FromHtml("#e64a19") };
        public static MaterialIconColor DeepOrange800 = new MaterialIconColor() { Name = "deep_orange_800", Color = ColorTranslator.FromHtml("#d84315") };
        public static MaterialIconColor DeepOrange900 = new MaterialIconColor() { Name = "deep_orange_900", Color = ColorTranslator.FromHtml("#bf360c") };
        public static MaterialIconColor DeepOrangeA100 = new MaterialIconColor() { Name = "deep_orange_A100", Color = ColorTranslator.FromHtml("#ff9e80") };
        public static MaterialIconColor DeepOrangeA200 = new MaterialIconColor() { Name = "deep_orange_A200", Color = ColorTranslator.FromHtml("#ff6e40") };
        public static MaterialIconColor DeepOrangeA400 = new MaterialIconColor() { Name = "deep_orange_A400", Color = ColorTranslator.FromHtml("#ff3d00") };
        public static MaterialIconColor DeepOrangeA700 = new MaterialIconColor() { Name = "deep_orange_A700", Color = ColorTranslator.FromHtml("#dd2c00") };
        #endregion

        #region Green
        public static MaterialIconColor Green50 = new MaterialIconColor() { Name = "green_50", Color = ColorTranslator.FromHtml("#d0f8ce") };
        public static MaterialIconColor Green100 = new MaterialIconColor() { Name = "green_100", Color = ColorTranslator.FromHtml("#a3e9a4") };
        public static MaterialIconColor Green200 = new MaterialIconColor() { Name = "green_200", Color = ColorTranslator.FromHtml("#72d572") };
        public static MaterialIconColor Green300 = new MaterialIconColor() { Name = "green_300", Color = ColorTranslator.FromHtml("#42bd41") };
        public static MaterialIconColor Green400 = new MaterialIconColor() { Name = "green_400", Color = ColorTranslator.FromHtml("#2baf2b") };
        public static MaterialIconColor Green500 = new MaterialIconColor() { Name = "green_500", Color = ColorTranslator.FromHtml("#259b24") };
        public static MaterialIconColor Green600 = new MaterialIconColor() { Name = "green_600", Color = ColorTranslator.FromHtml("#0a8f08") };
        public static MaterialIconColor Green700 = new MaterialIconColor() { Name = "green_700", Color = ColorTranslator.FromHtml("#0a7e07") };
        public static MaterialIconColor Green800 = new MaterialIconColor() { Name = "green_800", Color = ColorTranslator.FromHtml("#056f00") };
        public static MaterialIconColor Green900 = new MaterialIconColor() { Name = "green_900", Color = ColorTranslator.FromHtml("#0d5302") };
        public static MaterialIconColor GreenA100 = new MaterialIconColor() { Name = "green_A100", Color = ColorTranslator.FromHtml("#a2f78d") };
        public static MaterialIconColor GreenA200 = new MaterialIconColor() { Name = "green_A200", Color = ColorTranslator.FromHtml("#5af158") };
        public static MaterialIconColor GreenA400 = new MaterialIconColor() { Name = "green_A400", Color = ColorTranslator.FromHtml("#14e715") };
        public static MaterialIconColor GreenA700 = new MaterialIconColor() { Name = "green_A700", Color = ColorTranslator.FromHtml("#12c700") };
        #endregion

        #region Grey
        public static MaterialIconColor Grey50 = new MaterialIconColor() { Name = "grey_50", Color = ColorTranslator.FromHtml("#fafafa") };
        public static MaterialIconColor Grey100 = new MaterialIconColor() { Name = "grey_100", Color = ColorTranslator.FromHtml("#f5f5f5") };
        public static MaterialIconColor Grey200 = new MaterialIconColor() { Name = "grey_200", Color = ColorTranslator.FromHtml("#eeeeee") };
        public static MaterialIconColor Grey300 = new MaterialIconColor() { Name = "grey_300", Color = ColorTranslator.FromHtml("#e0e0e0") };
        public static MaterialIconColor Grey400 = new MaterialIconColor() { Name = "grey_400", Color = ColorTranslator.FromHtml("#bdbdbd") };
        public static MaterialIconColor Grey500 = new MaterialIconColor() { Name = "grey_500", Color = ColorTranslator.FromHtml("#9e9e9e") };
        public static MaterialIconColor Grey600 = new MaterialIconColor() { Name = "grey_600", Color = ColorTranslator.FromHtml("#757575") };
        public static MaterialIconColor Grey700 = new MaterialIconColor() { Name = "grey_700", Color = ColorTranslator.FromHtml("#616161") };
        public static MaterialIconColor Grey800 = new MaterialIconColor() { Name = "grey_800", Color = ColorTranslator.FromHtml("#424242") };
        public static MaterialIconColor Grey900 = new MaterialIconColor() { Name = "grey_900", Color = ColorTranslator.FromHtml("#212121") };
        public static MaterialIconColor GreyBlack1000 = new MaterialIconColor() { Name = "grey_black_1000", Color = ColorTranslator.FromHtml("#000000") };
        public static MaterialIconColor GreyWhite1000 = new MaterialIconColor() { Name = "grey_white_1000", Color = ColorTranslator.FromHtml("#ffffff") };
        #endregion

        #region Indigo
        public static MaterialIconColor Indigo50 = new MaterialIconColor() { Name = "indigo_50", Color = ColorTranslator.FromHtml("#e8eaf6") };
        public static MaterialIconColor Indigo100 = new MaterialIconColor() { Name = "indigo_100", Color = ColorTranslator.FromHtml("#c5cae9") };
        public static MaterialIconColor Indigo200 = new MaterialIconColor() { Name = "indigo_200", Color = ColorTranslator.FromHtml("#9fa8da") };
        public static MaterialIconColor Indigo300 = new MaterialIconColor() { Name = "indigo_300", Color = ColorTranslator.FromHtml("#7986cb") };
        public static MaterialIconColor Indigo400 = new MaterialIconColor() { Name = "indigo_400", Color = ColorTranslator.FromHtml("#5c6bc0") };
        public static MaterialIconColor Indigo500 = new MaterialIconColor() { Name = "indigo_500", Color = ColorTranslator.FromHtml("#3f51b5") };
        public static MaterialIconColor Indigo600 = new MaterialIconColor() { Name = "indigo_600", Color = ColorTranslator.FromHtml("#3949ab") };
        public static MaterialIconColor Indigo700 = new MaterialIconColor() { Name = "indigo_700", Color = ColorTranslator.FromHtml("#303f9f") };
        public static MaterialIconColor Indigo800 = new MaterialIconColor() { Name = "indigo_800", Color = ColorTranslator.FromHtml("#283593") };
        public static MaterialIconColor Indigo900 = new MaterialIconColor() { Name = "indigo_900", Color = ColorTranslator.FromHtml("#1a237e") };
        public static MaterialIconColor IndigoA100 = new MaterialIconColor() { Name = "indigo_A100", Color = ColorTranslator.FromHtml("#8c9eff") };
        public static MaterialIconColor IndigoA200 = new MaterialIconColor() { Name = "indigo_A200", Color = ColorTranslator.FromHtml("#536dfe") };
        public static MaterialIconColor IndigoA400 = new MaterialIconColor() { Name = "indigo_A400", Color = ColorTranslator.FromHtml("#3d5afe") };
        public static MaterialIconColor IndigoA700 = new MaterialIconColor() { Name = "indigo_A700", Color = ColorTranslator.FromHtml("#304ffe") };
        #endregion

        #region Light Blue
        public static MaterialIconColor LightBlue50 = new MaterialIconColor() { Name = "light_blue_50", Color = ColorTranslator.FromHtml("#e1f5fe") };
        public static MaterialIconColor LightBlue100 = new MaterialIconColor() { Name = "light_blue_100", Color = ColorTranslator.FromHtml("#b3e5fc") };
        public static MaterialIconColor LightBlue200 = new MaterialIconColor() { Name = "light_blue_200", Color = ColorTranslator.FromHtml("#81d4fa") };
        public static MaterialIconColor LightBlue300 = new MaterialIconColor() { Name = "light_blue_300", Color = ColorTranslator.FromHtml("#4fc3f7") };
        public static MaterialIconColor LightBlue400 = new MaterialIconColor() { Name = "light_blue_400", Color = ColorTranslator.FromHtml("#29b6f6") };
        public static MaterialIconColor LightBlue500 = new MaterialIconColor() { Name = "light_blue_500", Color = ColorTranslator.FromHtml("#03a9f4") };
        public static MaterialIconColor LightBlue600 = new MaterialIconColor() { Name = "light_blue_600", Color = ColorTranslator.FromHtml("#039be5") };
        public static MaterialIconColor LightBlue700 = new MaterialIconColor() { Name = "light_blue_700", Color = ColorTranslator.FromHtml("#0288d1") };
        public static MaterialIconColor LightBlue800 = new MaterialIconColor() { Name = "light_blue_800", Color = ColorTranslator.FromHtml("#0277bd") };
        public static MaterialIconColor LightBlue900 = new MaterialIconColor() { Name = "light_blue_900", Color = ColorTranslator.FromHtml("#01579b") };
        public static MaterialIconColor LightBlueA100 = new MaterialIconColor() { Name = "light_blue_A100", Color = ColorTranslator.FromHtml("#80d8ff") };
        public static MaterialIconColor LightBlueA200 = new MaterialIconColor() { Name = "light_blue_A200", Color = ColorTranslator.FromHtml("#40c4ff") };
        public static MaterialIconColor LightBlueA400 = new MaterialIconColor() { Name = "light_blue_A400", Color = ColorTranslator.FromHtml("#00b0ff") };
        public static MaterialIconColor LightBlueA700 = new MaterialIconColor() { Name = "light_blue_A700", Color = ColorTranslator.FromHtml("#0091ea") };
        #endregion

        #region Light Green
        public static MaterialIconColor LightGreen50 = new MaterialIconColor() { Name = "light_green_50", Color = ColorTranslator.FromHtml("#f1f8e9") };
        public static MaterialIconColor LightGreen100 = new MaterialIconColor() { Name = "light_green_100", Color = ColorTranslator.FromHtml("#dcedc8") };
        public static MaterialIconColor LightGreen200 = new MaterialIconColor() { Name = "light_green_200", Color = ColorTranslator.FromHtml("#c5e1a5") };
        public static MaterialIconColor LightGreen300 = new MaterialIconColor() { Name = "light_green_300", Color = ColorTranslator.FromHtml("#aed581") };
        public static MaterialIconColor LightGreen400 = new MaterialIconColor() { Name = "light_green_400", Color = ColorTranslator.FromHtml("#9ccc65") };
        public static MaterialIconColor LightGreen500 = new MaterialIconColor() { Name = "light_green_500", Color = ColorTranslator.FromHtml("#8bc34a") };
        public static MaterialIconColor LightGreen600 = new MaterialIconColor() { Name = "light_green_600", Color = ColorTranslator.FromHtml("#7cb342") };
        public static MaterialIconColor LightGreen700 = new MaterialIconColor() { Name = "light_green_700", Color = ColorTranslator.FromHtml("#689f38") };
        public static MaterialIconColor LightGreen800 = new MaterialIconColor() { Name = "light_green_800", Color = ColorTranslator.FromHtml("#558b2f") };
        public static MaterialIconColor LightGreen900 = new MaterialIconColor() { Name = "light_green_900", Color = ColorTranslator.FromHtml("#33691e") };
        public static MaterialIconColor LightGreenA100 = new MaterialIconColor() { Name = "light_green_A100", Color = ColorTranslator.FromHtml("#ccff90") };
        public static MaterialIconColor LightGreenA200 = new MaterialIconColor() { Name = "light_green_A200", Color = ColorTranslator.FromHtml("#b2ff59") };
        public static MaterialIconColor LightGreenA400 = new MaterialIconColor() { Name = "light_green_A400", Color = ColorTranslator.FromHtml("#76ff03") };
        public static MaterialIconColor LightGreenA700 = new MaterialIconColor() { Name = "light_green_A700", Color = ColorTranslator.FromHtml("#64dd17") };
        #endregion

        #region Lime
        public static MaterialIconColor Lime50 = new MaterialIconColor() { Name = "lime_50", Color = ColorTranslator.FromHtml("#f9fbe7") };
        public static MaterialIconColor Lime100 = new MaterialIconColor() { Name = "lime_100", Color = ColorTranslator.FromHtml("#f0f4c3") };
        public static MaterialIconColor Lime200 = new MaterialIconColor() { Name = "lime_200", Color = ColorTranslator.FromHtml("#e6ee9c") };
        public static MaterialIconColor Lime300 = new MaterialIconColor() { Name = "lime_300", Color = ColorTranslator.FromHtml("#dce775") };
        public static MaterialIconColor Lime400 = new MaterialIconColor() { Name = "lime_400", Color = ColorTranslator.FromHtml("#d4e157") };
        public static MaterialIconColor Lime500 = new MaterialIconColor() { Name = "lime_500", Color = ColorTranslator.FromHtml("#cddc39") };
        public static MaterialIconColor Lime600 = new MaterialIconColor() { Name = "lime_600", Color = ColorTranslator.FromHtml("#c0ca33") };
        public static MaterialIconColor Lime700 = new MaterialIconColor() { Name = "lime_700", Color = ColorTranslator.FromHtml("#afb42b") };
        public static MaterialIconColor Lime800 = new MaterialIconColor() { Name = "lime_800", Color = ColorTranslator.FromHtml("#9e9d24") };
        public static MaterialIconColor Lime900 = new MaterialIconColor() { Name = "lime_900", Color = ColorTranslator.FromHtml("#827717") };
        public static MaterialIconColor LimeA100 = new MaterialIconColor() { Name = "lime_A100", Color = ColorTranslator.FromHtml("#f4ff81") };
        public static MaterialIconColor LimeA200 = new MaterialIconColor() { Name = "lime_A200", Color = ColorTranslator.FromHtml("#eeff41") };
        public static MaterialIconColor LimeA400 = new MaterialIconColor() { Name = "lime_A400", Color = ColorTranslator.FromHtml("#c6ff00") };
        public static MaterialIconColor LimeA700 = new MaterialIconColor() { Name = "lime_A700", Color = ColorTranslator.FromHtml("#aeea00") };
        #endregion

        #region Orange
        public static MaterialIconColor Orange50 = new MaterialIconColor() { Name = "orange_50", Color = ColorTranslator.FromHtml("#fff3e0") };
        public static MaterialIconColor Orange100 = new MaterialIconColor() { Name = "orange_100", Color = ColorTranslator.FromHtml("#ffe0b2") };
        public static MaterialIconColor Orange200 = new MaterialIconColor() { Name = "orange_200", Color = ColorTranslator.FromHtml("#ffcc80") };
        public static MaterialIconColor Orange300 = new MaterialIconColor() { Name = "orange_300", Color = ColorTranslator.FromHtml("#ffb74d") };
        public static MaterialIconColor Orange400 = new MaterialIconColor() { Name = "orange_400", Color = ColorTranslator.FromHtml("#ffa726") };
        public static MaterialIconColor Orange500 = new MaterialIconColor() { Name = "orange_500", Color = ColorTranslator.FromHtml("#ff9800") };
        public static MaterialIconColor Orange600 = new MaterialIconColor() { Name = "orange_600", Color = ColorTranslator.FromHtml("#fb8c00") };
        public static MaterialIconColor Orange700 = new MaterialIconColor() { Name = "orange_700", Color = ColorTranslator.FromHtml("#f57c00") };
        public static MaterialIconColor Orange800 = new MaterialIconColor() { Name = "orange_800", Color = ColorTranslator.FromHtml("#ef6c00") };
        public static MaterialIconColor Orange900 = new MaterialIconColor() { Name = "orange_900", Color = ColorTranslator.FromHtml("#e65100") };
        public static MaterialIconColor OrangeA100 = new MaterialIconColor() { Name = "orange_A100", Color = ColorTranslator.FromHtml("#ffd180") };
        public static MaterialIconColor OrangeA200 = new MaterialIconColor() { Name = "orange_A200", Color = ColorTranslator.FromHtml("#ffab40") };
        public static MaterialIconColor OrangeA400 = new MaterialIconColor() { Name = "orange_A400", Color = ColorTranslator.FromHtml("#ff9100") };
        public static MaterialIconColor OrangeA700 = new MaterialIconColor() { Name = "orange_A700", Color = ColorTranslator.FromHtml("#ff6d00") };
        #endregion

        #region Pink
        public static MaterialIconColor Pink50 = new MaterialIconColor() { Name = "pink_50", Color = ColorTranslator.FromHtml("#fce4ec") };
        public static MaterialIconColor Pink100 = new MaterialIconColor() { Name = "pink_100", Color = ColorTranslator.FromHtml("#f8bbd0") };
        public static MaterialIconColor Pink200 = new MaterialIconColor() { Name = "pink_200", Color = ColorTranslator.FromHtml("#f48fb1") };
        public static MaterialIconColor Pink300 = new MaterialIconColor() { Name = "pink_300", Color = ColorTranslator.FromHtml("#f06292") };
        public static MaterialIconColor Pink400 = new MaterialIconColor() { Name = "pink_400", Color = ColorTranslator.FromHtml("#ec407a") };
        public static MaterialIconColor Pink500 = new MaterialIconColor() { Name = "pink_500", Color = ColorTranslator.FromHtml("#e91e63") };
        public static MaterialIconColor Pink600 = new MaterialIconColor() { Name = "pink_600", Color = ColorTranslator.FromHtml("#d81b60") };
        public static MaterialIconColor Pink700 = new MaterialIconColor() { Name = "pink_700", Color = ColorTranslator.FromHtml("#c2185b") };
        public static MaterialIconColor Pink800 = new MaterialIconColor() { Name = "pink_800", Color = ColorTranslator.FromHtml("#ad1457") };
        public static MaterialIconColor Pink900 = new MaterialIconColor() { Name = "pink_900", Color = ColorTranslator.FromHtml("#880e4f") };
        public static MaterialIconColor PinkA100 = new MaterialIconColor() { Name = "pink_A100", Color = ColorTranslator.FromHtml("#ff80ab") };
        public static MaterialIconColor PinkA200 = new MaterialIconColor() { Name = "pink_A200", Color = ColorTranslator.FromHtml("#ff4081") };
        public static MaterialIconColor PinkA400 = new MaterialIconColor() { Name = "pink_A400", Color = ColorTranslator.FromHtml("#f50057") };
        public static MaterialIconColor PinkA700 = new MaterialIconColor() { Name = "pink_A700", Color = ColorTranslator.FromHtml("#c51162") };
        #endregion

        #region Purple
        public static MaterialIconColor Purple50 = new MaterialIconColor() { Name = "purple_50", Color = ColorTranslator.FromHtml("#f3e5f5") };
        public static MaterialIconColor Purple100 = new MaterialIconColor() { Name = "purple_100", Color = ColorTranslator.FromHtml("#e1bee7") };
        public static MaterialIconColor Purple200 = new MaterialIconColor() { Name = "purple_200", Color = ColorTranslator.FromHtml("#ce93d8") };
        public static MaterialIconColor Purple300 = new MaterialIconColor() { Name = "purple_300", Color = ColorTranslator.FromHtml("#ba68c8") };
        public static MaterialIconColor Purple400 = new MaterialIconColor() { Name = "purple_400", Color = ColorTranslator.FromHtml("#ab47bc") };
        public static MaterialIconColor Purple500 = new MaterialIconColor() { Name = "purple_500", Color = ColorTranslator.FromHtml("#9c27b0") };
        public static MaterialIconColor Purple600 = new MaterialIconColor() { Name = "purple_600", Color = ColorTranslator.FromHtml("#8e24aa") };
        public static MaterialIconColor Purple700 = new MaterialIconColor() { Name = "purple_700", Color = ColorTranslator.FromHtml("#7b1fa2") };
        public static MaterialIconColor Purple800 = new MaterialIconColor() { Name = "purple_800", Color = ColorTranslator.FromHtml("#6a1b9a") };
        public static MaterialIconColor Purple900 = new MaterialIconColor() { Name = "purple_900", Color = ColorTranslator.FromHtml("#4a148c") };
        public static MaterialIconColor PurpleA100 = new MaterialIconColor() { Name = "purple_A100", Color = ColorTranslator.FromHtml("#ea80fc") };
        public static MaterialIconColor PurpleA200 = new MaterialIconColor() { Name = "purple_A200", Color = ColorTranslator.FromHtml("#e040fb") };
        public static MaterialIconColor PurpleA400 = new MaterialIconColor() { Name = "purple_A400", Color = ColorTranslator.FromHtml("#d500f9") };
        public static MaterialIconColor PurpleA700 = new MaterialIconColor() { Name = "purple_A700", Color = ColorTranslator.FromHtml("#aa00ff") };
        #endregion

        #region Red
        public static MaterialIconColor Red50 = new MaterialIconColor() { Name = "red_50", Color = ColorTranslator.FromHtml("#fde0dc") };
        public static MaterialIconColor Red100 = new MaterialIconColor() { Name = "red_100", Color = ColorTranslator.FromHtml("#f9bdbb") };
        public static MaterialIconColor Red200 = new MaterialIconColor() { Name = "red_200", Color = ColorTranslator.FromHtml("#f69988") };
        public static MaterialIconColor Red300 = new MaterialIconColor() { Name = "red_300", Color = ColorTranslator.FromHtml("#f36c60") };
        public static MaterialIconColor Red400 = new MaterialIconColor() { Name = "red_400", Color = ColorTranslator.FromHtml("#e84e40") };
        public static MaterialIconColor Red500 = new MaterialIconColor() { Name = "red_500", Color = ColorTranslator.FromHtml("#e51c23") };
        public static MaterialIconColor Red600 = new MaterialIconColor() { Name = "red_600", Color = ColorTranslator.FromHtml("#dd191d") };
        public static MaterialIconColor Red700 = new MaterialIconColor() { Name = "red_700", Color = ColorTranslator.FromHtml("#d01716") };
        public static MaterialIconColor Red800 = new MaterialIconColor() { Name = "red_800", Color = ColorTranslator.FromHtml("#c41411") };
        public static MaterialIconColor Red900 = new MaterialIconColor() { Name = "red_900", Color = ColorTranslator.FromHtml("#b0120a") };
        public static MaterialIconColor RedA100 = new MaterialIconColor() { Name = "red_A100", Color = ColorTranslator.FromHtml("#ff7997") };
        public static MaterialIconColor RedA200 = new MaterialIconColor() { Name = "red_A200", Color = ColorTranslator.FromHtml("#ff5177") };
        public static MaterialIconColor RedA400 = new MaterialIconColor() { Name = "red_A400", Color = ColorTranslator.FromHtml("#ff2d6f") };
        public static MaterialIconColor RedA700 = new MaterialIconColor() { Name = "red_A700", Color = ColorTranslator.FromHtml("#e00032") };
        #endregion

        #region Teal
        public static MaterialIconColor Teal50 = new MaterialIconColor() { Name = "teal_50", Color = ColorTranslator.FromHtml("#e0f2f1") };
        public static MaterialIconColor Teal100 = new MaterialIconColor() { Name = "teal_100", Color = ColorTranslator.FromHtml("#b2dfdb") };
        public static MaterialIconColor Teal200 = new MaterialIconColor() { Name = "teal_200", Color = ColorTranslator.FromHtml("#80cbc4") };
        public static MaterialIconColor Teal300 = new MaterialIconColor() { Name = "teal_300", Color = ColorTranslator.FromHtml("#4db6ac") };
        public static MaterialIconColor Teal400 = new MaterialIconColor() { Name = "teal_400", Color = ColorTranslator.FromHtml("#26a69a") };
        public static MaterialIconColor Teal500 = new MaterialIconColor() { Name = "teal_500", Color = ColorTranslator.FromHtml("#9688") };
        public static MaterialIconColor Teal600 = new MaterialIconColor() { Name = "teal_600", Color = ColorTranslator.FromHtml("#00897b") };
        public static MaterialIconColor Teal700 = new MaterialIconColor() { Name = "teal_700", Color = ColorTranslator.FromHtml("#00796b") };
        public static MaterialIconColor Teal800 = new MaterialIconColor() { Name = "teal_800", Color = ColorTranslator.FromHtml("#00695c") };
        public static MaterialIconColor Teal900 = new MaterialIconColor() { Name = "teal_900", Color = ColorTranslator.FromHtml("#004d40") };
        public static MaterialIconColor TealA100 = new MaterialIconColor() { Name = "teal_A100", Color = ColorTranslator.FromHtml("#a7ffeb") };
        public static MaterialIconColor TealA200 = new MaterialIconColor() { Name = "teal_A200", Color = ColorTranslator.FromHtml("#64ffda") };
        public static MaterialIconColor TealA400 = new MaterialIconColor() { Name = "teal_A400", Color = ColorTranslator.FromHtml("#1de9b6") };
        public static MaterialIconColor TealA700 = new MaterialIconColor() { Name = "teal_A700", Color = ColorTranslator.FromHtml("#00bfa5") };
        #endregion

        #region Yellow
        public static MaterialIconColor Yellow50 = new MaterialIconColor() { Name = "yellow_50", Color = ColorTranslator.FromHtml("#fffde7") };
        public static MaterialIconColor Yellow100 = new MaterialIconColor() { Name = "yellow_100", Color = ColorTranslator.FromHtml("#fff9c4") };
        public static MaterialIconColor Yellow200 = new MaterialIconColor() { Name = "yellow_200", Color = ColorTranslator.FromHtml("#fff59d") };
        public static MaterialIconColor Yellow300 = new MaterialIconColor() { Name = "yellow_300", Color = ColorTranslator.FromHtml("#fff176") };
        public static MaterialIconColor Yellow400 = new MaterialIconColor() { Name = "yellow_400", Color = ColorTranslator.FromHtml("#ffee58") };
        public static MaterialIconColor Yellow500 = new MaterialIconColor() { Name = "yellow_500", Color = ColorTranslator.FromHtml("#ffeb3b") };
        public static MaterialIconColor Yellow600 = new MaterialIconColor() { Name = "yellow_600", Color = ColorTranslator.FromHtml("#fdd835") };
        public static MaterialIconColor Yellow700 = new MaterialIconColor() { Name = "yellow_700", Color = ColorTranslator.FromHtml("#fbc02d") };
        public static MaterialIconColor Yellow800 = new MaterialIconColor() { Name = "yellow_800", Color = ColorTranslator.FromHtml("#f9a825") };
        public static MaterialIconColor Yellow900 = new MaterialIconColor() { Name = "yellow_900", Color = ColorTranslator.FromHtml("#f57f17") };
        public static MaterialIconColor YellowA100 = new MaterialIconColor() { Name = "yellow_A100", Color = ColorTranslator.FromHtml("#ffff8d") };
        public static MaterialIconColor YellowA200 = new MaterialIconColor() { Name = "yellow_A200", Color = ColorTranslator.FromHtml("#ffff00") };
        public static MaterialIconColor YellowA400 = new MaterialIconColor() { Name = "yellow_A400", Color = ColorTranslator.FromHtml("#ffea00") };
        public static MaterialIconColor YellowA700 = new MaterialIconColor() { Name = "yellow_A700", Color = ColorTranslator.FromHtml("#ffd600") };
        #endregion

        public static List<MaterialIconColor> Get()
        {
            return new List<MaterialIconColor>()
            {
                #region Black & White
                White,
                Black,
                #endregion

                #region Custom
                BlueDark,
                BlueLight,
                GreenDark,
                GreenLight,
                PurpleDark,
                PurpleLight,
                RedDark,
                RedLight,
                YellowDark,
                YellowLight,
                #endregion

                #region Amber
                Amber50,
                Amber100,
                Amber200,
                Amber300,
                Amber400,
                Amber500,
                Amber600,
                Amber700,
                Amber800,
                Amber900,
                AmberA100,
                AmberA200,
                AmberA400,
                AmberA700,
                #endregion

                #region Blue
                Blue50,
                Blue100,
                Blue200,
                Blue300,
                Blue400,
                Blue500,
                Blue600,
                Blue700,
                Blue800,
                Blue900,
                BlueA100,
                BlueA200,
                BlueA400,
                BlueA700,
                #endregion
                
                #region Blue Gray
                BlueGrey50,
                BlueGrey100,
                BlueGrey200,
                BlueGrey300,
                BlueGrey400,
                BlueGrey500,
                BlueGrey600,
                BlueGrey700,
                BlueGrey800,
                BlueGrey900,
                #endregion
                
                #region Brown
                Brown50,
                Brown100,
                Brown200,
                Brown300,
                Brown400,
                Brown500,
                Brown600,
                Brown700,
                Brown800,
                Brown900,
                #endregion
                
                #region Cyan
                Cyan50,
                Cyan100,
                Cyan200,
                Cyan300,
                Cyan400,
                Cyan500,
                Cyan600,
                Cyan700,
                Cyan800,
                Cyan900,
                CyanA100,
                CyanA200,
                CyanA400,
                CyanA700,
                #endregion
                
                #region Dark Purple
                DarkPurple50,
                DarkPurple100,
                DarkPurple200,
                DarkPurple300,
                DarkPurple400,
                DarkPurple500,
                DarkPurple600,
                DarkPurple700,
                DarkPurple800,
                DarkPurple900,
                DarkPurpleA100,
                DarkPurpleA200,
                DarkPurpleA400,
                DarkPurpleA700,
                #endregion
                
                #region Deep Orange
                DeepOrange50,
                DeepOrange100,
                DeepOrange200,
                DeepOrange300,
                DeepOrange400,
                DeepOrange500,
                DeepOrange600,
                DeepOrange700,
                DeepOrange800,
                DeepOrange900,
                DeepOrangeA100,
                DeepOrangeA200,
                DeepOrangeA400,
                DeepOrangeA700,
                #endregion
                
                #region Green
                Green50,
                Green100,
                Green200,
                Green300,
                Green400,
                Green500,
                Green600,
                Green700,
                Green800,
                Green900,
                GreenA100,
                GreenA200,
                GreenA400,
                GreenA700,
                #endregion
                
                #region Grey
                Grey50,
                Grey100,
                Grey200,
                Grey300,
                Grey400,
                Grey500,
                Grey600,
                Grey700,
                Grey800,
                Grey900,
                GreyBlack1000,
                GreyWhite1000,
                #endregion
                
                #region Indigo
                Indigo50,
                Indigo100,
                Indigo200,
                Indigo300,
                Indigo400,
                Indigo500,
                Indigo600,
                Indigo700,
                Indigo800,
                Indigo900,
                IndigoA100,
                IndigoA200,
                IndigoA400,
                IndigoA700,
                #endregion
                
                #region Light Blue
                LightBlue50,
                LightBlue100,
                LightBlue200,
                LightBlue300,
                LightBlue400,
                LightBlue500,
                LightBlue600,
                LightBlue700,
                LightBlue800,
                LightBlue900,
                LightBlueA100,
                LightBlueA200,
                LightBlueA400,
                LightBlueA700,
                #endregion
                
                #region Light Green
                LightGreen50,
                LightGreen100,
                LightGreen200,
                LightGreen300,
                LightGreen400,
                LightGreen500,
                LightGreen600,
                LightGreen700,
                LightGreen800,
                LightGreen900,
                LightGreenA100,
                LightGreenA200,
                LightGreenA400,
                LightGreenA700,
                #endregion

                #region Lime
                Lime50,
                Lime100,
                Lime200,
                Lime300,
                Lime400,
                Lime500,
                Lime600,
                Lime700,
                Lime800,
                Lime900,
                LimeA100,
                LimeA200,
                LimeA400,
                LimeA700,
                #endregion
                
                #region Orange
                Orange50,
                Orange100,
                Orange200,
                Orange300,
                Orange400,
                Orange500,
                Orange600,
                Orange700,
                Orange800,
                Orange900,
                OrangeA100,
                OrangeA200,
                OrangeA400,
                OrangeA700,
                #endregion
                
                #region Pink
                Pink50,
                Pink100,
                Pink200,
                Pink300,
                Pink400,
                Pink500,
                Pink600,
                Pink700,
                Pink800,
                Pink900,
                PinkA100,
                PinkA200,
                PinkA400,
                PinkA700,
                #endregion
                
                #region Purple
                Purple50,
                Purple100,
                Purple200,
                Purple300,
                Purple400,
                Purple500,
                Purple600,
                Purple700,
                Purple800,
                Purple900,
                PurpleA100,
                PurpleA200,
                PurpleA400,
                PurpleA700,
                #endregion
                
                #region Red
                Red50,
                Red100,
                Red200,
                Red300,
                Red400,
                Red500,
                Red600,
                Red700,
                Red800,
                Red900,
                RedA100,
                RedA200,
                RedA400,
                RedA700,
                #endregion
                
                #region Teal
                Teal50,
                Teal100,
                Teal200,
                Teal300,
                Teal400,
                Teal500,
                Teal600,
                Teal700,
                Teal800,
                Teal900,
                TealA100,
                TealA200,
                TealA400,
                TealA700,
                #endregion
                
                #region Yellow
                Yellow50,
                Yellow100,
                Yellow200,
                Yellow300,
                Yellow400,
                Yellow500,
                Yellow600,
                Yellow700,
                Yellow800,
                Yellow900,
                YellowA100,
                YellowA200,
                YellowA400,
                YellowA700
                #endregion
            };
        }
    }
}