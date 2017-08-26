using GalaSoft.MvvmLight;

namespace MaterialIconsGenerator.ViewModels
{
    public class BaseViewModel : ViewModelBase
    {


        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { _isBusy = value; this.RaisePropertyChanged(); }
        }
    }
}
