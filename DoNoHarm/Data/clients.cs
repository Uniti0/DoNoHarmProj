//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DoNoHarm.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class clients
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public clients()
        {
            this.invoices = new HashSet<invoices>();
            this.orders = new HashSet<orders>();
        }
    
        public int id { get; set; }
        public int type { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string surname { get; set; }
        public string name { get; set; }
        public string patronymic { get; set; }
        public Nullable<System.DateTime> birthdate { get; set; }
        public Nullable<int> passport_series { get; set; }
        public Nullable<int> passport_number { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string company_name { get; set; }
        public string company_address { get; set; }
        public int inn { get; set; }
        public int account { get; set; }
        public int bik { get; set; }
        public bool hidden { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<invoices> invoices { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<orders> orders { get; set; }
    }
}