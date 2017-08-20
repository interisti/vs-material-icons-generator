using System.Threading.Tasks;

namespace MaterialIconsGenerator.Core
{
    public interface IProjectManager
    {
        Task Addicon(IProjectIcon icon);
    }
}
