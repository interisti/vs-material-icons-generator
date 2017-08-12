using System.Collections.Generic;
using System.Net.Cache;
using System.Net.Http;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight.Command;
using MaterialIconsGenerator.Common;
using MaterialIconsGenerator.Models;
using MaterialIconsGenerator.VS;
using MaterialIconsGenerator.Utils;

namespace MaterialIconsGenerator.ViewModels
{
    public class IconViewModel : BaseViewModel
    {
        public IconViewModel()
        {
            this._color = Pallete.Black;
            this._size = Size.Dp24;
            this.AddToProjectCommand = new RelayCommand(this.AddToProject, this.CanAddToProject);
            this._mdpi = new Selectable<Type>(Type.GetMDPI(), true, (x) => this.AddToProjectCommand.RaiseCanExecuteChanged());
            this._hdpi = new Selectable<Type>(Type.GetHDPI(), true, (x) => this.AddToProjectCommand.RaiseCanExecuteChanged());
            this._xhdpi = new Selectable<Type>(Type.GetXHDPI(), true, (x) => this.AddToProjectCommand.RaiseCanExecuteChanged());
            this._xxhdpi = new Selectable<Type>(Type.GetXXHDPI(), true, (x) => this.AddToProjectCommand.RaiseCanExecuteChanged());
            this._xxxhdpi = new Selectable<Type>(Type.GetXXXHDPI(), true, (x) => this.AddToProjectCommand.RaiseCanExecuteChanged());
        }

        public IconViewModel(Icon icon)
            : this()
        {
            this._icon = icon;
            this.GenerateName();
        }

        private Icon _icon;
        public Icon Icon
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

        private void GenerateName()
        {
            if (this.Icon == null || this.Color == null || this.Size == null) return;

            this.Name = $"{this.Icon.Id}_{this.Color.Name}_{this.Size.Value}";
        }


        #region Configuration
        private Pallete _color;
        public Pallete Color
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

        private Size _size;
        public Size Size
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

        private Selectable<Type> _mdpi;
        public Selectable<Type> Mdpi
        {
            get { return this._mdpi; }
        }

        private Selectable<Type> _hdpi;
        public Selectable<Type> Hdpi
        {
            get { return this._hdpi; }
        }

        private Selectable<Type> _xhdpi;
        public Selectable<Type> XHdpi
        {
            get { return this._xhdpi; }
        }

        private Selectable<Type> _xxhdpi;
        public Selectable<Type> XXHdpi
        {
            get { return this._xxhdpi; }
        }

        private Selectable<Type> _xxxhdpi;
        public Selectable<Type> XXXHdpi
        {
            get { return this._xxxhdpi; }
        }
        #endregion

        #region Preview

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
            var color = (this.Color.IsKnown) ? this.Color : Pallete.Black;
            var iconUrl = this.GenerateUrl(this.Icon.Group.Id, this.Icon.Id,
                this.XHdpi.Item.Folder, color.Name, this.Size.Value);

            if (this.Color.IsKnown)
            {
                this.PreviewImage = new BitmapImage(new System.Uri(iconUrl),
                    new RequestCachePolicy(RequestCacheLevel.CacheIfAvailable));
            }
            else
            {
                // if icon data is is null, then cache
                if (this._previewImageDataInBlack == null || reset)
                {
                    using (var client = new HttpClient())
                        this._previewImageDataInBlack = await client.GetByteArrayAsync(iconUrl);
                }

                var iconData = (byte[])this._previewImageDataInBlack.Clone();
                iconData = ColorUtils.ReplaceColor(iconData, this.Color.Color);
                this.PreviewImage = ImageUtils.BitmapFromByteArray(iconData);
            }
        }

        #endregion

        #region ListItem
        public Type ListItemDestination { get; set; } = Type.GetHDPI();

        public Size ListItemSize { get; set; } = new Size() { Name = "24dp", Value = "24dp" };

        public Pallete ListItemColor { get; set; } = Pallete.Black;

        public string ListItemUrl
        {
            get
            {
                return this.GenerateUrl(this.Icon.Group.Id, this.Icon.Id,
                    this.ListItemDestination.Folder, this.ListItemColor.Name, this.ListItemSize.Value);
            }
        }
        #endregion


        public RelayCommand AddToProjectCommand { get; set; }
        private async void AddToProject()
        {
            try
            {
                this.IsBusy = true;
                this.AddToProjectCommand.RaiseCanExecuteChanged();
                StatusBar.DisplayMessage("Downloading icons ...");

                var project = Project.GetActiveProject();
                var projectDir = Project.GetProjectDirectory(project);

                var selectedTypes = new List<Type>();
                if (this.Mdpi.IsSelected) selectedTypes.Add(this.Mdpi.Item);
                if (this.Hdpi.IsSelected) selectedTypes.Add(this.Hdpi.Item);
                if (this.XHdpi.IsSelected) selectedTypes.Add(this.XHdpi.Item);
                if (this.XXHdpi.IsSelected) selectedTypes.Add(this.XXHdpi.Item);
                if (this.XXXHdpi.IsSelected) selectedTypes.Add(this.XXXHdpi.Item);

                foreach (var type in selectedTypes)
                {
                    var color = (this.Color.IsKnown) ? this.Color : Pallete.Black;
                    var iconUrl = this.GenerateUrl(this.Icon.Group.Id, this.Icon.Id,
                        type.Folder, color.Name, this.Size.Value);

                    byte[] icon;
                    using (var client = new HttpClient())
                        icon = await client.GetByteArrayAsync(iconUrl);

                    if (!this.Color.IsKnown)
                        icon = ColorUtils.ReplaceColor(icon, this.Color.Color);

                    var filepath = type.Destination(projectDir, this.Name);
                    FileUtils.WriteAllBytes(icon, filepath);
                    // add to project
                    Project.AddFileToProject(project, filepath, "AndroidResource");
                }

                project.Save();
            }
            catch (System.Exception ex)
            {
                OutputPane.Output(ex.Message);
                OutputPane.Output(ex.StackTrace);
                OutputPane.Activate();
            }
            finally
            {
                StatusBar.Clear();
                this.IsBusy = false;
                this.AddToProjectCommand.RaiseCanExecuteChanged();
            }
        }

        private bool CanAddToProject()
        {
            return this.Icon != null && this.Color != null && this.Size != null &&
                (this.Mdpi.IsSelected || this.Hdpi.IsSelected || this.XHdpi.IsSelected
                    || this.XXHdpi.IsSelected || this.XXXHdpi.IsSelected) &&
                    !string.IsNullOrEmpty(this.Name) &&
                    !this.IsBusy;
        }


        #region Utils
        public string GenerateUrl(string group_id, string icon_id, string folder, string color, string size)
        {
            return $"https://raw.githubusercontent.com/google/material-design-icons/master/{group_id}/{folder}/{icon_id}_{color}_{size}.png";
        }
        #endregion
    }
}
