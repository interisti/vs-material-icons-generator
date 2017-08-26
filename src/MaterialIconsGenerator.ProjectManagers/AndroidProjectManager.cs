using System.IO;
using System.Threading.Tasks;
using MaterialIconsGenerator.Core;
using MaterialIconsGenerator.Core.Utils;

namespace MaterialIconsGenerator.ProjectManagers
{
    public class AndroidProjectManager : IProjectManager
    {
        public const string RESOURCES_FOLDER = "Resources";

        public async Task AddIcon(IProject project, IProjectIcon icon)
        {
            // download icon
            var data = await icon.Get();

            var root = project.GetRootDirectory();
            var filepath = Path.Combine(root, RESOURCES_FOLDER,
                $"drawable-{icon.Density}", $"{icon.FullName}.png");
            // save file
            FileUtils.WriteAllBytes(data, filepath);
            // add to project
            project.AddFile(filepath, "AndroidResource");
            // save
            project.Save();
        }
    }
}
