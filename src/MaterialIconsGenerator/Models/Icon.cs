using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace MaterialIconsGenerator.Models
{
    public class Icon
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public Group Group { get; set; }

        public List<string> Keywords { get; set; } = new List<string>();

        public string KeywordsString
        {
            get { return string.Join(", ", this.Keywords); }
        }

        public bool IsNew { get; set; }

        public override string ToString()
        {
            return this.Name;
        }



        public static async Task<List<Icon>> GetIconsAsync()
        {
            var client = new RestClient("https://material.io");
            var request = new RestRequest("/icons/data/grid.json", Method.GET);
            request.AddHeader("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.71 Safari/537.36");
            request.AddHeader("cache-control", "max-age=0");
            var response = await client.ExecuteTaskAsync(request);
            var json = JObject.Parse(response.Content);

            var groups = json["groups"].Select(item => new Group()
            {
                Id = item["data"]["id"].Value<string>(),
                Name = item["data"]["name"].Value<string>(),
                Length = item["length"].Value<int>()
            }).ToList();

            return json["icons"].Select(item => new Icon()
            {
                Id = item["id"].Value<string>(),
                Name = item["name"].Value<string>(),
                Group = groups.FirstOrDefault(x => x.Id == item["group_id"].Value<string>()),
                Keywords = item["keywords"].Values<string>().ToList(),
                IsNew = item["is_new"].Value<bool>()
            }).ToList();
        }
    }
}
