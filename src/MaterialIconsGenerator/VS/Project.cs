using System.IO;
using System.Linq;
using EnvDTE;
using MaterialIconsGenerator.Core;

namespace MaterialIconsGenerator.VS
{
    public class Project : IProject
    {
        private EnvDTE.Project _vsProject;

        public Project(EnvDTE.Project project)
        {
            this._vsProject = project;
        }

        public string GetRootDirectory()
        {
            return Path.GetDirectoryName(this._vsProject.FileName);
        }

        public void AddFile(string filename, string type)
        {
            var file = this._vsProject.ProjectItems.AddFromFile(filename);
            file.Properties.Item("ItemType").Value = type;
        }

        public void Save()
        {
            this._vsProject.Save();
        }


        public static Project GetActiveProject()
        {
            var dteService = ServiceLocator.GetGlobalService<DTE, DTE>();
            var vsProject = ((object[])dteService.ActiveSolutionProjects)
                .Select(x => (EnvDTE.Project)x)
                .FirstOrDefault();

            return vsProject == null ? null : new Project(vsProject);
        }
    }
}
