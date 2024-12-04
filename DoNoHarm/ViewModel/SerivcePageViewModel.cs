using DoNoHarm.Data;
using DoNoHarm.View.Windows;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace DoNoHarm.ViewModel
{
    internal class SerivcePageViewModel : BindableBase
    {
        public ObservableCollection<services> dgSourse { get; set; }
        public DelegateCommand AddNewService { get; set; }
        public DelegateCommand EditService { get; set; }
        public services SelectedService { get; set; }
        public SerivcePageViewModel()
        {
            dgSourse = new ObservableCollection<services>();
            Update();

            AddNewService = new DelegateCommand(AddNewServiceRealization);
            EditService = new DelegateCommand(EditNewSerivceRealization);
        }

        private async void Update()
        {
            var service = await DoNoHarmDB.GetContext().services.ToListAsync();
            foreach (services item in service)
            {
                dgSourse.Add(item);
            }
        }

        private void AddNewServiceRealization()
        {
            if (new AddEdit().ShowDialog().Value == false) 
            {
                Update(); 
                return;
            }
        }
        private void EditNewSerivceRealization()
        {
            if (SelectedService != null)
            {
                if (new AddEdit(SelectedService).ShowDialog().Value == false)
                {
                    Update();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Сначала выберите нужную услугу для редактирования", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
