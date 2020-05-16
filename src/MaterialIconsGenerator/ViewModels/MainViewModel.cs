using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using MaterialIconsGenerator.Core;

namespace MaterialIconsGenerator.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            if (!IsInDesignModeStatic)
            {
                this._iconProvider = SimpleIoc.Default.GetInstance<IIconProvider>();
            }
            this.LoadCommand = new RelayCommand(this.DoLoad);
        }

        private IIconProvider _iconProvider;
        protected IIconProvider IconProvider
        {
            get { return _iconProvider; }
            set { _iconProvider = value; }
        }

        private ObservableCollection<IconListViewModel> _items;
        public ObservableCollection<IconListViewModel> Items
        {
            get { return _items; }
            set { this.Set(ref this._items, value); this.DoFilter(); }
        }

        public RelayCommand LoadCommand { get; set; }
        private async void DoLoad()
        {
            this.IsBusy = true;

            this.Items = new ObservableCollection<IconListViewModel>(
                (await this._iconProvider.Get())
                .Select(x => new IconListViewModel(x))
                .ToList());

            this.IsBusy = false;
        }

        private ObservableCollection<IconListViewModel> _filteredItems;
        public ObservableCollection<IconListViewModel> FilteredItems
        {
            get { return _filteredItems; }
            set { this.Set(ref this._filteredItems, value); }
        }

        private string _filterExpression;
        public string FilterExpression
        {
            get { return _filterExpression; }
            set { this.Set(ref this._filterExpression, value); this.DoFilter(); }
        }

        private void DoFilter()
        {
            if (string.IsNullOrEmpty(this.FilterExpression))
            {
                this.FilteredItems = this.Items;
            }
            else
            {
                this.FilteredItems = new ObservableCollection<IconListViewModel>(
                    this.Items.Where(x => x.Icon.Name.Contains(this.FilterExpression)));
            }
        }

        private IconListViewModel _selectedIcon;
        public IconListViewModel SelectedIcon
        {
            get { return _selectedIcon; }
            set
            {
                if (this.Set(ref this._selectedIcon, value))
                {
                    this.UpdateSelectedIconDetails(value);
                }
            }
        }

        private IconDetailsViewModel _selectedIconDetails;
        public IconDetailsViewModel SelectedIconDetails
        {
            get { return _selectedIconDetails; }
        }

        private void UpdateSelectedIconDetails(IconListViewModel selectedIcon)
        {
            if (selectedIcon is null)
            {
                this._selectedIconDetails = null;
            }
            else
            {
                this._selectedIconDetails = new IconDetailsViewModel(selectedIcon.Icon, this._selectedIconDetails);
            }

            this.RaisePropertyChanged(nameof(this.SelectedIconDetails));
        }
    }
}