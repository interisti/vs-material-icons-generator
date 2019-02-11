﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using MaterialIconsGenerator.Common;
using MaterialIconsGenerator.Core;
using MaterialIconsGenerator.Models;
using MaterialIconsGenerator.Utils;
using MaterialIconsGenerator.VS;

namespace MaterialIconsGenerator.ViewModels
{
    public class IconDetailsViewModel : BaseViewModel
    {
        private IProjectManager _projectManager;

        public IconDetailsViewModel()
        {
            if (!IsInDesignModeStatic)
            {
                this._projectManager = SimpleIoc.Default.GetInstance<IProjectManager>();
            }
            this.AddToProjectCommand = new RelayCommand(this.AddToProject, this.CanAddToProject);
        }

        public IconDetailsViewModel(IIcon icon, ISize size = null, IIconColor color = null)
            : this()
        {
            var sizes = icon.Provider.GetSizes();
            var densities = icon.Provider.GetDensities();
            // fill selection controls
            this._icon = icon;
            this._colors = new ObservableCollection<IIconColor>(MaterialIconColor.Get());
            this._size = size ?? sizes.First();
            this._sizes = new ObservableCollection<ISize>(sizes);
            this._densities = new ObservableCollection<Selectable<string>>(
                densities.Select(density => new Selectable<string>(density, !density.Contains("drawable"),
                (x) => this.AddToProjectCommand.RaiseCanExecuteChanged())));

            // fill user selection
            this._color = color ?? MaterialIconColor.Black;
            this._colorCode = this.ColorToCode(this._color.Color);
            this._materialColorSelected = this._color is MaterialIconColor 
                ? this._color 
                : MaterialIconColor.Black;
            this._projectIcon = icon.Provider.CreateProjectIcon(this.Icon,
                this.Color, this.Size, densities.FirstOrDefault());

            this.GenerateName();
        }

        private string _error;
        public string Error
        {
            get { return _error; }
            set
            {
                this.Set(ref _error, value);
                this.AddToProjectCommand.RaiseCanExecuteChanged();
            }
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
        private IIconColor _materialColorSelected;
        public IIconColor MaterialColorSelected
        {
            get { return this._materialColorSelected; }
            set
            {
                this.Set(ref this._materialColorSelected, value);

                // 1. update color code
                this.Set(ref this._colorCode, this.ColorToCode(value.Color), "ColorCode");
                // 2. update private color
                this.Color = value;
            }
        }

        private string _colorCode;
        public string ColorCode
        {
            get { return this._colorCode; }
            set
            {
                this.Set(ref this._colorCode, value);

                var customColor = CustomColor.FromHex(value);
                if (customColor != null)
                {
                    // update private color
                    this.Color = customColor;
                }
            }
        }



        private IIconColor _color;
        public IIconColor Color
        {
            get { return this._color; }
            private set
            {
                this.Set(ref this._color, value);

                this.GenerateName();
                this.UpdatePreviewImage();
                this.AddToProjectCommand.RaiseCanExecuteChanged();
            }
        }

        private ObservableCollection<ISize> _sizes;
        public ObservableCollection<ISize> Sizes
        {
            get { return this._sizes; }
            set { this.Set(ref this._sizes, value); }
        }

        private ISize _size;
        public ISize Size
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

        private BitmapImage _previewImage;
        public BitmapImage PreviewImage
        {
            get
            {
                if (this._previewImage == null)
                    this.UpdatePreviewImage();
                return _previewImage;
            }
            set
            {
                if (value == null)
                {
#if DEBUG
                    throw new System.Exception("null is invalid value for PreviewImage");
#else
                    return;
#endif
                }

                this.Set(ref _previewImage, value);
            }
        }

        private async void UpdatePreviewImage()
        {
            if (IsInDesignModeStatic) return;

            var data = await this.ProjectIcon.Get();

            if (data == null)
            {
                this.PreviewImage = ImageUtils.EmptyBitmap;
                this.Error = "Icon or size does not exists in Google's github repo";
            }
            else
            {
                this.PreviewImage = ImageUtils.BitmapFromByteArray(data);
                this.Error = string.Empty;
            }
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

                var project = Project.GetActiveProject();
                var icons = this.Densities.Count == 0
                    ? new List<IProjectIcon>() { this.Icon.Provider.CreateProjectIcon(this.Icon, this.Color, this.Size, null) }
                    : this.Densities.Where(x => x.IsSelected).Select(density =>
                    { return this.Icon.Provider.CreateProjectIcon(this.Icon, this.Color, this.Size, density.Item); });

                foreach (var icon in icons)
                {
                    await this._projectManager.AddIcon(project, icon, this.Name);
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
                this.IsBusy = false;
                this.AddToProjectCommand.RaiseCanExecuteChanged();
            }
        }

        private bool CanAddToProject()
        {
            return !this.IsBusy &&
                this.Icon != null &&
                this.Color != null &&
                this.Size != null &&
                !string.IsNullOrEmpty(this.Name) &&
                (this.Densities.Count == 0 || this.Densities.Any(x => x.IsSelected)) &&
                !string.IsNullOrEmpty(this.Name) &&
                string.IsNullOrEmpty(this.Error);
        }
        #endregion

        private void GenerateName()
        {
            if (this.ProjectIcon == null) return;

            this.ProjectIcon.Color = this.Color;
            this.ProjectIcon.Size = this.Size;
            this.Name = this.ProjectIcon.FullName;
        }

        private string ColorToCode(System.Drawing.Color color)
        {
            return $"#{color.A.ToString("X2")}{color.R.ToString("X2")}{color.G.ToString("X2")}{color.B.ToString("X2")}";
        }
    }
}
