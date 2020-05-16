// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Microsoft.VisualStudio.Shell;

namespace MaterialIconsGenerator.Views
{
    public class Styles
    {
        [Browsable(false)]
        public static object ComboStyleKey => VsResourceKeys.ComboBoxStyleKey ?? typeof(ComboBox);

        [Browsable(false)]
        public static object ScrollBarStyleKey => VsResourceKeys.ScrollBarStyleKey ?? typeof(ScrollBar);

        [Browsable(false)]
        public static object ScrollViewerStyleKey => VsResourceKeys.ScrollViewerStyleKey ?? typeof(ScrollViewer);

        [Browsable(false)]
        public static object CheckBoxStyleKey => VsResourceKeys.ThemedDialogCheckBoxStyleKey ?? typeof(CheckBox);

        [Browsable(false)]
        public static object ButtonStyleKey => VsResourceKeys.ThemedDialogButtonStyleKey ?? typeof(Button);

        [Browsable(false)]
        public static object ProgressBarStyleKey => VsResourceKeys.ProgressBarStyleKey ?? typeof(ProgressBar);
    }
}