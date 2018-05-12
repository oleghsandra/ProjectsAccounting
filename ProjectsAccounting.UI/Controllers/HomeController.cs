using ProjectsAccounting.Common.Models;
using ProjectsAccounting.TFS.Repositories;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProjectsAccounting.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var r = new TFSProjectsRepository();
            var a = r.GetAll();

            var r1 = new TFSUsersRepository();
            var a1 = r1.GetAll();

            var r2 = new TFSIterationsRepository();
            var r3 = new TFSTasksRepository();
            var tasks = new List<TaskModel>();
            foreach (var project in a)
            {
                var a2 = r2.GetAll(project.PMCID);

                foreach (var iteration in a2)
                {
                    tasks.AddRange(r3.GetAll(iteration.PMCID));
                }
            }
            
            return View();
        }

        public ActionResult Projects()
        {
            return View();
        }

        public ActionResult Users()
        {
            return View();
        }
    }
}