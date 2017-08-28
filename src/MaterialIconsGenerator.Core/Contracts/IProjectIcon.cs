using System.Threading.Tasks;

namespace MaterialIconsGenerator.Core
{
    public interface IProjectIcon
    {
        IIcon Icon { get; }

        string FullName { get; }

        IIconColor Color { get; set; }

        string Size { get; set; }

        string Density { get; set; }


        Task<byte[]> Get();
    }
}
