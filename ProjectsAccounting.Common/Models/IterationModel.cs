namespace ProjectsAccounting.Common.Models
{
    public class IterationModel
    {
        public int IterationId { get; set; }

        public string Name { get; set; }

        public string PMCID { get; set; }

        public int ProjectId { get; set; }

        public ProjectModel Project { get; set; }
    }
}
