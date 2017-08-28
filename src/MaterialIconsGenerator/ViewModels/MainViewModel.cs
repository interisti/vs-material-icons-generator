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

        private ObservableCollection<IconViewModel> _items;
        public ObservableCollection<IconViewModel> Items
        {
            get { return _items; }
            set { this.Set(ref this._items, value); this.DoFilter(); }
        }

        public RelayCommand LoadCommand { get; set; }
        private async void DoLoad()
        {
            this.IsBusy = true;

            this.Items = new ObservableCollection<IconViewModel>(
                (await this._iconProvider.Get())
                .Select(x => new IconViewModel(x))
                .ToList());

            this.IsBusy = false;
        }

        private ObservableCollection<IconViewModel> _filteredItems;
        public ObservableCollection<IconViewModel> FilteredItems
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
                this.FilteredItems = new ObservableCollection<IconViewModel>(
                    this.Items.Where(x => x.Icon.Name.Contains(this.FilterExpression)));
            }
        }

        private IconViewModel _selectedIcon;
        public IconViewModel SelectedIcon
        {
            get { return _selectedIcon; }
            set { this.Set(ref this._selectedIcon, value); }
        }
    }
}