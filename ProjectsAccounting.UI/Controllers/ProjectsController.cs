using ProjectsAccounting.Common.Models;
using ProjectsAccountingBL.Providers.Abstract;
using System.Web.Mvc;

namespace ProjectsAccounting.UI.Controllers
{
    public class ProjectsController : Controller
    {
        public ProjectsController(IProjectsProvider projectsProvider)
        {
            this._projectsProvider = projectsProvider;
        }

        private IProjectsProvider _projectsProvider { get; set; }

        public ActionResult Index()
        {
            var projects = this._projectsProvider.GetAll();
            return View(projects);
        }

        [HttpPost]
        public void SynhronizeProjects()
        {
            this._projectsProvider.Synhronize();
        }

        [HttpPost]
        public void UpdateProjectCustomerInfo(ProjectModel model)
        {
            this._projectsProvider.UpdateCustomerInfo(model);
        }
    }
}