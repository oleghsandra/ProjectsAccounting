using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsAccounting.Common.Models
{
    public class ProjectModel
    {
        public int ProjectId { get; set; }

        public string ProjectName { get; set; }

        public string PMCID { get; set; }

        public virtual List<ProjectRateModel> ProjectRates { get; set; }
    }
}
