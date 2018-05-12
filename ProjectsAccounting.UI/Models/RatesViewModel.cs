using ProjectsAccounting.Common.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProjectsAccounting.UI.Models
{
    public class RatesViewModel
    {
        public List<UserModel> Users { get; set; }

        public List<ProjectRateModel> ProjectRates { get; set; }

        public List<SelectListItem> ProjectsOptions { get; set; }

        public List<SelectListItem> UsersOptions { get; set; }
    }
}