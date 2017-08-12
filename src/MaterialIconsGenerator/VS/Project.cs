using EnvDTE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialIconsGenerator.VS
{
    public class Project
    {
        public static EnvDTE.Project GetActiveProject()
        {
            var dteService = ServiceLocator.GetGlobalService<DTE, DTE>();
            return ((object[])dteService.ActiveSolutionProjects)
                .Select(x => (EnvDTE.Project)x)
                .FirstOrDefault();
        }

        public static string GetProjectDirectory(EnvDTE.Project project)
        {
            return Path.GetDirectoryName(project.FileName);
        }

        public static void AddFileToProject(EnvDTE.Project project,
            string filename, string type)
        {
            var file = project.ProjectItems.AddFromFile(filename);
            file.Properties.Item("ItemType").Value = type;
        }
    }
}
