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

        IEnumerable<IIconTheme> GetThemes();

        Task<IEnumerable<IIcon>> Get();

        IProjectIcon CreateProjectIcon(IIcon icon, IIconTheme theme, IIconColor color, ISize size, string density);
    }
}
