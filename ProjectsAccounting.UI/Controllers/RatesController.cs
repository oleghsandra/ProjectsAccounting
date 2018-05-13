using ProjectsAccounting.Common.Models;
using ProjectsAccounting.UI.Models;
using ProjectsAccountingBL.Providers.Abstract;
using System.Linq;
using System.Web.Mvc;

namespace ProjectsAccounting.UI.Controllers
{
    public class RatesController : Controller
    {
        public RatesController(
            IProjectsProvider projectsProvider,
            IProjectRatesProvider projectRatesProvider,
            ICompanyInfoProvider companyInfoProvider,
            IUsersProvider usersProvider)
        {
            this._projectsProvider = projectsProvider;
            this._projectRatesProvider = projectRatesProvider;
            this._companyInfoProvider = companyInfoProvider;
            this._usersProvider = usersProvider;
        }

        private IProjectsProvider _projectsProvider { get; set; }

        private IProjectRatesProvider _projectRatesProvider { get; set; }

        private ICompanyInfoProvider _companyInfoProvider { get; set; }

        private IUsersProvider _usersProvider { get; set; }

        public ActionResult Index()
        {
            var companyInfo = this._companyInfoProvider.GetCompanyInfo();
            var users = this._usersProvider.GetAll();
            var projects = this._projectsProvider.GetAll();
            var pojectRates = this._projectRatesProvider.GetAll();

            var model = new RatesViewModel()
            {
                Users = users,
                ProjectRates = pojectRates,
                CompanyInfo = companyInfo,
                UsersOptions = users.Select(u => new SelectListItem { Text = u.UserName, Value = u.UserId.ToString() }).ToList(),
                ProjectsOptions = projects.Select(u => new SelectListItem { Text = u.ProjectName, Value = u.ProjectId.ToString() }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public JsonResult SaveProjectUserRate(ProjectRateModel model)
        {
            if (model.UserId != 0 || model.ProjectId != 0)
            {
                var exist = this._projectRatesProvider.GetForUserAndProject(model.UserId, model.ProjectId);

                if (exist == null)
                {
                    this._projectRatesProvider.Insert(model);
                }
                else
                {
                    model.ProjectRateId = exist.ProjectRateId;
                    this._projectRatesProvider.Update(model);
                }

                return Json(new { Saved = true });
            }
            else
            {
                return Json(new { Saved = false, ErrorMsg = "Select project and user." });
            }
        }

        [HttpPost]
        public void SaveInternalRate(int userId, double internalRate)
        {
            this._usersProvider.ChangeInternalRate(userId, internalRate);
        }

        [HttpPost]
        public void SynhronizeUsers()
        {
            this._usersProvider.Synhronize();
        }
    }
}