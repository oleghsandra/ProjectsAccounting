using ProjectsAccounting.Common.Models;
using System.Collections.Generic;

namespace ProjectsAccountingBL.Providers.Abstract
{
    public interface IProjectsProvider
    {
        ProjectModel Get(int projectId);

        List<ProjectModel> GetAll();

        void Synhronize();

        void UpdateCustomerInfo(ProjectModel model);
    }
}
