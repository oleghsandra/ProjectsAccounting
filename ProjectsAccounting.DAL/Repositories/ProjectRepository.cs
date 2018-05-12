using ProjectsAccounting.Common;
using ProjectsAccounting.Common.Models;
using ProjectsAccounting.DAL.DB;
using ProjectsAccounting.DAL.Mappers;
using System.Collections.Generic;
using System.Linq;

namespace ProjectsAccounting.DAL.Repositories
{
    class ProjectRepository : RepositoryBase<ProjectsAccountingEntities>
    {
        public List<ProjectModel> GetAll()
        {
            return this.Context.Projects.ToList()
                .Select(p => ProjectMapper.ToProjectModel(p)).ToList();
        }
    }
}
