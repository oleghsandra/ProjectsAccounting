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
                ProjectName = dbModel.ProjectName,
                CustomerName = dbModel.CustomerName,
                CustomerAddress = dbModel.CustomerAddress,
                CustomerEmail = dbModel.CustomerEmail,
                CustomerPhone = dbModel.CustomerPhone,
            };
        }

        public static Projects ToDBProject(ProjectModel model)
        {
            return new Projects()
            {
                PMCID = model.PMCID,
                ProjectId = model.ProjectId,
                ProjectName = model.ProjectName,
                CustomerName = model.CustomerName,
                CustomerAddress = model.CustomerAddress,
                CustomerEmail = model.CustomerEmail,
                CustomerPhone = model.CustomerPhone,
            };
        }
    }
}
