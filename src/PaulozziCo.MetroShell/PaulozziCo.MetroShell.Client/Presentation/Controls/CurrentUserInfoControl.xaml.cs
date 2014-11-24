using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using PaulozziCo.MetroShell.Model;

namespace PaulozziCo.MetroShell.Presentation.Controls
{
    public partial class CurrentUserInfoControl : UserControl
    {
        public CurrentUserInfoControl()
        {
            InitializeComponent();


            this.changePassoworButton.Click += (o, t) =>
            {
                AuthenticationModel autentication = new AuthenticationModel();
                autentication.ChangePassword.Execute(null);
            };
        }
    }
}
