using System.Threading.Tasks;
using MaterialIconsGenerator.Core;
using MaterialIconsGenerator.Core.Utils;
using RestSharp;

namespace MaterialIconsGenerator.Providers.Google
{
    public class GoogleProjectIcon : IProjectIcon
    {
        public GoogleProjectIcon(IIcon icon, IIconColor color, string size, string density)
        {
            this.Id = icon.Id;
            this.Name = icon.Name;
            this.Category = icon.Category;
            this.Color = color;
            this.Size = size;
            this.Density = density;
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public IIconCategory Category { get; set; }

        public IIconColor Color { get; set; }

        public string Size { get; set; }

        public string Density { get; set; }

        public string FullName => $"{this.Name}_{this.Color.Name}_{this.Density}";

        public async Task<byte[]> Download()
        {
            var client = new RestClient("https://raw.githubusercontent.com");
            var request = new RestRequest(this.GenerateUrl(), Method.GET);
            request.AddHeader("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.71 Safari/537.36");
            request.AddHeader("cache-control", "max-age=0");
            var response = await client.ExecuteTaskAsync(request);

            return this.Tint(response.RawBytes);
        }

        private byte[] Tint(byte[] data)
        {
            if (this.Color.Color == System.Drawing.Color.White ||
                this.Color.Color == System.Drawing.Color.Black)
            {
                return data;
            }

            return ColorUtils.Tint(data, this.Color.Color);
        }

        private string GenerateUrl()
        {
            var downloadColor = this.Color.Color == System.Drawing.Color.White ? "white" : "black";

            return $"/google/material-design-icons/master/{this.Category.Id}/drawable-{this.Density}/{this.Id}_{downloadColor}_{this.Size}.png";
        }
    }
}
