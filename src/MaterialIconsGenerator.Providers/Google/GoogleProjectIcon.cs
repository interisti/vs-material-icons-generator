using System.Threading.Tasks;
using MaterialIconsGenerator.Core;
using MaterialIconsGenerator.Core.Utils;
using RestSharp;

namespace MaterialIconsGenerator.Providers.Google
{
    public abstract class GoogleProjectIcon : IProjectIcon
    {
        public GoogleProjectIcon(IIcon icon, IIconTheme theme, IIconColor color, ISize size, string density)
        {
            this.Icon = icon;
            this.Color = color;
            this.Theme = theme;
            this.Size = size;
            this.Density = density;
        }

        public IIcon Icon { get; }

        public IIconColor Color { get; set; }

        public IIconTheme Theme { get; set; }

        public ISize Size { get; set; }

        public string Density { get; set; }

        public virtual bool IsVector => false;

        public virtual string FullName =>
            $"ic_{this.Icon.Id}_{this.Color.Name}_{this.Size.Name}";


        public virtual async Task<byte[]> Get()
        {
            var response = await this.Download(this.GenerateUrl());

            return this.Tint(response);
        }

        protected async Task<byte[]> Download(string resource)
        {
            var client = new RestClient("https://www.vs-material-icons-generator.com");
            client.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.CacheIfAvailable);
            var request = new RestRequest(resource, Method.GET);
            request.AddHeader("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.71 Safari/537.36");
            var response = await client.ExecuteAsync(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return null;
            }

            return response.RawBytes;
        }

        protected byte[] Tint(byte[] data)
        {
            if (data == null)
            {
                return data;
            }

            if (this.Color.Color == System.Drawing.Color.Black)
            {
                return data;
            }

            return ColorUtils.Tint(data, this.Color.Color);
        }

        protected abstract string GenerateUrl();
    }
}
