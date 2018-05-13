using ProjectsAccounting.Common.Models;
using ProjectsAccounting.UI.Models;
using ProjectsAccountingBL.Providers.Abstract;
using System.Linq;
using System.Web.Mvc;

namespace ProjectsAccounting.UI.Controllers
{
    public class InvoicingController : Controller
    {
        public InvoicingController(
            IProjectsProvider projectsProvider,
            ICompanyInfoProvider companyInfoProvider,
            IUsersProvider usersProvider)
        {
            this._projectsProvider = projectsProvider;
            this._companyInfoProvider = companyInfoProvider;
            this._usersProvider = usersProvider;
        }

        private IProjectsProvider _projectsProvider { get; set; }

        private ICompanyInfoProvider _companyInfoProvider { get; set; }

        private IUsersProvider _usersProvider { get; set; }

        public ActionResult Index()
        {

            return View();
        }
    }
}