using System.Threading.Tasks;

namespace MaterialIconsGenerator.Core
{
    public interface IProjectIcon
    {
        IIcon Icon { get; }

        string FullName { get; }

        IIconColor Color { get; set; }

        ISize Size { get; set; }

        IIconTheme Theme { get; set; }

        string Density { get; set; }

        bool IsVector { get; }


        Task<byte[]> Get();
    }
}
