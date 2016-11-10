using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;

namespace VSMaterialIcons.Models
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
            var url = "https://material.io/icons/data/grid.json";
            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync(url);
                var json = JObject.Parse(response);

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
}
