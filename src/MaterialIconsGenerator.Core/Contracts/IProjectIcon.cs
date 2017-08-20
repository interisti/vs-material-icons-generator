using System.Threading.Tasks;

namespace MaterialIconsGenerator.Core
{
    public interface IProjectIcon
    {
        string Id { get; }

        string Name { get; }

        string FullName { get; }

        IIconCategory Category { get; }

        IIconColor Color { get; }

        string Size { get; }

        string Density { get; }


        Task<byte[]> Download();
    }
}
