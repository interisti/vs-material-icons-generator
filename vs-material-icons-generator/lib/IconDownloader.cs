using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace VSMaterialIcons
{
    public static class IconDownloader
    {
        public static string GetIconUrl(string iconFull, string folder, string color, string size)
        {
            const string urlFormat = "https://raw.githubusercontent.com/google/material-design-icons/master/{0}/{1}/{2}_{3}_{4}.png";

            var iconFullArr = iconFull.Split('/');
            var icon = iconFullArr[1];
            var category = iconFullArr[0];

            var url = string.Format(urlFormat,
                          category.ToLower(),
                          folder.ToLower(),
                          icon.ToLower(),
                          color.ToLower().Replace(" ", ""),
                          size.ToLower()
                      );
            return url;
        }

        public static byte[] DownloadIcon(string icon, string folder, string color, string size)
        {
            using (var webCl = new System.Net.WebClient())
            {
                return webCl.DownloadData(GetIconUrl(icon,
                    folder,
                    IconColors.FixColor(IconColors.NormalizeColor(color)),
                    size));
            }
        }

        public static List<string> KnownSizes = new List<string>() {
            "18dp",
            "24dp",
            "36dp",
            "48dp"
        };

        public static List<string> DownloadIconsFromRepo()
        {
            var result = new List<string>();
            using (var client = new System.Net.WebClient())
            {
                var response = client.DownloadString("https://design.google.com/icons/data/grid.json");
                var json_data = JObject.Parse(response);

                foreach (var icon in json_data.Property("icons").Values())
                {
                    var normalized_name = icon.Value<string>("group_id") + "/" +
                                          icon.Value<string>("id");

                    result.Add(normalized_name);
                }
            }
            // sort
            result.Sort();

            return result;
        }

        //			"action/ic_3d_rotation",
    }
}

