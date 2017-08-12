using Microsoft.VisualStudio.PlatformUI;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Input;
using MaterialIconsGenerator.ViewModels;
using MaterialIconsGenerator.VS;

namespace MaterialIconsGenerator.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : DialogWindow, IVsWindowSearch
    {
        private readonly IVsWindowSearchHost _windowSearchHost;
        private readonly IVsWindowSearchHostFactory _windowSearchHostFactory;
        private readonly MainViewModel _mainViewModel;

        public MainWindow()
        {
            InitializeComponent();

            _mainViewModel = this.FindResource("MainViewModel") as MainViewModel;

            // initialize Search
            _windowSearchHostFactory = ServiceLocator.GetGlobalService<SVsWindowSearchHostFactory, IVsWindowSearchHostFactory>();
            if (_windowSearchHostFactory != null)
            {
                _windowSearchHost = _windowSearchHostFactory.CreateWindowSearchHost(
                    this._searchControlParent);
                _windowSearchHost.SetupSearch(this);
                _windowSearchHost.IsVisible = true;
            }
        }

        #region Events

        private void FocusOnSearchBox_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            _windowSearchHost.Activate();
        }

        private void ExecuteOpenLicenseLink(object sender, ExecutedRoutedEventArgs e)
        {
            var hyperlink = e.OriginalSource as Hyperlink;
            if (hyperlink != null && hyperlink.NavigateUri != null)
            {
                e.Handled = true;

                try
                {
                    Process.Start(hyperlink.NavigateUri.AbsoluteUri);
                }
                catch (Exception ex)
                {
                    ActivityLog.TryLogError("Material Icons Generator", ex.Message);
                }
            }
        }

        #endregion

        #region Utils

        private string GetSearchWatermark()
        {
            var focusOnSearchKeyGesture = (KeyGesture)InputBindings.OfType<KeyBinding>().First(
                x => x.Command == Commands.FocusOnSearchBox).Gesture;
            return $"Search ({focusOnSearchKeyGesture.GetDisplayStringForCulture(CultureInfo.CurrentCulture)})";
        }

        #endregion

        #region IVsWindowSearch Members

        public Guid Category => Guid.Empty;

        public bool SearchEnabled => true;

        public IVsEnumWindowSearchFilters SearchFiltersEnum => null;

        public IVsEnumWindowSearchOptions SearchOptionsEnum => null;

        public void ClearSearch()
        {
            this._mainViewModel.FilterExpression = _windowSearchHost.SearchQuery.SearchString;
        }

        public IVsSearchTask CreateSearch(uint dwCookie, IVsSearchQuery pSearchQuery, IVsSearchCallback pSearchCallback)
        {
            this._mainViewModel.FilterExpression = pSearchQuery.SearchString;

            return null;
        }

        public bool OnNavigationKeyDown(uint dwNavigationKey, uint dwModifiers)
        {
            // We are not interesting in intercepting navigation keys, so return "not handled"
            return false;
        }

        public void ProvideSearchSettings(IVsUIDataSource pSearchSettings)
        {
            // pSearchSettings is of type SearchSettingsDataSource. We use dynamic here
            // so that the code can be run on both dev12 & dev14. If we use the type directly,
            // there will be type mismatch error.
            dynamic settings = pSearchSettings;
            settings.ControlMinWidth = (uint)this._searchControlParent.MinWidth;
            settings.ControlMaxWidth = uint.MaxValue;
            settings.SearchWatermark = this.GetSearchWatermark();
        }

        #endregion
    }
}
