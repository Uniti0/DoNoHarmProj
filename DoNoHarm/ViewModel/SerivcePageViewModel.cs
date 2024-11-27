using DoNoHarm.Data;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoNoHarm.ViewModel
{
    internal class SerivcePageViewModel : BindableBase
    {
        public ObservableCollection<services> dgSourse { get; set; }
        public SerivcePageViewModel()
        {
            dgSourse = new ObservableCollection<services>();
            DoNoHarmDB.GetContext().services.ToListAsync().Wait(); 
        }

    }
}
