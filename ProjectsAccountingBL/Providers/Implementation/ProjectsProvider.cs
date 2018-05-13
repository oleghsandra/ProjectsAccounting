using ProjectsAccounting.Common.Models;
using ProjectsAccounting.DAL.Repositories;
using ProjectsAccounting.TFS.Repositories;
using ProjectsAccountingBL.Providers.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace ProjectsAccountingBL.Providers.Implementation
{
    public class ProjectsProvider : IProjectsProvider
    {
        public ProjectsProvider(IProjectRepository projectRepository, ITFSProjectsRepository tfsProjectsRepository)
        {
            this._projectRepository = projectRepository;
            this._tfsProjectsRepository = tfsProjectsRepository;
        }

        private IProjectRepository _projectRepository { get; set; }

        private ITFSProjectsRepository _tfsProjectsRepository { get; set; }

        public List<ProjectModel> GetAll()
        {
            return this._projectRepository.GetAll();
        }

        public void UpdateCustomerInfo(ProjectModel model)
        {
            this._projectRepository.UpdateCustomerInfo(model);
        }

        public void Synhronize()
        {
            var ownProjects = this._projectRepository.GetAll();
            var tfsProjects = this._tfsProjectsRepository.GetAll();

            foreach (var tfsProject in tfsProjects)
            {
                if (!ownProjects.Any(p => p.PMCID == tfsProject.PMCID))
                {
                    this._projectRepository.Insert(tfsProject);
                }
            }
        }
    }
}
