using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VSMaterialIcons.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            this.FilterCommand = new RelayCommand(this.DoFilter);
            this.LoadCommand = new RelayCommand(this.DoLoad);
        }


        private ObservableCollection<IconViewModel> _items;
        public ObservableCollection<IconViewModel> Items
        {
            get { return _items; }
            set { this.Set(ref this._items, value); this.DoFilter(); }
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
            set { this.Set(ref this._filterExpression, value); }
        }

        private IconViewModel _selectedIcon;
        public IconViewModel SelectedIcon
        {
            get { return _selectedIcon; }
            set { this.Set(ref this._selectedIcon, value); }
        }

        private ObservableCollection<Models.Size> _availableSizes = new ObservableCollection<Models.Size>(Models.Size.GetDefault());
        public ObservableCollection<Models.Size> AvailableSizes
        {
            get { return _availableSizes; }
            set { this.Set(ref this._availableSizes, value); }
        }


        public RelayCommand FilterCommand { get; set; }
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

        public RelayCommand LoadCommand { get; set; }
        private async void DoLoad()
        {
            this.IsBusy = true;
            this.Items = new ObservableCollection<IconViewModel>(
                (await Models.Icon.GetIconsAsync())
                .Select(x => new IconViewModel(x))
                .ToList());
            this.IsBusy = false;
        }
    }
}