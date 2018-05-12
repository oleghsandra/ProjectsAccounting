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
            var projectsRepository = new TFSProjectsRepository();
            var projects = projectsRepository.GetAll();
            
            return View(projects);
        }

        public ActionResult Users()
        {
            var usersRepository = new TFSUsersRepository();
            var users = usersRepository.GetAll();

            var projectsRepository = new TFSProjectsRepository();
            var projects = projectsRepository.GetAll();

            var model = new RatesViewModel()
            {
                Users = users,
                ProjectRates = new List<ProjectRateModel>() { new ProjectRateModel() { ProjectName ="Test", UserName="Oleg", ExternalRate=2.33 } }, //ToDo,
                UsersOptions = users.Select(u => new SelectListItem { Text = u.UserName, Value = u.UserId.ToString() }).ToList(),
                ProjectsOptions = projects.Select(u => new SelectListItem { Text = u.ProjectName, Value = u.ProjectId.ToString() }).ToList()
            };

            return View(model);
        }
    }
}