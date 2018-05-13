using ProjectsAccounting.Common.Models;
using ProjectsAccounting.DAL.DB;
using ProjectsAccounting.DAL.Mappers;
using System.Collections.Generic;
using System.Linq;

namespace ProjectsAccounting.DAL.Repositories
{
    public class InvoicesRepository : RepositoryBase<ProjectsAccountingEntities>, IInvoicesRepository
    {
        public List<InvoiceModel> GetAll()
        {
            return this.Context.Invoices.OrderByDescending(i => i.InvoiceDate)
                .Select(i => new { invoice = i, project = i.Projects, tasks = i.InvoicedTasks }).ToList()
                .Select(i => InvoiceMapper.ToInvoiceModel(i.invoice, i.project, i.tasks)).ToList();
        }

        public InvoiceModel Get(int invoiceId)
        {
            var invoice = this.Context.Invoices.FirstOrDefault(i => i.InvoiceId == invoiceId);
            var result = InvoiceMapper.ToInvoiceModel(invoice, invoice.Projects, invoice.InvoicedTasks);
            return result;
        }

        public void Insert(InvoiceModel model)
        {
            var invoice = InvoiceMapper.ToDBInvoice(model);
            this.Context.Invoices.Add(invoice);
            this.Save();
            model.InvoiceId = invoice.InvoiceId;
        }
    }
}
