using ProjectsAccounting.Common.Models;
using ProjectsAccounting.TFS.TFSDB;

namespace ProjectsAccounting.DAL.Mappers
{
    static class ProjectMapper
    {
        public static ProjectModel ToProjectModel(tbl_Project dbModel)
        {
            return new ProjectModel()
            {
                PMCID = dbModel.ProjectId.ToString(),
                ProjectName = dbModel.ProjectName
            };
        }
    }
}
