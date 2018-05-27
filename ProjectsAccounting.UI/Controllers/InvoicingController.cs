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
            IUsersProvider usersProvider,
            IIterationsProvider iterationsProvider,
            ITasksProvider tasksProvider,
            IInvoicesProvider invoicesProvider)
        {
            this._projectsProvider = projectsProvider;
            this._usersProvider = usersProvider;
            this._iterationsProvider = iterationsProvider;
            this._tasksProvider = tasksProvider;
            this._invoicesProvider = invoicesProvider;
        }

        private IProjectsProvider _projectsProvider { get; set; }

        private IUsersProvider _usersProvider { get; set; }

        private IIterationsProvider _iterationsProvider { get; set; }

        private ITasksProvider _tasksProvider { get; set; }

        private IInvoicesProvider _invoicesProvider { get; set; }

        public ActionResult Index()
        {
            var projects = this._projectsProvider.GetAll().Select(u => new SelectListItem { Text = u.ProjectName, Value = u.ProjectId.ToString() }).ToList();
            projects.Insert(0, new SelectListItem() { Text = "", Value = "" });

            var model = new InvoicingViewModel()
            {
                ProjectsOptions = projects
            };

            return View(model);
        }

        /// <summary>
        /// Load all iterations for projects
        /// </summary>
        [HttpPost]
        public ActionResult LoadIterations(int projectId)
        {
            var project = this._projectsProvider.Get(projectId);
            var iterations = this._iterationsProvider.GetAll(project.PMCID).Select(u => new SelectListItem { Text = u.Name, Value = u.PMCID }).ToList();
            iterations.Insert(0, new SelectListItem() { Text = "", Value = "" });

            return PartialView("IterationsList", iterations);
        }

        /// <summary>
        /// Load all tasks for iteration
        /// </summary>
        [HttpPost]
        public ActionResult LoadTasks(string iterationId)
        {
            var tasks = this._tasksProvider.GetAll(iterationId);
            return PartialView("InvoicedTasks", tasks);
        }

        /// <summary>
        /// Insert invoice
        /// </summary>
        [HttpPost]
        public void SaveInvoice(InvoiceModel invoiceModel)
        {
            this._invoicesProvider.SaveInvoice(invoiceModel);
        }
    }
}