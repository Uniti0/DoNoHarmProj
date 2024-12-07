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
        private Page ClientPage;


        public DelegateCommand navigateService { get; set; }
        public DelegateCommand NavigateClient { get; set; }

        public MainWindowViewModel()
        {
            navigateService = new DelegateCommand(NavigateService);
            NavigateClient = new DelegateCommand(NavigateClientRealization);
        }


        private void NavigateClientRealization()
        {
            if (Navigation.ActivePage != ClientPage || ClientPage == null)
            {
                ClientPage = new ClientsPage();
                Navigation.Navigate(ClientPage);
            } else if (Navigation.ActivePage != ClientPage || ClientPage != null)
            {
                Navigation.Navigate(ClientPage);
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
