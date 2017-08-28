using System.Windows.Input;

namespace MaterialIconsGenerator.Views
{
    public static class Commands
    {
        public static ICommand FocusOnSearchBox { get; } = new RoutedCommand();

        public static ICommand OpenExternalLink { get; } = new RoutedCommand();
    }
}
