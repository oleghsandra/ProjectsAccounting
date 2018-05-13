using ProjectsAccounting.Common;
using ProjectsAccounting.Common.Models;
using ProjectsAccounting.DAL.DB;
using ProjectsAccounting.DAL.Mappers;
using System.Collections.Generic;
using System.Linq;

namespace ProjectsAccounting.DAL.Repositories
{
    public class ProjectRepository : RepositoryBase<ProjectsAccountingEntities>, IProjectRepository
    {
        public List<ProjectModel> GetAll()
        {
            return this.Context.Projects.ToList()
                .Select(p => ProjectMapper.ToProjectModel(p)).ToList();
        }

        public void Insert(ProjectModel model)
        {
            var project = ProjectMapper.ToDBProject(model);
            this.Context.Projects.Add(project);
            this.Save();
        }

        public void UpdateCustomerInfo(ProjectModel model)
        {
            var project = this.Context.Projects.FirstOrDefault(p => p.ProjectId == model.ProjectId);
            project.CustomerName = model.CustomerName;
            project.CustomerAddress = model.CustomerAddress;
            project.CustomerEmail = model.CustomerEmail;
            project.CustomerPhone = model.CustomerPhone;

            this.Save();
        }
    }
}
