using System.Threading.Tasks;
using MaterialIconsGenerator.Core;
using MaterialIconsGenerator.Core.Utils;
using RestSharp;

namespace MaterialIconsGenerator.Providers.Google
{
    public abstract class GoogleProjectIcon : IProjectIcon
    {
        public GoogleProjectIcon(IIcon icon, IIconColor color, string size, string density)
        {
            this.Icon = icon;
            this.Color = color;
            this.Size = size;
            this.Density = density;
        }

        public IIcon Icon { get; }

        public IIconColor Color { get; set; }

        public string Size { get; set; }

        public string Density { get; set; }

        public abstract string FullName { get; }

        public async Task<byte[]> Get()
        {
            var client = new RestClient("https://raw.githubusercontent.com");
            var request = new RestRequest(this.GenerateUrl(), Method.GET);
            request.AddHeader("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.71 Safari/537.36");
            request.AddHeader("cache-control", "max-age=0");
            var response = await client.ExecuteTaskAsync(request);

            return this.Tint(response.RawBytes);
        }

        protected byte[] Tint(byte[] data)
        {
            if (this.Color.Color == System.Drawing.Color.White ||
                this.Color.Color == System.Drawing.Color.Black)
            {
                return data;
            }

            return ColorUtils.Tint(data, this.Color.Color);
        }

        protected abstract string GenerateUrl();
    }
}
