namespace ProjectsAccounting.Common.Models
{
    public class InvoicedTaskModel
    {
        public int InvoicedTaskId { get; set; }

        public int InvoiceId { get; set; }

        public int UserId { get; set; }

        public double UserExternalRate { get; set; }

        public double UserInternalRate { get; set; }

        public double ReportedHours { get; set; }

        public string TaskName { get; set; }

        public virtual InvoiceModel Invoice { get; set; }

        public virtual UserModel User { get; set; }
    }
}
