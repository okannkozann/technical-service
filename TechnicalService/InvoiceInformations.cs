//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TechnicalService
{
    using System;
    using System.Collections.Generic;
    
    public partial class InvoiceInformations
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InvoiceInformations()
        {
            this.InvoiceDetails = new HashSet<InvoiceDetails>();
        }
    
        public int Id { get; set; }
        public string SerialName { get; set; }
        public Nullable<int> SerialNumber { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Time { get; set; }
        public string TaxAdministration { get; set; }
        public Nullable<int> CurrentId { get; set; }
        public Nullable<short> EmployeeId { get; set; }
    
        public virtual Currents Currents { get; set; }
        public virtual Employees Employees { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoiceDetails> InvoiceDetails { get; set; }
    }
}
