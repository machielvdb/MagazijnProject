//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MagazijnProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class SupplierOrder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SupplierOrder()
        {
            this.SupplierOrderProducts = new HashSet<SupplierOrderProduct>();
        }
    
        public int SupplierOrderID { get; set; }
        public System.DateTime DateCreated { get; set; }
        public int EmployeeID { get; set; }
        public int SupplierID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SupplierOrderProduct> SupplierOrderProducts { get; set; }
    }
}
