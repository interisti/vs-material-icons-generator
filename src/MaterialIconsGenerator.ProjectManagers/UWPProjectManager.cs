using System.IO;
using System.Threading.Tasks;
using MaterialIconsGenerator.Core;
using MaterialIconsGenerator.Core.Utils;

namespace MaterialIconsGenerator.ProjectManagers
{
    public class UWPProjectManager : IProjectManager
    {
        public async Task AddIcon(IProject project, IProjectIcon icon)
        {
            // download icon
            var data = await icon.Get();
            // save file
            var root = project.GetRootDirectory();
            var filename = $"{icon.FullName}.png";
            var filepath = Path.Combine(root, filename);
            FileUtils.WriteAllBytes(data, filepath);
            // add to project
            project.AddFile(filepath, "Content");
            // save
            project.Save();
        }
    }
}
