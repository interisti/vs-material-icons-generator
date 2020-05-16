using System.Collections.Generic;
using MaterialIconsGenerator.Core;

namespace MaterialIconsGenerator.Providers.Google
{
    public class GoogleIconTheme : IIconTheme
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public static IList<IIconTheme> _themes = new List<IIconTheme>()
        {
            new GoogleIconTheme{ Id = "material-icons", Name ="Material Icons" },
            new GoogleIconTheme{ Id = "material-icons-outlined", Name ="Material Icons Outlined" },
            new GoogleIconTheme{ Id = "material-icons-round", Name ="Material Icons Round" },
            new GoogleIconTheme{ Id = "material-icons-sharp", Name ="Material Icons Sharp" },
            new GoogleIconTheme{ Id = "material-icons-two-tone", Name ="Material Icons Two Tone" }
        };
        public static IList<IIconTheme> Get() => _themes;
    }
}
