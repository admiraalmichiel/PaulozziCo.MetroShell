using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using PaulozziCo.MetroShell.Model;

namespace PaulozziCo.MetroShell.Utilities
{
    public static class ViewModelManager
    {
        #region Public Methods

        /// <summary>
        /// Gets a Singleton Instance of a ViewModel
        /// </summary>
        public static T GetViewModelInstance<T>() where T : ViewModelBase, new()
        {
            string typeKey = typeof(T).Name;
            if (!Application.Current.Resources.Contains(typeKey))
            {
                Application.Current.Resources.Add(typeKey, new T());
            }
            return (T)Application.Current.Resources[typeKey];
        }

        #endregion

    }
}
