using EnvDTE;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace VSMaterialIcons
{
    public partial class MainForm : Form
    {
        private ProgressIndicator progressIndicator;

        public MainForm()
        {
            InitializeComponent();

            this.progressIndicator = new ProgressIndicator(AddIconCommand.Instance.StatusBar);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // start waiting
            this.progressIndicator.DisplayProgress("Downloading icons from repo ...");

            this.LoadIcons();
            this.LoadColors();
            this.LoadSizes();
            // stop waiting
            this.progressIndicator.ClearProgress();

            this.iconComboBox.SelectedIndexChanged += ConfigurationComboBox_SelectedIndexChanged;
            this.colorComboBox.SelectedIndexChanged += ConfigurationComboBox_SelectedIndexChanged;
            this.sizeComboBox.SelectedIndexChanged += ConfigurationComboBox_SelectedIndexChanged;
        }

        public string SelectedIcon { get { return (this.iconComboBox.SelectedItem ?? "").ToString(); } }

        public string SelectedColor { get { return (this.colorComboBox.SelectedItem ?? "").ToString(); } }

        public string SelectedSize { get { return (this.sizeComboBox.SelectedItem ?? "").ToString(); } }

        private void LoadIcons()
        {
            this.iconComboBox.DataSource = IconDownloader.DownloadIconsFromRepo();
            // clear initial selection
            this.iconComboBox.SelectedIndex = -1;
        }

        private void LoadColors()
        {
            this.colorComboBox.DataSource = IconColors.KnownColors.Concat(IconColors.Colors.Keys).ToList();
        }

        private void LoadSizes()
        {
            this.sizeComboBox.DataSource = IconDownloader.KnownSizes;
            // set selection to 24dp
            this.sizeComboBox.SelectedItem = IconDownloader.KnownSizes[1];
        }

        private void SetName()
        {
            var icon = this.SelectedIcon;
            if (string.IsNullOrEmpty(icon))
                return;
            var color = this.SelectedColor;
            var size = this.SelectedSize;
            var name = IconLocation.NormalizeFileName(icon, color, size);

            this.nameTextBox.Text = name;
        }

        private void SetPreview()
        {
            try
            {
                var icon = this.SelectedIcon;
                if (string.IsNullOrEmpty(icon))
                    return;
                // start waiting
                this.progressIndicator.DisplayProgress("Downloading icon ...");

                var color = this.SelectedColor;
                var size = this.SelectedSize;
                var data = IconDownloader.DownloadIcon(icon,
                               IconLocation.DRAWABLE_HDPI_FOLDER,
                               IconColors.FixColor(IconColors.NormalizeColor(color)),
                               size);
                if (!IconColors.IsKnownColor(color))
                    data = IconColors.ReplaceColor(data, IconColors.GetColor(color));
                this.previewPictureBox.Image = Image.FromStream(new MemoryStream(data));

                this.SetName();
                throw new Exception("test ex");
            }
            catch (Exception ex)
            {
                AddIconCommand.Instance.OutputPane.OutputString(ex.Message + Environment.NewLine);
                AddIconCommand.Instance.OutputPane.OutputString(ex.StackTrace + Environment.NewLine);
                AddIconCommand.Instance.OutputPane.Activate();
            }
            finally
            {
                // stop waiting
                this.progressIndicator.ClearProgress();
            }
        }

        private void StartDownloading()
        {
            try
            {
                var icon = this.SelectedIcon;
                if (string.IsNullOrEmpty(icon))
                    return;

                // start waiting
                this.progressIndicator.DisplayProgress("Downloading icons ...");

                var folders = new List<string>();
                if (this.hdpiCheckBox.Checked) folders.Add(IconLocation.DRAWABLE_HDPI_FOLDER);
                if (this.mdpiCheckBox.Checked) folders.Add(IconLocation.DRAWABLE_MDPI_FOLDER);
                if (this.xhdpiCheckBox.Checked) folders.Add(IconLocation.DRAWABLE_XHDPI_FOLDER);
                if (this.xxhdpiCheckBox.Checked) folders.Add(IconLocation.DRAWABLE_XXHDPI_FOLDER);
                if (this.xxxhdpiCheckBox.Checked) folders.Add(IconLocation.DRAWABLE_XXXHDPI_FOLDER);
                var color = this.SelectedColor;
                var size = this.SelectedSize;
                var name = this.nameTextBox.Text;
                if (string.IsNullOrEmpty(name))
                    name = IconLocation.NormalizeFileName(icon, color, size);

                foreach (var folder in folders)
                {
                    var data = IconDownloader.DownloadIcon(icon, folder,
                                   IconColors.FixColor(IconColors.NormalizeColor(color)), size);
                    if (!IconColors.IsKnownColor(color))
                        data = IconColors.ReplaceColor(data, IconColors.GetColor(color));
                    // save
                    var baseDir = this.GetProjectDir();
                    var fullPath = Path.Combine(baseDir, IconLocation.RESOURCES_FOLDER, folder,
                        name + IconLocation.ICON_EXTENSION);
                    // save to folder
                    IconLocation.SaveIcon(data, fullPath);
                    // add to project
                    this.AddFileToProject(fullPath);
                }

                this.SaveProject();
            }
            catch (Exception ex)
            {
                AddIconCommand.Instance.OutputPane.OutputString(ex.Message + Environment.NewLine);
                AddIconCommand.Instance.OutputPane.OutputString(ex.StackTrace + Environment.NewLine);
                AddIconCommand.Instance.OutputPane.Activate();
            }
            finally
            {
                // stop waiting
                this.progressIndicator.ClearProgress();
            }
        }

        private string GetProjectDir()
        {
            var project = this.GetActiveProject();

            return Path.GetDirectoryName(project.FileName);
        }

        private void AddFileToProject(string filename)
        {
            var project = this.GetActiveProject();

            var file = project.ProjectItems.AddFromFile(filename);
            file.Properties.Item("ItemType").Value = "AndroidResource";
        }

        private void SaveProject()
        {
            var project = this.GetActiveProject();

            project.Save();
        }

        private EnvDTE.Project GetActiveProject()
        {
            var dteService = AddIconCommand.Instance.DTE;
            return ((object[])dteService.ActiveSolutionProjects)
                .Select(x => (EnvDTE.Project)x)
                .FirstOrDefault();
        }


        #region Events

        private void ConfigurationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetPreview();
        }

        private void sourceButton_Click(object sender, EventArgs e)
        {
            VsShellUtilities.OpenSystemBrowser("https://github.com/google/material-design-icons");
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            this.StartDownloading();
        }

        #endregion
    }
}
