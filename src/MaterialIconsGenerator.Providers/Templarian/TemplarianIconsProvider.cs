using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaterialIconsGenerator.Core;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace MaterialIconsGenerator.Providers.Templarian
{
    public abstract class TemplarianIconsProvider : IIconProvider
    {
        public string Name
        {
            get { return "Material Design Icons from the Community"; }
        }

        public string Reference
        {
            get { return "https://materialdesignicons.com"; }
        }

        public abstract IEnumerable<string> GetSizes();

        public abstract IEnumerable<string> GetDensities();

        public async Task<IEnumerable<IIcon>> Get()
        {
            var client = new RestClient("https://raw.githubusercontent.com");
            var request = new RestRequest("/Templarian/MaterialDesign-SVG/master/meta.json", Method.GET);
            request.AddHeader("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.71 Safari/537.36");
            request.AddHeader("cache-control", "max-age=0");
            var response = await client.ExecuteTaskAsync(request);
            var json = JArray.Parse(response.Content);

            return json.Select(item => new TemplarianIcon()
            {
                Id = item["id"].Value<string>(),
                Name = item["name"].Value<string>(),
                Category = null,
                Keywords = item["tags"].Values<string>().ToList(),
                Author = item["author"].Value<string>(),
                Badge = "community",
                Provider = this
            })
            .Where(x => x.Author != "Google")
            .ToList();
        }

        public abstract IProjectIcon CreateProjectIcon(IIcon icon, IIconColor color, string size, string density);
    }
}
