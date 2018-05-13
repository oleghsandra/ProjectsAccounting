using ProjectsAccounting.Common.Models;
using ProjectsAccounting.DAL.Repositories;
using ProjectsAccountingBL.Providers.Abstract;
using System.Collections.Generic;

namespace ProjectsAccountingBL.Providers.Implementation
{
    public class ProjectRatesProvider : IProjectRatesProvider
    {
        public ProjectRatesProvider(IProjectRateRepository projectRateRepository)
        {
            this._projectRateRepository = projectRateRepository;
        }

        private IProjectRateRepository _projectRateRepository { get; set; }

        public List<ProjectRateModel> GetAll()
        {
            return this._projectRateRepository.GetAll();
        }

        public List<ProjectRateModel> GetForUser(int userId)
        {
            return this._projectRateRepository.GetForUser(userId);
        }

        public List<ProjectRateModel> GetForProject(int projectId)
        {
            return this._projectRateRepository.GetForProject(projectId);
        }

        public ProjectRateModel GetForUserAndProject(int userId, int projectId)
        {
            return this._projectRateRepository.GetForUserAndProject(userId, projectId);
        }

        public void Insert(ProjectRateModel model)
        {
            this._projectRateRepository.Insert(model);
        }

        public void Update(ProjectRateModel model)
        {
            this._projectRateRepository.Update(model);
        }
    }
}