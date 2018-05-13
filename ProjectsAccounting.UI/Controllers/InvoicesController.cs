using ProjectsAccounting.Common.Models;
using ProjectsAccounting.UI.Models;
using ProjectsAccountingBL.Providers.Abstract;
using System.Linq;
using System.Web.Mvc;

namespace ProjectsAccounting.UI.Controllers
{
    public class InvoicesController : Controller
    {
        public InvoicesController(IInvoicesProvider invoicesProvider)
        {
            this._invoicesProvider = invoicesProvider;
        }

        private IInvoicesProvider _invoicesProvider { get; set; }

        public ActionResult Index()
        {
            var invoices = this._invoicesProvider.GetAll();
            return View(invoices);
        }

        [HttpPost]
        public ActionResult LoadInvoice(int invoiceId)
        {
            var invoice = this._invoicesProvider.Get(invoiceId);
            return PartialView("Invoice", invoice);
        }
    }
}