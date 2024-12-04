﻿using DoNoHarm.Data;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace DoNoHarm.ViewModel
{
    internal class AddEditViewModel : BindableBase
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Price { get; set; }
        public string Title { get; set; }
        public DelegateCommand AddEditNewService { get; set; }
        private bool ItsEdit = false;
        private services EditService;
        private Window window;

        public AddEditViewModel(Window window, services services = null)
        {
            AddEditNewService = new DelegateCommand(AddEditNewServiceRealization);
            
            if (services != null)
            {
                Name = services.name; 
                Code = services.code;
                Price = services.price.ToString();
                EditService = services;
                Title = "Изменение";
            }
            else
            {
                Title = "Добавление";
            }
            this.window = window;
        }

        private async void AddEditNewServiceRealization()
        {
            if (ItsEdit)
            {
                EditService.name = Name;
                EditService.code = Code;
                EditService.price = decimal.Parse(Price);
                await DoNoHarmDB.GetContext().SaveChangesAsync();
                MessageBox.Show("Пользователь успешно изменён", "Успешный успех", MessageBoxButton.OK, MessageBoxImage.Information);
                window.Close();
            }
            else
            {
                var newService = new services();
                newService.name = Name;
                newService.code = Code;
                newService.price = Decimal.Parse(Price);
                DoNoHarmDB.GetContext().services.Add(newService);
                await DoNoHarmDB.GetContext().SaveChangesAsync();
                MessageBox.Show("Пользователь успешно добавлен", "Успешный успех", MessageBoxButton.OK, MessageBoxImage.Information);
                window.Close();
            }
        }
    }
}
