using Microsoft.LightSwitch.Runtime.Shell.Implementation.Standard;
using PaulozziCo.MetroShell.Services;
using System;
using System.Windows.Input;

namespace PaulozziCo.MetroShell.Model
{
    public class AuthenticationModel
    {

        #region Fields

        private ICommand changePassword;

        #endregion

        #region Constructors

        public AuthenticationModel()
        {
            this.ChangePassword = new ChangePasswordCommand();
        }

        #endregion

        #region Properties

        public ICommand ChangePassword
        {
            get
            {
                return this.changePassword;
            }
            private set
            {
                this.changePassword = value;
            }
        }

        #endregion

        private class ChangePasswordCommand : CommandBase
        {
            private void Dialog_Closed(object sender, EventArgs e)
            {
                ChangePasswordDialog dialog = (ChangePasswordDialog)sender;
                if (dialog.DialogResult.HasValue && dialog.DialogResult.Value)
                {
                    ServiceProxy.Instance.CurrentUserViewModel.ChangePassword(dialog.OldPassword, dialog.NewPassword);
                }
            }

            protected override void ExecuteCore(object parameter)
            {
                ChangePasswordDialog dialog = new ChangePasswordDialog();
                dialog.Closed += new EventHandler(this.Dialog_Closed);
                dialog.Show();
            }
        }
    }
}
