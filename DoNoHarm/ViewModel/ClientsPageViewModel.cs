using DoNoHarm.Data;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoNoHarm.ViewModel
{
    internal class ClientsPageViewModel
    {
        public ObservableCollection<clients> lvSourse { get; set; }
        public DelegateCommand AddNewClients { get; set; }
        public DelegateCommand EditClients { get; set; }
        public DelegateCommand DeleteClients { get; set; }

        public clients SelectedClients { get; set; }


        public ClientsPageViewModel()
        {
            AddNewClients = new DelegateCommand(AddNewClientsRealization);
            EditClients = new DelegateCommand(EditClientsRealization);
            DeleteClients = new DelegateCommand(DeleteClientsRealization);

            Update();
        }

        private async void Update()
        {

        }

        private void AddNewClientsRealization()
        {
            
        }

        private void EditClientsRealization()
        {

        }
        private void DeleteClientsRealization()
        {

        }
    }
}