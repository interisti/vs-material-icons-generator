using MaterialIconsGenerator.Core;

namespace MaterialIconsGenerator.ViewModels
{
    public class IconListViewModel : BaseViewModel
    {
        public IconListViewModel(IIcon icon)
        {
            this._icon = icon;
            this._filterableText = $"{icon.Name}#${icon.Category.Name}#{string.Join("#", icon.Keywords)}";
        }

        private string _filterableText;

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

        public bool SatisfiesFilter(string filterExpression)
        {
            return this._filterableText.Contains(filterExpression);
        }
    }
}
