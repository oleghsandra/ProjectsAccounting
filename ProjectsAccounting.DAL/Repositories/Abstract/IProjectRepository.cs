using ProjectsAccounting.Common.Models;
using System.Collections.Generic;

namespace ProjectsAccounting.DAL.Repositories
{
    public interface IProjectRepository
    {
        ProjectModel Get(int projectId);

        List<ProjectModel> GetAll();

        void Insert(ProjectModel model);

        void UpdateCustomerInfo(ProjectModel model);
    }
}
