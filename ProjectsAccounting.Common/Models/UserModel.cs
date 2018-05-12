using System.Collections.Generic;

namespace ProjectsAccounting.Common.Models
{
    public class UserModel
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string FullName { get; set; }

        public string PMCID { get; set; }

        public double InternalRate { get; set; }

        public virtual List<ProjectModel> Projects { get; set; }

        public virtual List<ProjectRateModel> ProjectsRates { get; set; }
    }
}
