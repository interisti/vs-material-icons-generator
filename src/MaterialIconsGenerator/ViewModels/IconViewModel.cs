using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using MaterialIconsGenerator.Common;
using MaterialIconsGenerator.Core;
using MaterialIconsGenerator.Utils;
using MaterialIconsGenerator.VS;

namespace MaterialIconsGenerator.ViewModels
{
    public class IconViewModel : BaseViewModel
    {
        private IProjectManager _projectManager;

        public IconViewModel()
        {
            if (!IsInDesignModeStatic)
            {
                this._projectManager = SimpleIoc.Default.GetInstance<IProjectManager>();
            }
            this.AddToProjectCommand = new RelayCommand(this.AddToProject, this.CanAddToProject);
        }

        public IconViewModel(IIcon icon)
            : this()
        {
            var sizes = icon.Provider.GetSizes();
            var densities = icon.Provider.GetDensities();

            this._icon = icon;
            this._color = MaterialIconColor.Black;
            this._colors = new ObservableCollection<IIconColor>(MaterialIconColor.Get());
            this._size = sizes.First();
            this._sizes = new ObservableCollection<string>(sizes);
            this._densities = new ObservableCollection<Selectable<string>>(
                densities.Select(density => new Selectable<string>(density, !density.Contains("drawable"),
                (x) => this.AddToProjectCommand.RaiseCanExecuteChanged())));
            this._projectIcon = icon.Provider.CreateProjectIcon(this.Icon,
                this.Color, this.Size, densities.First());

            this.GenerateName();
        }

        private IProjectIcon _projectIcon;
        protected IProjectIcon ProjectIcon
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

                this.GenerateName();
                this.UpdatePreviewImage();
                this.AddToProjectCommand.RaiseCanExecuteChanged();
            }
        }

        private ObservableCollection<IIconColor> _colors;
        public ObservableCollection<IIconColor> Colors
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

                this.GenerateName();
                this.UpdatePreviewImage();
                this.AddToProjectCommand.RaiseCanExecuteChanged();
            }
        }

        private ObservableCollection<string> _sizes;
        public ObservableCollection<string> Sizes
        {
            get { return this._sizes; }
            set { this.Set(ref this._sizes, value); }
        }

        private string _size;
        public string Size
        {
            get { return this._size; }
            set
            {
                this.Set(ref this._size, value);

                this.GenerateName();
                this.UpdatePreviewImage();
                this.AddToProjectCommand.RaiseCanExecuteChanged();
            }
        }

        private ObservableCollection<Selectable<string>> _densities;
        public ObservableCollection<Selectable<string>> Densities
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

        public string PreviewUrl
        {
            get { return this.Icon.PreviewUrl; }
        }

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

        private async void UpdatePreviewImage()
        {
            if (IsInDesignModeStatic) return;

            var data = await this.ProjectIcon.Get();
            this.PreviewImage = ImageUtils.BitmapFromByteArray(data);
        }

        #endregion

        #region Save
        public RelayCommand AddToProjectCommand { get; set; }
        private async void AddToProject()
        {
            try
            {
                this.IsBusy = true;
                this.AddToProjectCommand.RaiseCanExecuteChanged();
                StatusBar.DisplayMessage("Downloading icons ...");

                var project = Project.GetActiveProject();
                var icons = this.Densities.Where(x => x.IsSelected).Select(density =>
                 {
                     return this.Icon.Provider.CreateProjectIcon(this.Icon, this.Color, this.Size, density.Item);
                 });

                foreach (var icon in icons)
                {
                    await this._projectManager.AddIcon(project, icon);
                }
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
            return this.Icon != null && this.Color != null &&
                this.Size != null && this.Densities.Any(x => x.IsSelected) &&
                !string.IsNullOrEmpty(this.Name) && !this.IsBusy;
        }
        #endregion

        private void GenerateName()
        {
            if (this.ProjectIcon == null) return;

            this.ProjectIcon.Color = this.Color;
            this.ProjectIcon.Size = this.Size;
            this.Name = this.ProjectIcon.FullName;
        }
    }
}
