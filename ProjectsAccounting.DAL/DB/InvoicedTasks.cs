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
    
    public partial class InvoicedTasks
    {
        public int InvoicedTaskId { get; set; }
        public Nullable<int> InvoiceId { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<double> ReportedHours { get; set; }
        public string TaskName { get; set; }
    
        public virtual Users Users { get; set; }
        public virtual Invoices Invoices { get; set; }
    }
}
