using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaterialIconsGenerator.Core;

namespace MaterialIconsGenerator.Providers.Google
{
    public abstract class GoogleIconsProvider : IIconProvider
    {
        public string Name => "Google Material Icons";

        public string Reference => "https://material.io/resources/icons";

        public abstract IEnumerable<ISize> GetSizes();

        public abstract IEnumerable<string> GetDensities();

        public IEnumerable<IIconTheme> GetThemes() => GoogleIconTheme.Get();

        public async Task<IEnumerable<IIcon>> Get()
        {
            try
            {
                var client = new RestClient("https://www.vs-material-icons-generator.com");
                var request = new RestRequest("/icon-providers/google/material-icons.json", Method.GET, DataFormat.Json);
                request.AddHeader("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.71 Safari/537.36");
                var response = await client.ExecuteAsync(request);
                var json = SimpleJson.DeserializeObject<IconsJsonResponse>(response.Content);

                return json.categories
                    .SelectMany(category =>
                    {
                        var iconCategory = new GoogleIconCategory()
                        {
                            Id = category.id,
                            Name = category.name
                        };

                        return category.icons
                            .Select(item => new GoogleIcon()
                            {
                                Id = item.id,
                                Name = item.name,
                                Category = iconCategory,
                                Keywords = item.keywords,
                                Provider = this
                            })
                            .ToList();
                    })
                    .OrderBy(x => x.Name);
            }
            catch
            {
                return new List<IIcon>();
            }
        }

        public abstract IProjectIcon CreateProjectIcon(IIcon icon, IIconTheme theme, IIconColor color, ISize size, string density);
    }

    class IconsJsonResponse
    {
        public IEnumerable<IconsJsonCategory> categories { get; set; }
    }

    class IconsJsonCategory
    {
        public string id { get; set; }
        public string name { get; set; }

        public IEnumerable<IconsJsonIcon> icons { get; set; }
    }

    class IconsJsonIcon
    {
        public string id { get; set; }
        public string name { get; set; }

        public IEnumerable<string> keywords { get; set; }
    }
}
