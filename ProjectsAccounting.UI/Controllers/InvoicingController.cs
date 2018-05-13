using ProjectsAccounting.Common.Models;
using ProjectsAccounting.UI.Models;
using ProjectsAccountingBL.Providers.Abstract;
using System.Linq;
using System.Web.Mvc;

namespace ProjectsAccounting.UI.Controllers
{
    public class InvoicesController : Controller
    {
        public InvoicesController()
        {

        }
        
        public ActionResult Index()
        {
            return View();
        }
    }
}