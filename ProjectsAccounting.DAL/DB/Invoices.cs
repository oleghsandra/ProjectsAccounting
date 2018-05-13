//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectsAccounting.DAL.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Invoices
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Invoices()
        {
            this.InvoicedTasks = new HashSet<InvoicedTasks>();
        }
    
        public int InvoiceId { get; set; }
        public Nullable<int> ProjectId { get; set; }
        public Nullable<System.DateTime> InvoiceDate { get; set; }
        public string Notes { get; set; }
        public string CompanyName { get; set; }
        public string MainAccpuntantName { get; set; }
        public string OwnerName { get; set; }
        public string LocationAddress { get; set; }
        public string Fax { get; set; }
        public string Phone { get; set; }
        public Nullable<double> TaxRate { get; set; }
        public Nullable<double> OfficeRate { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
    
        public virtual Projects Projects { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoicedTasks> InvoicedTasks { get; set; }
    }
}
