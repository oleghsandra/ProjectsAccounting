using ProjectsAccounting.Common.Models;
using ProjectsAccounting.TFS.Repositories;
using ProjectsAccounting.UI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProjectsAccounting.UI.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        public ActionResult Index()
        {
            return View();
        }
    }
}