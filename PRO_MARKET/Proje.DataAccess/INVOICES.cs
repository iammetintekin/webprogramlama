//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proje.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class INVOICES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INVOICES()
        {
            this.INVOICEDETAILS = new HashSet<INVOICEDETAILS>();
        }
    
        public int ID { get; set; }
        public Nullable<int> ORDERID { get; set; }
        public Nullable<System.DateTime> DATE_ { get; set; }
        public Nullable<int> ADDRESSID { get; set; }
        public string CARGOFICHENO { get; set; }
        public Nullable<decimal> TOTALPRICE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INVOICEDETAILS> INVOICEDETAILS { get; set; }
    }
}