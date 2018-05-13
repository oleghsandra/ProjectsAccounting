namespace ProjectsAccounting.Common.Models
{
    public partial class CompanyInfoModel
    {
        public int CompanyId { get; set; }

        public string CompanyName { get; set; }

        public string MainAccpuntantName { get; set; }

        public string OwnerName { get; set; }

        public string LocationAddress { get; set; }

        public string Fax { get; set; }

        public string Phone { get; set; }

        public double TaxRate { get; set; }

        public double OfficeRate { get; set; }
    }
}
