using ProjectsAccounting.Common.Models;
using ProjectsAccounting.UI.Models;
using ProjectsAccountingBL.Providers.Abstract;
using System.Linq;
using System.Web.Mvc;

namespace ProjectsAccounting.UI.Controllers
{
    public class InvoicesController : Controller
    {
        public InvoicesController(IInvoicesProvider invoicesProvider, IUsersProvider usersProvider)
        {
            this._invoicesProvider = invoicesProvider;
            this._usersProvider = usersProvider;
        }

        private IInvoicesProvider _invoicesProvider { get; set; }

        private IUsersProvider _usersProvider { get; set; }

        public ActionResult Index()
        {
            var invoices = this._invoicesProvider.GetAll();
            return View(invoices);
        }

        [HttpPost]
        public ActionResult LoadInvoice(int invoiceId)
        {
            var users = this._usersProvider.GetAll();
            var invoice = this._invoicesProvider.Get(invoiceId);
            var viewModel = new InvoiceViewModel(users, invoice);

            return PartialView("Invoice", viewModel);
        }
    }
}