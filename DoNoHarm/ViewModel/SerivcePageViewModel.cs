using DoNoHarm.Data;
using DoNoHarm.View.Windows;
using Prism.Commands;
using Prism.Dialogs;
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
        public ObservableCollection<services> dgSource { get; set; }
        public DelegateCommand AddNewService { get; set; }
        public DelegateCommand EditService { get; set; }
        public DelegateCommand DeleteService { get; set; }
        public services SelectedService { get; set; }
        public SerivcePageViewModel()
        {
            dgSource = new ObservableCollection<services>();
            Update();

            AddNewService = new DelegateCommand(AddNewServiceRealization);
            EditService = new DelegateCommand(EditNewSerivceRealization);
            DeleteService = new DelegateCommand(RemoveSelectedService);
        }

        private async void Update()
        {
            dgSource.Clear();
            var service = await DoNoHarmDB.GetContext().services.ToListAsync();
            foreach (services item in service)
            {
                dgSource.Add(item);
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
        private async void RemoveSelectedService()
        {
            if (SelectedService != null)
            {
                if (MessageBox.Show($"Вы точно хотите удалить сервис {SelectedService.name}", 
                    "Подтвердите действие", MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    DoNoHarmDB.GetContext().services.Remove(SelectedService);
                    await DoNoHarmDB.GetContext().SaveChangesAsync();
                    Update();
                }
            }
            else
            {
                MessageBox.Show("Сначала выберите нужную услугу для редактирования", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
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
