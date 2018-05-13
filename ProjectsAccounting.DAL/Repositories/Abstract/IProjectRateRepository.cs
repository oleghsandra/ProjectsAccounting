using ProjectsAccounting.Common.Models;
using System.Collections.Generic;

namespace ProjectsAccounting.DAL.Repositories
{
    public interface IProjectRateRepository
    {
        void Insert(ProjectRateModel model);

        ProjectRateModel GetForUserAndProject(int userId, int projectId);

        List<ProjectRateModel> GetForProject(int projectId);

        List<ProjectRateModel> GetAll();

        List<ProjectRateModel> GetForUser(int userId);

        void Update(ProjectRateModel model);
    }
}
