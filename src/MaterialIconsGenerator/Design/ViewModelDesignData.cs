﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Ioc;
using MaterialIconsGenerator.Core;
using MaterialIconsGenerator.ViewModels;

namespace MaterialIconsGenerator.Design
{
    internal class MainViewModelDesign : MainViewModel
    {
        [PreferredConstructor]
        public MainViewModelDesign()
        {
            this.FilteredItems = new ObservableCollection<IconViewModel>()
            {
                new IconViewModelDesign(new IconDesign()),
                new IconViewModelDesign(new IconDesign()),
                new IconViewModelDesign(new IconDesign()),
                new IconViewModelDesign(new IconDesign()),
                new IconViewModelDesign(new IconDesign()),
                new IconViewModelDesign(new IconDesign())
            };
            this.SelectedIcon = new IconViewModelDesign(new IconDesign());
            this.IconProvider = new IconProviderDesign();
        }
    }

    internal class IconViewModelDesign : IconViewModel
    {
        public IconViewModelDesign(IIcon icon)
            : base(icon)
        {

        }
    }

    internal class IconDesign : IIcon
    {
        public IconDesign()
        {
            this.Id = new Random().Next().ToString();
            this.Name = $"icon_{new Random().Next()}";
            this.Category = new IconCategoryDesign();
            this.Keywords = new List<string>() { $"keyword_{new Random().Next()}", $"keyword_{new Random().Next()}" };
            this.PreviewUrl = "https://raw.githubusercontent.com/google/material-design-icons/master/action/drawable-mdpi/ic_3d_rotation_black_24dp.png";
            this.Provider = new IconProviderDesign();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public IIconCategory Category { get; set; }

        public IEnumerable<string> Keywords { get; set; }

        public string PreviewUrl { get; set; }

        public IIconProvider Provider { get; set; }
    }

    internal class ProjectIconDesign : IProjectIcon
    {
        public ProjectIconDesign(IIcon icon, IIconColor color, string size, string density)
        {
            this.Icon = icon;
            this.FullName = icon.Name;
            this.Color = color;
            this.Size = size;
            this.Density = density;
        }

        public IIcon Icon { get; set; }

        public string FullName { get; set; }

        public IIconColor Color { get; set; }

        public string Size { get; set; }

        public string Density { get; set; }

        public Task<byte[]> Get()
        {
            return null;
        }
    }

    internal class IconColorDesign : IIconColor
    {
        public IconColorDesign()
        {
            this.Name = $"name_{new Random().Next()}";
            this.Color = Color.Black;
        }

        public string Name { get; set; }

        public Color Color { get; set; }
    }

    internal class IconCategoryDesign : IIconCategory
    {
        public IconCategoryDesign()
        {
            this.Id = new Random().Next().ToString();
            this.Name = $"icon_{new Random().Next()}";
        }

        public string Id { get; set; }

        public string Name { get; set; }
    }

    internal class IconProviderDesign : IIconProvider
    {
        public IconProviderDesign()
        {
            this.Name = $"icon_{new Random().Next()}";
            this.Reference = $"http://www.test-{new Random().Next()}.com";
        }

        public string Name { get; set; }

        public string Reference { get; set; }

        public IProjectIcon CreateProjectIcon(IIcon icon, IIconColor color, string size, string density)
        {
            return new ProjectIconDesign(icon, color, size, density);
        }

        public Task<IEnumerable<IIcon>> Get()
        {
            return null;
        }

        public IEnumerable<string> GetDensities()
        {
            return new List<string>()
            {
                "mdpi",
                "hdpi",
                "xhdpi",
                "xxhdpi",
                "xxxhdpi"
            };
        }

        public IEnumerable<string> GetSizes()
        {
            return new List<string>()
            {
                "18dp",
                "24dp",
                "36dp",
                "48dp"
            };
        }
    }
}