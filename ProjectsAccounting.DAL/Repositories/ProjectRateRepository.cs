using ProjectsAccounting.Common.Models;
using ProjectsAccounting.DAL.DB;
using ProjectsAccounting.DAL.Mappers;
using System.Collections.Generic;
using System.Linq;

namespace ProjectsAccounting.DAL.Repositories
{
    class ProjectRateRepository : RepositoryBase<ProjectsAccountingEntities>
    {
        public List<ProjectRateModel> GetAll(int projectId)
        {
            return this.Context.ProjectRates.Where(r => r.ProjectId == projectId).ToList()
                .Select(p => ProjectRateMapper.ToProjectRateModel(p)).ToList();
        }

        public void Insert(ProjectRateModel model)
        {
            var rate = ProjectRateMapper.ToDBProjectRate(model);
            this.Context.ProjectRates.Add(rate);
            this.Save();
        }
    }
}
