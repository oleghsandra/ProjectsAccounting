using ProjectsAccounting.Common.Models;
using ProjectsAccounting.DAL.DB;

namespace ProjectsAccounting.DAL.Mappers
{
    class InvoiceMapper
    {
        public static InvoiceModel ToInvoiceModel(Invoices dbModel)
        {
            return new InvoiceModel()
            {
                InvoiceId = dbModel.InvoiceId,
                ProjectId = dbModel.ProjectId ?? 0,
                InvoiceDate = dbModel.InvoiceDate.GetValueOrDefault(),
                Notes = dbModel.Notes,
                CompanyName = dbModel.CompanyName,
                MainAccpuntantName = dbModel.MainAccpuntantName,
                OwnerName = dbModel.OwnerName,
                LocationAddress = dbModel.LocationAddress,
                Fax = dbModel.Fax,
                Phone = dbModel.Phone,
                TaxRate = dbModel.TaxRate ?? 0,
                OfficeRate = dbModel.OfficeRate,
            };
        }

        public static Invoices ToDBInvoice(InvoiceModel model)
        {
            return new Invoices()
            {
                InvoiceId = model.InvoiceId,
                ProjectId = model.ProjectId,
                InvoiceDate = model.InvoiceDate,
                Notes = model.Notes,
                CompanyName = model.CompanyName,
                MainAccpuntantName = model.MainAccpuntantName,
                OwnerName = model.OwnerName,
                LocationAddress = model.LocationAddress,
                Fax = model.Fax,
                Phone = model.Phone,
                TaxRate = model.TaxRate,
                OfficeRate = model.OfficeRate,
            };
        }
    }
}
