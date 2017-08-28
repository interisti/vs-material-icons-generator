using System.IO;
using System.Linq;
using EnvDTE;
using MaterialIconsGenerator.Core;
using Microsoft.VisualStudio.Shell.Flavor;
using Microsoft.VisualStudio.Shell.Interop;

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

        public ProjectType GetProjectType()
        {
            var solution = ServiceLocator.GetGlobalService<SVsSolution, IVsSolution>();
            if (solution == null) return ProjectType.Other;

            solution.GetProjectOfUniqueName(this._vsProject.UniqueName, out IVsHierarchy hierarchy);
            if (hierarchy == null) return ProjectType.Other;

            var ap = hierarchy as IVsAggregatableProjectCorrected;
            if (ap == null) return ProjectType.Other;

            ap.GetAggregateProjectTypeGuids(out string projectTypeGuids);
            if (string.IsNullOrEmpty(projectTypeGuids)) return ProjectType.Other;

            // check if xamarin project
            if (!projectTypeGuids.Contains("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}")) return ProjectType.Other;
            // check if android project
            if (projectTypeGuids.Contains("{EFBA0AD7-5A72-4C68-AF49-83D382785DCF}")) return ProjectType.XamarinAndroid;
            // check if ios project
            if (projectTypeGuids.Contains("{FEACFBD2-3405-455C-9665-78FE426C6842}")) return ProjectType.XamariniOS;

            return ProjectType.Other;
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
