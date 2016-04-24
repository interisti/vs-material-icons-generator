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
using VSMaterialIcons.VS;

namespace VSMaterialIcons
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // start waiting
            VS.StatusBar.DisplayMessage("Downloading icons from repo ...");

            this.LoadIcons();
            this.LoadColors();
            this.LoadSizes();
            // stop waiting
            VS.StatusBar.Clear();

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
                VS.StatusBar.DisplayMessage("Downloading icon ...");

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
                OutputPane.Output(ex.Message);
                OutputPane.Output(ex.StackTrace);
                OutputPane.Activate();
            }
            finally
            {
                // stop waiting
                VS.StatusBar.Clear();
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
                VS.StatusBar.DisplayMessage("Downloading icons ...");
                var project = VS.Project.GetActiveProject();
                var projectDir = VS.Project.GetProjectDirectory(project);

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
                    var fullPath = Path.Combine(projectDir, IconLocation.RESOURCES_FOLDER, folder,
                        name + IconLocation.ICON_EXTENSION);
                    // save to folder
                    IconLocation.SaveIcon(data, fullPath);
                    // add to project
                    VS.Project.AddFileToProject(project, fullPath, "AndroidResource");
                }

                project.Save();
            }
            catch (Exception ex)
            {
                OutputPane.Output(ex.Message);
                OutputPane.Output(ex.StackTrace);
                OutputPane.Activate();
            }
            finally
            {
                // stop waiting
                VS.StatusBar.Clear();
            }
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
