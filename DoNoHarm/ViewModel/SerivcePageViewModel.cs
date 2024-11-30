using DoNoHarm.Data;
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
using System.Windows.Documents;

namespace DoNoHarm.ViewModel
{
    internal class SerivcePageViewModel : BindableBase
    {
        public static ObservableCollection<services> dgSourse { get; set; }
        public SerivcePageViewModel()
        {
            dgSourse = new ObservableCollection<services>();
            Update();
        }

        private async void Update()
        {
            var service = await DoNoHarmDB.GetContext().services.ToListAsync();
            foreach (services item in service)
            {
                dgSourse.Add(item);
            }
        }
    }
}
