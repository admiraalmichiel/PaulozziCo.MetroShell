using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections;

namespace PaulozziCo.MetroShell.Utilities
{
    public static class ListBoxFix
    {
        #region Readonly

        public static readonly DependencyProperty SelectedItemsBindingProperty =
                    DependencyProperty.RegisterAttached("FixSlecetedItemsBinding",
                    typeof(bool), typeof(FrameworkElement), new PropertyMetadata(false));

        #endregion

        #region Public Methods

        public static bool GetSelectedItemsBinding(System.Windows.Controls.ListBox element)
        {
            return (bool)element.GetValue(SelectedItemsBindingProperty);
        }

        public static void SetSelectedItemsBinding(System.Windows.Controls.ListBox element, bool value)
        {
            element.SetValue(SelectedItemsBindingProperty, value);
            if (value)
            {
                element.SelectionChanged += (sender, args) =>
                {
                    // Dummy code to refresh SelectedItems value
                    var x = element.SelectedItems;
                };
            }
        }

        #endregion

    }
}
