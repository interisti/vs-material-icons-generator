using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaterialIconsGenerator.Core;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace MaterialIconsGenerator.Providers.Google
{
    public abstract class GoogleIconsProvider : IIconProvider
    {
        public string Name =>
            "Google Material Icons";

        public string Reference =>
            "https://github.com/google/material-design-icons";

        public abstract IEnumerable<ISize> GetSizes();

        public abstract IEnumerable<string> GetDensities();

        public async Task<IEnumerable<IIcon>> Get()
        {
            var client = new RestClient("https://material.io");
            var request = new RestRequest("/tools/icons/static/data.json", Method.GET);
            request.AddHeader("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.71 Safari/537.36");
            request.AddHeader("cache-control", "max-age=0");
            var response = await client.ExecuteTaskAsync(request);
            var json = JObject.Parse(response.Content);

            return json["categories"]
                .SelectMany(category =>
                {
                    var iconCategory = new GoogleIconCategory()
                    {
                        Id = category["name"].Value<string>(),
                        Name = category["name"].Value<string>()
                    };

                    return category["icons"]
                        .Select(item => new GoogleIcon()
                        {
                            Id = $"ic_{item["id"].Value<string>()}",
                            Name = item["id"].Value<string>(),
                            Category = iconCategory,
                            Keywords = new List<string>(),
                            Provider = this
                        })
                        .ToList();
                });
        }

        public abstract IProjectIcon CreateProjectIcon(IIcon icon, IIconColor color, ISize size, string density);
    }
}
