using System.Collections.Generic;
using System.Threading.Tasks;

namespace MaterialIconsGenerator.Core
{
    public interface IIconProvider
    {
        string Name { get; }

        string Reference { get; }

        IEnumerable<string> GetSizes();

        IEnumerable<string> GetDensities();

        Task<IEnumerable<IIcon>> Get();

        IProjectIcon CreateProjectIcon(IIcon icon, IIconColor color, string size, string density);
    }
}
