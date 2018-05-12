using ProjectsAccounting.Common.Models;
using ProjectsAccounting.DAL.DB;

namespace ProjectsAccounting.DAL.Mappers
{
    static class ProjectMapper
    {
        public static ProjectModel ToProjectModel(Projects dbModel)
        {
            return new ProjectModel()
            {
                PMCID = dbModel.PMCID,
                ProjectId = dbModel.ProjectId,
                ProjectName = dbModel.ProjectName
            };
        }
    }
}
