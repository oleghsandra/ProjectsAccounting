using ProjectsAccounting.Common.Models;
using System.Collections.Generic;

namespace ProjectsAccounting.DAL.Repositories
{
    public interface IInvoicedTasksRepository
    {
        List<InvoicedTaskModel> GetAll(int invoiceId);

        void Insert(InvoicedTaskModel model);
    }
}
