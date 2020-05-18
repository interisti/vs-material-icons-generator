using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
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
                client.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.CacheIfAvailable);
                var request = new RestRequest("/icon-providers/google/material-icons.json", Method.GET, DataFormat.Json);
                request.AddHeader("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.71 Safari/537.36");
                var response = await client.ExecuteAsync(request);
                var json = JObject.Parse(response.Content);

                return json["categories"]
                    .SelectMany(category =>
                    {
                        var iconCategory = new GoogleIconCategory()
                        {
                            Id = category["id"].Value<string>(),
                            Name = category["name"].Value<string>()
                        };

                        return category["icons"]
                            .Select(item => new GoogleIcon()
                            {
                                Id = item["id"].Value<string>(),
                                Name = item["name"].Value<string>(),
                                Category = iconCategory,
                                Keywords = item["keywords"].Values<string>(),
                                Provider = this
                            })
                            .ToList();
                    });
            }
            catch
            {
                return new List<IIcon>();
            }
        }

        public abstract IProjectIcon CreateProjectIcon(IIcon icon, IIconTheme theme, IIconColor color, ISize size, string density);
    }
}
