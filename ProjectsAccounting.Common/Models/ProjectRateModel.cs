using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsAccounting.Common.Models
{
    public class ProjectRateModel
    {
        public int ProjectRateId { get; set; }

        public int ProjectId { get; set; }

        public string ProjectName { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }

        public double ExternalRate { get; set; }

        public ProjectModel Project { get; set; }
        public UserModel User { get; set; }
    }
}
