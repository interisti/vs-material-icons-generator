using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Net.Http;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight.Command;
using MaterialIconsGenerator.Common;
using MaterialIconsGenerator.Core;
using MaterialIconsGenerator.Models;
using MaterialIconsGenerator.Utils;
using MaterialIconsGenerator.VS;

namespace MaterialIconsGenerator.ViewModels
{
    public class IconViewModel : BaseViewModel
    {
        public IconViewModel()
        {
            this._colors = MaterialIconColor.Get();
            this.AddToProjectCommand = new RelayCommand(this.AddToProject, this.CanAddToProject);
        }

        public IconViewModel(IIcon icon)
            : this()
        {
            var sizes = icon.Provider.GetSizes();
            var densities = icon.Provider.GetDensities();

            this._icon = icon;
            this._color = MaterialIconColor.Black;
            this._size = sizes.First();
            this._densities = densities.Select(density => new Selectable<string>(density, true, (x) => this.AddToProjectCommand.RaiseCanExecuteChanged()));
            this._projectIcon = icon.Provider.CreateProjectIcon(this.Icon,
                this.Color, this.Size, densities.First());

            this.GenerateName();
        }

        private IProjectIcon _projectIcon;
        private IProjectIcon ProjectIcon
        {
            get { return this._projectIcon; }
            set { this.Set(ref this._projectIcon, value); }
        }

        private IIcon _icon;
        public IIcon Icon
        {
            get { return this._icon; }
            set
            {
                this.Set(ref this._icon, value);

                this.UpdatePreviewImage();
                this.GenerateName();
                this.AddToProjectCommand.RaiseCanExecuteChanged();
            }
        }

        private IEnumerable<IIconColor> _colors;
        public IEnumerable<IIconColor> Colors
        {
            get { return _colors; }
            set { this.Set(ref this._colors, value); }
        }

        #region Configuration
        private IIconColor _color;
        public IIconColor Color
        {
            get { return this._color; }
            set
            {
                this.Set(ref this._color, value);
                this.UpdatePreviewImage();
                this.GenerateName();
                this.AddToProjectCommand.RaiseCanExecuteChanged();
            }
        }

        private string _size;
        public string Size
        {
            get { return this._size; }
            set
            {
                this.Set(ref this._size, value);
                this.UpdatePreviewImage(true);
                this.GenerateName();
                this.AddToProjectCommand.RaiseCanExecuteChanged();
            }
        }

        private IEnumerable<Selectable<string>> _densities;
        public IEnumerable<Selectable<string>> Densities
        {
            get { return _densities; }
            set { this.Set(ref this._densities, value); }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                this.Set(ref this._name, value);
                this.AddToProjectCommand.RaiseCanExecuteChanged();
            }
        }
        #endregion

        #region Preview

        public string PreviewUrl => this.Icon.PreviewUrl;

        // cache icon data in black & 
        // reuse it when colour conversion required
        private byte[] _previewImageDataInBlack;

        private BitmapImage _previewImage;
        public BitmapImage PreviewImage
        {
            get
            {
                if (this._previewImage == null)
                    this.UpdatePreviewImage();
                return _previewImage;
            }
            set { this.Set(ref _previewImage, value); }
        }

        private async void UpdatePreviewImage(bool reset = false)
        {
            //var color = (this.Color.IsKnown) ? this.Color : Pallete.Black;
            //var iconUrl = this.GenerateUrl(this.Icon.Group.Id, this.Icon.Id,
            //    this.XHdpi.Item.Folder, color.Name, this.Size.Value);

            //if (this.Color.IsKnown)
            //{
            //    this.PreviewImage = new BitmapImage(new System.Uri(iconUrl),
            //        new RequestCachePolicy(RequestCacheLevel.CacheIfAvailable));
            //}
            //else
            //{
            //    // if icon data is is null, then cache
            //    if (this._previewImageDataInBlack == null || reset)
            //    {
            //        using (var client = new HttpClient())
            //            this._previewImageDataInBlack = await client.GetByteArrayAsync(iconUrl);
            //    }

            //    var iconData = (byte[])this._previewImageDataInBlack.Clone();
            //    iconData = ColorUtils.ReplaceColor(iconData, this.Color.Color);
            //    this.PreviewImage = ImageUtils.BitmapFromByteArray(iconData);
            //}
        }

        #endregion


        public RelayCommand AddToProjectCommand { get; set; }
        private async void AddToProject()
        {
            //try
            //{
            //    this.IsBusy = true;
            //    this.AddToProjectCommand.RaiseCanExecuteChanged();
            //    StatusBar.DisplayMessage("Downloading icons ...");

            //    var project = Project.GetActiveProject();
            //    var projectDir = project.GetRootDirectory();

            //    var selectedTypes = new List<Type>();
            //    if (this.Mdpi.IsSelected) selectedTypes.Add(this.Mdpi.Item);
            //    if (this.Hdpi.IsSelected) selectedTypes.Add(this.Hdpi.Item);
            //    if (this.XHdpi.IsSelected) selectedTypes.Add(this.XHdpi.Item);
            //    if (this.XXHdpi.IsSelected) selectedTypes.Add(this.XXHdpi.Item);
            //    if (this.XXXHdpi.IsSelected) selectedTypes.Add(this.XXXHdpi.Item);

            //    foreach (var type in selectedTypes)
            //    {
            //        var color = (this.Color.IsKnown) ? this.Color : Pallete.Black;
            //        var iconUrl = this.GenerateUrl(this.Icon.Group.Id, this.Icon.Id,
            //            type.Folder, color.Name, this.Size.Value);

            //        byte[] icon;
            //        using (var client = new HttpClient())
            //            icon = await client.GetByteArrayAsync(iconUrl);

            //        if (!this.Color.IsKnown)
            //            icon = ColorUtils.ReplaceColor(icon, this.Color.Color);

            //        var filepath = type.Destination(projectDir, this.Name);
            //        FileUtils.WriteAllBytes(icon, filepath);
            //        // add to project
            //        project.AddFile(filepath, "AndroidResource");
            //    }

            //    project.Save();
            //}
            //catch (System.Exception ex)
            //{
            //    OutputPane.Output(ex.Message);
            //    OutputPane.Output(ex.StackTrace);
            //    OutputPane.Activate();
            //}
            //finally
            //{
            //    StatusBar.Clear();
            //    this.IsBusy = false;
            //    this.AddToProjectCommand.RaiseCanExecuteChanged();
            //}
        }

        private bool CanAddToProject()
        {
            return this.Icon != null && this.Color != null &&
                this.Size != null && (!this.Densities.Any(x => x.IsSelected)) &&
                !string.IsNullOrEmpty(this.Name) && !this.IsBusy;
        }

        private void GenerateName()
        {
            this.Name = this.ProjectIcon.FullName;
        }
    }
}
