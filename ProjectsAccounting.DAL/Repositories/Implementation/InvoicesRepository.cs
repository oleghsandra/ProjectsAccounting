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
            return this.Context.Invoices.ToList()
                .Select(i => InvoiceMapper.ToInvoiceModel(i)).ToList();
        }

        public void Insert(InvoiceModel model)
        {
            var invoice = InvoiceMapper.ToDBInvoice(model);
            this.Context.Invoices.Add(invoice);
            this.Save();
        }
    }
}
