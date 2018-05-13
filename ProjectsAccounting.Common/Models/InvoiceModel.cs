using System;
using System.Collections.Generic;

namespace ProjectsAccounting.Common.Models
{
    public partial class InvoiceModel
    {
        public int InvoiceId { get; set; }

        public int ProjectId { get; set; }

        public DateTime InvoiceDate { get; set; }
        
        public string Notes { get; set; }

        public string CompanyName { get; set; }

        public string MainAccpuntantName { get; set; }

        public string OwnerName { get; set; }

        public string LocationAddress { get; set; }

        public string Fax { get; set; }

        public string Phone { get; set; }

        public double TaxRate { get; set; }

        public string OfficeRate { get; set; }
        
        public List<InvoicedTaskModel> InvoicedTasks { get; set; }

        public ProjectModel Project { get; set; }
    }
}
