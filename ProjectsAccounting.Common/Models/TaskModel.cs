using System.Collections.Generic;

namespace ProjectsAccounting.Common.Models
{
    public class TaskModel
    {
        public int TaskId { get; set; }

        public string Name { get; set; }

        public string PMCID { get; set; }

        public string AssignedToUserPMCId { get; set; }

        public string Description { get; set; }

        public double HoursReported { get; set; }
    }
}
