using ProjectsAccounting.Common.Models;
using System.Collections.Generic;

namespace ProjectsAccountingBL.Providers.Abstract
{
    public interface IProjectRatesProvider
    {
        void Insert(ProjectRateModel model);

        ProjectRateModel GetForUserAndProject(int userId, int projectId);

        List<ProjectRateModel> GetForProject(int projectId);

        List<ProjectRateModel> GetAll();

        List<ProjectRateModel> GetForUser(int userId);

        void Update(ProjectRateModel model);
    }
}
