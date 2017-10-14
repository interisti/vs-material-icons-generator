using System.Threading.Tasks;

namespace MaterialIconsGenerator.Core
{
    public interface IProjectManager
    {
        Task AddIcon(IProject project, IProjectIcon icon, string name);
    }
}
