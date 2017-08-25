using System.Threading.Tasks;

namespace MaterialIconsGenerator.Core
{
    public interface IProjectIcon
    {
        IIcon Icon { get; }

        string FullName { get; }

        IIconColor Color { get; }

        string Size { get; }

        string Density { get; }


        Task<byte[]> Download();
    }
}
