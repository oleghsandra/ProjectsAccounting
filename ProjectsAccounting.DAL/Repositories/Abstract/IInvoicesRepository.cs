using ProjectsAccounting.Common.Models;
using System.Collections.Generic;

namespace ProjectsAccounting.DAL.Repositories
{
    public interface IInvoicesRepository
    {
        List<InvoiceModel> GetAll();

        void Insert(InvoiceModel model);
    }
}
