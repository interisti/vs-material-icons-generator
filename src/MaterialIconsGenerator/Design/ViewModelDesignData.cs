using System;
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
            this.FilteredItems = new ObservableCollection<IconListViewModel>()
            {
                new IconListViewModelDesign(new IconDesign()),
                new IconListViewModelDesign(new IconDesign()),
                new IconListViewModelDesign(new IconDesign()),
                new IconListViewModelDesign(new IconDesign()),
                new IconListViewModelDesign(new IconDesign()),
                new IconListViewModelDesign(new IconDesign())
            };
            this.SelectedIcon = new IconListViewModelDesign(new IconDesign());
            this.IconProvider = new IconProviderDesign();
        }
    }

    internal class IconListViewModelDesign : IconListViewModel
    {
        public IconListViewModelDesign(IIcon icon)
            : base(icon)
        { }
    }

    internal class IconDetailsViewModelDesign : IconDetailsViewModel
    {
        public IconDetailsViewModelDesign(IIcon icon)
            : base(icon)
        { }
    }

    internal class IconDesign : IIcon
    {
        public IconDesign()
        {
            this.Id = new Random().Next().ToString();
            this.Name = $"icon_{new Random().Next()}";
            this.Category = new IconCategoryDesign();
            this.Keywords = new List<string>() { $"keyword_{new Random().Next()}", $"keyword_{new Random().Next()}" };
            this.PreviewUrl = "https://vs-material-icons-generator.s3.amazonaws.com/icon-providers/google/assets/action/drawable-xdpi/material-icons/ic_3d_ratition_24dp.png";
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
        public ProjectIconDesign(IIcon icon, IIconTheme theme, IIconColor color, ISize size, string density)
        {
            this.Icon = icon;
            this.FullName = icon.Name;
            this.Color = color;
            this.Theme = theme;
            this.Size = size;
            this.Density = density;
        }

        public IIcon Icon { get; set; }

        public string FullName { get; set; }

        public IIconTheme Theme { get; set; }

        public IIconColor Color { get; set; }

        public ISize Size { get; set; }

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
            this.Color = Color.Indigo;
        }

        public string Name { get; set; }

        public Color Color { get; set; }

        public bool IsEditable { get => true; }
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

    internal class SizeDesign : ISize
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Title => this.Name;
    }

    internal class IconThemeDesign : IIconTheme
    {
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

        public IProjectIcon CreateProjectIcon(IIcon icon, IIconTheme theme, IIconColor color, ISize size, string density)
        {
            return new ProjectIconDesign(icon, theme, color, size, density);
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

        public IEnumerable<ISize> GetSizes()
        {
            return new List<ISize>()
            {
                new SizeDesign{ Id = "18", Name ="18dp" },
                new SizeDesign{ Id = "24", Name ="24dp" },
                new SizeDesign{ Id = "36", Name ="36dp" },
                new SizeDesign{ Id = "48", Name ="48dp" }
            };
        }

        public IEnumerable<IIconTheme> GetThemes()
        {
            return new List<IIconTheme>()
            {
                new IconThemeDesign{ Id = "material-icons", Name ="Material Icons" },
                new IconThemeDesign{ Id = "material-icons-outlined", Name ="Material Icons Outlined" },
                new IconThemeDesign{ Id = "material-icons-round", Name ="Material Icons Round" },
                new IconThemeDesign{ Id = "material-icons-sharp", Name ="Material Icons Sharp" },
                new IconThemeDesign{ Id = "material-icons-two-tone", Name ="Material Icons Two Tone" }
            };
        }
    }
}
