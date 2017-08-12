using System.Windows.Input;

namespace MaterialIconsGenerator.UI
{
    public static class Commands
    {
        public static ICommand FocusOnSearchBox { get; } = new RoutedCommand();

        public static ICommand OpenExternalLink { get; } = new RoutedCommand();
    }
}
