//------------------------------------------------------------------------------
// <copyright file="AddIconCommand.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel.Design;
using GalaSoft.MvvmLight.Ioc;
using MaterialIconsGenerator.Core;
using MaterialIconsGenerator.ProjectManagers;
using MaterialIconsGenerator.Providers.Google;
using MaterialIconsGenerator.VS;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace MaterialIconsGenerator
{
    /// <summary>
    /// Command handler
    /// </summary>
    internal sealed class AddIconCommand
    {
        /// <summary>
        /// Command ID.
        /// </summary>
        public const int CommandId = 0x0100;

        /// <summary>
        /// Command menu group (command set GUID).
        /// </summary>
        public static readonly Guid CommandSet = new Guid("4bc78819-cb1b-4120-8dd9-69aea2953600");

        /// <summary>
        /// VS Package that provides this command, not null.
        /// </summary>
        private readonly Package package;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddIconCommand"/> class.
        /// Adds our command handlers for menu (commands must exist in the command table file)
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        private AddIconCommand(Package package)
        {
            if (package == null)
                throw new ArgumentNullException("package");

            this.package = package;
            ServiceLocator.InitializePackageServiceProvider(this.package);

            var commandService = ServiceLocator.GetGlobalService<IMenuCommandService, OleMenuCommandService>();
            if (commandService != null)
            {
                var menuCommandID = new CommandID(CommandSet, CommandId);
                var menuItem = new MenuCommand(this.MenuItemCallback, menuCommandID);
                commandService.AddCommand(menuItem);
            }
        }

        /// <summary>
        /// Gets the instance of the command.
        /// </summary>
        public static AddIconCommand Instance
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the service provider from the owner package.
        /// </summary>
        public IServiceProvider ServiceProvider
        {
            get
            {
                return this.package;
            }
        }

        /// <summary>
        /// Initializes the singleton instance of the command.
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        public static void Initialize(Package package)
        {
            Instance = new AddIconCommand(package);
        }

        /// <summary>
        /// This function is the callback used to execute the command when the menu item is clicked.
        /// See the constructor to see how the menu item is associated with this function using
        /// OleMenuCommandService service and MenuCommand class.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event args.</param>
        private void MenuItemCallback(object sender, EventArgs e)
        {
            var project = Project.GetActiveProject();
            var projectType = project.GetProjectType();
            if (projectType != ProjectType.XamarinAndroid)
            {
                VsShellUtilities.ShowMessageBox(
                    this.ServiceProvider,
                    "Extension currently works for Xamarin.Android projects",
                    Vsix.Name,
                    OLEMSGICON.OLEMSGICON_INFO,
                    OLEMSGBUTTON.OLEMSGBUTTON_OK,
                    OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
                return;
            }

            this.SetupIOC(projectType);

            new Views.MainWindow().ShowDialog();
        }

        private void SetupIOC(ProjectType projectType)
        {
            // cleanup ioc
            SimpleIoc.Default.Unregister<IIconProvider>();
            SimpleIoc.Default.Unregister<IProjectManager>();
            // register ioc
            if (projectType == ProjectType.XamarinAndroid)
            {
                SimpleIoc.Default.Register<IIconProvider, GoogleAndroidIconsProvider>();
                SimpleIoc.Default.Register<IProjectManager, AndroidProjectManager>();
            }
            else if (projectType == ProjectType.XamariniOS)
            {
                SimpleIoc.Default.Register<IIconProvider, GoogleiOSIconsProvider>();
                SimpleIoc.Default.Register<IProjectManager, iOSProjectManager>();
            }
        }
    }
}
