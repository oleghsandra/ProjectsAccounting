using ProjectsAccounting.Common.Models;
using System.Collections.Generic;

namespace ProjectsAccountingBL.Providers.Abstract
{
    public interface IProjectsProvider
    {
        List<ProjectModel> GetAll();

        void Synhronize();

        void UpdateCustomerInfo(ProjectModel model);
    }
}
