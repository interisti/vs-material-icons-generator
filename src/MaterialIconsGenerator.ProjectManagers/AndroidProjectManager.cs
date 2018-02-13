using System.IO;
using System.Threading.Tasks;
using MaterialIconsGenerator.Core;
using MaterialIconsGenerator.Core.Utils;

namespace MaterialIconsGenerator.ProjectManagers
{
    public class AndroidProjectManager : IProjectManager
    {
        public const string RESOURCES_FOLDER = "Resources";

        public async Task AddIcon(IProject project, IProjectIcon icon, string name)
        {
            // download icon
            var data = await icon.Get();
            // TEMP solution to https://github.com/interisti/vs-material-icons-generator/issues/17
            if (data == null)
            {
                return;
            }
            // save file
            var filepath = this.GetFilePath(project, icon, name);
            FileUtils.WriteAllBytes(data, filepath);
            // add to project
            project.AddFile(filepath, "AndroidResource");
            // save
            project.Save();
        }

        private string GetFilePath(IProject project, IProjectIcon icon, string name)
        {
            var root = project.GetRootDirectory();
            return (icon.Density == "drawable" || icon.Density == "drawable-v21")
                ? Path.Combine(root, RESOURCES_FOLDER, icon.Density, $"{name}.xml")
                : Path.Combine(root, RESOURCES_FOLDER, $"drawable-{icon.Density}", $"{name}.png");
        }
    }
}
