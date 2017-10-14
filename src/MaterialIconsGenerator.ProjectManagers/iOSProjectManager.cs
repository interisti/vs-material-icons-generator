using System.IO;
using System.Threading.Tasks;
using MaterialIconsGenerator.Core;
using MaterialIconsGenerator.Core.Utils;

namespace MaterialIconsGenerator.ProjectManagers
{
    public class iOSProjectManager : IProjectManager
    {
        public const string RESOURCES_FOLDER = "Resources";

        public async Task AddIcon(IProject project, IProjectIcon icon, string name)
        {
            // download icon
            var data = await icon.Get();
            // save file
            var root = project.GetRootDirectory();
            var filename = $"{name}@{icon.Density}.png".Replace("@1x", "");
            var filepath = Path.Combine(root, RESOURCES_FOLDER, filename);
            FileUtils.WriteAllBytes(data, filepath);
            // add to project
            project.AddFile(filepath, "BundleResource");
            // save
            project.Save();
        }
    }
}
