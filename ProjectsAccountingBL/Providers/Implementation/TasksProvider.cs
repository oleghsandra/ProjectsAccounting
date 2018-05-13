using System.Collections.Generic;
using ProjectsAccounting.TFS.Repositories;
using ProjectsAccounting.Common.Models;
using ProjectsAccountingBL.Providers.Abstract;

namespace ProjectAccountingBL.Providers.Implementation
{
    public class TasksProvider : ITasksProvider
    {
        public TasksProvider(ITFSTasksRepository tfsTasksRepository)
        {
            this._tfsTasksRepository = tfsTasksRepository;
        }

        private ITFSTasksRepository _tfsTasksRepository { get; set; }

        public List<TaskModel> GetAll(string iterationId)
        {
            return this._tfsTasksRepository.GetAll(iterationId);
        }
    }
}