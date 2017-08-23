using System.Collections.Generic;
using System.Threading.Tasks;

namespace MaterialIconsGenerator.Core
{
    public interface IIconProvider
    {
        string Name { get; }

        string Reference { get; }

        bool IsAndroidSupported { get; }

        bool IsiOSSupported { get; }

        IEnumerable<string> GetAndroidSizes();

        IEnumerable<string> GetiOSSizes();

        IEnumerable<string> GetAndroidDensities();

        IEnumerable<string> GetiOSDensities();

        Task<IEnumerable<IIcon>> Get();

        IProjectIcon CreateProjectIcon(IIcon icon, IIconColor color, string size, string density);
    }
}
