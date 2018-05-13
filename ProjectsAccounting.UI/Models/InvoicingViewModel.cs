using ProjectsAccounting.Common.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProjectsAccounting.UI.Models
{
    public class InvoicingViewModel
    {
        public CompanyInfoModel CompanyInfo { get; set; }
        
        public List<SelectListItem> ProjectsOptions { get; set; }
    }
}