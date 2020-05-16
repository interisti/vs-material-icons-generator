using MaterialIconsGenerator.Core;

namespace MaterialIconsGenerator.ViewModels
{
    public class IconListViewModel : BaseViewModel
    {
        public IconListViewModel(IIcon icon)
        {
            this._icon = icon;
        }

        private IIcon _icon;
        public IIcon Icon
        {
            get { return this._icon; }
            set { this.Set(ref this._icon, value); }
        }

        public string PreviewUrl
        {
            get { return this.Icon.PreviewUrl; }
        }
    }
}
