using System.Collections.Generic;
using System.Threading.Tasks;

namespace MaterialIconsGenerator.Core
{
    public interface IIconProvider
    {
        string Name { get; }

        string Reference { get; }

        IEnumerable<ISize> GetSizes();

        IEnumerable<string> GetDensities();

        Task<IEnumerable<IIcon>> Get();

        IProjectIcon CreateProjectIcon(IIcon icon, IIconColor color, ISize size, string density);
    }
}
