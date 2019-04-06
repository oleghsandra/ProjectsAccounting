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

        public int UserId { get; set; }

        public double ExternalRate { get; set; }

        public ProjectModel Project { get; set; }
        public UserModel User { get; set; }

        public UserModel UserModel
        {
            get => default(UserModel);
            set
            {
            }
        }

        public ProjectModel ProjectModel
        {
            get => default(ProjectModel);
            set
            {
            }
        }
    }
}
