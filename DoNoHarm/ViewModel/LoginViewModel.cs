using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Commands;
using System.Security.Permissions;
using System.Windows;

namespace DoNoHarm.ViewModel
{
    internal class LoginViewModel : BindableBase
    {
        private Window window;
        private string _login;
        private string _password;
        private DelegateCommand _authorizate;

        public string Login { get => _login; set => _login = value; }
        public string Password { get => _password; set => _password = value; }

        public DelegateCommand Authorizate { get => _authorizate; set => _authorizate = value; }

        private void AuthorizateRealiztion()
        {
            new MainWindow().Show();
            window.Close();
        }

        public LoginViewModel(Window window)
        {
            _authorizate = new DelegateCommand(AuthorizateRealiztion);
            this.window = window;
        }

    }
}
