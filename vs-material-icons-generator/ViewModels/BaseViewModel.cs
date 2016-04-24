using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSMaterialIcons.ViewModels
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
