using DoNoHarm.Model;
using DoNoHarm.View.Pages;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DoNoHarm.ViewModel
{
    internal class MainWindowViewModel
    {

        private Page ServicePage;
        private Page UserPage;


        public DelegateCommand navigateService { get; set; }
        public DelegateCommand navigateUsers { get; set; }

        public MainWindowViewModel()
        {
            navigateService = new DelegateCommand(NavigateService);
            navigateUsers = new DelegateCommand(NavigateUsers);
        }


        private void NavigateUsers()
        {
            if (Navigation.ActivePage != UserPage || UserPage == null)
            {
                UserPage = new UserPage();
                Navigation.Navigate(UserPage);
            } else if (Navigation.ActivePage != UserPage || UserPage != null)
            {
                Navigation.Navigate(UserPage);
            }
        }

        private void NavigateService()
        {
            if (Navigation.ActivePage != ServicePage || ServicePage == null)
            {
                ServicePage = new ServicePage();
                Navigation.Navigate(ServicePage);
            } else if (Navigation.ActivePage != ServicePage || ServicePage != null)
            {
                Navigation.Navigate(ServicePage);
            }
        }

    }
}
