using ProjectsAccounting.Common.Models;
using System.Collections.Generic;

namespace ProjectsAccountingBL.Providers.Abstract
{
    public interface IInvoicesProvider
    {
        List<InvoiceModel> GetAll();

        void SaveInvoice(InvoiceModel invoiceModel);

        InvoiceModel Get(int invoiceId);
    }
}
