using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VSMaterialIcons.UI
{
    public static class Commands
    {
        public static ICommand FocusOnSearchBox { get; } = new RoutedCommand();
    }

}
