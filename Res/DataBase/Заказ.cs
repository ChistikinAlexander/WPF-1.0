//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WPF_1._0.Res.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Заказ
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Заказ()
        {
            this.Поступления = new HashSet<Поступления>();
        }
    
        public int Id { get; set; }
        public string OrderNum { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<int> Corp { get; set; }
        public Nullable<int> Product { get; set; }
        public Nullable<int> Count { get; set; }
        public Nullable<int> Price { get; set; }
    
        public virtual Поставщики Поставщики { get; set; }
        public virtual Товар Товар { get; set; }
        public virtual Товар Товар1 { get; set; }
        public virtual Товар Товар2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Поступления> Поступления { get; set; }
    }
}
