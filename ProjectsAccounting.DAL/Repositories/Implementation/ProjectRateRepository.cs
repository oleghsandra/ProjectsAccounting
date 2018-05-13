using ProjectsAccounting.Common.Models;
using ProjectsAccounting.DAL.DB;
using ProjectsAccounting.DAL.Mappers;
using System.Collections.Generic;
using System.Linq;

namespace ProjectsAccounting.DAL.Repositories
{
    public class ProjectRateRepository : RepositoryBase<ProjectsAccountingEntities>, IProjectRateRepository
    {
        public List<ProjectRateModel> GetAll()
        {
            return this.Context.ProjectRates.Select(r => new { rate = r, project = r.Projects, user = r.Users }).ToList()
                .Select(p => new ProjectRateModel()
                {
                    ProjectId = p.rate.ProjectId ?? 0,
                    UserId = p.rate.UserId ?? 0,
                    ExternalRate = p.rate.ExternalRate ?? 0,
                    Project = ProjectMapper.ToProjectModel(p.project),
                    User = UserMapper.ToUserModel(p.user),
                }).ToList();
        }

        public List<ProjectRateModel> GetForUser(int userId)
        {
            return this.Context.ProjectRates.Where(r => r.UserId == userId).ToList()
                .Select(p => ProjectRateMapper.ToProjectRateModel(p)).ToList();
        }

        public List<ProjectRateModel> GetForProject(int projectId)
        {
            return this.Context.ProjectRates.Where(r => r.ProjectId == projectId).ToList()
                .Select(p => ProjectRateMapper.ToProjectRateModel(p)).ToList();
        }

        public ProjectRateModel GetForUserAndProject(int userId, int projectId)
        {
            return this.Context.ProjectRates.Where(r => r.ProjectId == projectId && r.UserId == userId).ToList()
                .Select(p => ProjectRateMapper.ToProjectRateModel(p)).FirstOrDefault();
        }

        public void Insert(ProjectRateModel model)
        {
            var rate = ProjectRateMapper.ToDBProjectRate(model);
            this.Context.ProjectRates.Add(rate);
            this.Save();
        }

        public void Update(ProjectRateModel model)
        {
            var rate = this.Context.ProjectRates.FirstOrDefault(r => r.ProjectRateId == model.ProjectRateId);
            rate.ExternalRate = model.ExternalRate;
            this.Save();
        }
    }
}
