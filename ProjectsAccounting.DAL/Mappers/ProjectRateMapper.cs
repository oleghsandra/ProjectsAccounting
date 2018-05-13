using ProjectsAccounting.Common.Models;
using ProjectsAccounting.DAL.DB;

namespace ProjectsAccounting.DAL.Mappers
{
    class ProjectRateMapper
    {
        public static ProjectRateModel ToProjectRateModel(ProjectRates dbModel)
        {
            return new ProjectRateModel()
            {
                ProjectRateId = dbModel.ProjectRateId,
                ProjectId = dbModel.ProjectId ?? 0,
                UserId = dbModel.UserId ?? 0,
                ExternalRate = dbModel.ExternalRate ?? 0
            };
        }

        public static ProjectRates ToDBProjectRate(ProjectRateModel model)
        {
            return new ProjectRates()
            {
                ProjectId = model.ProjectId,
                UserId = model.UserId,
                ExternalRate = model.ExternalRate
            };
        }
    }
}
