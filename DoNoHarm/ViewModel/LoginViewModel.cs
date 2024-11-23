using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Commands;
using System.Security.Permissions;
using System.Windows;
using DoNoHarm.Data;
using System.Data.Entity.Core.Common.EntitySql;
using System.Security.Policy;
using System.Data.Entity;

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

        private async void AuthorizateRealiztion()
        {
            if (String.IsNullOrWhiteSpace(Login) || String.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show("Поля не заполнены или заполнены не правильно", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (await CheckAcconutInDBAsync())
            {
                AuthorizateComplite();
            }
            else
            {
                MessageBox.Show($"Неправильный логин или пароль", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task<bool> CheckAcconutInDBAsync()
        {
            if (await DoNoHarmDB.GetContext().users.Where(i => i.login == Login && i.password == Password).FirstOrDefaultAsync() != null)
                return true;
            else
                return false;
        }

        private void AuthorizateComplite()
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
