using System.Collections.Generic;
using ProjectsAccounting.TFS.Repositories;
using ProjectsAccounting.Common.Models;
using ProjectsAccountingBL.Providers.Abstract;
using System.Linq;

namespace ProjectAccountingBL.Providers.Implementation
{
    public class TasksProvider : ITasksProvider
    {
        public TasksProvider(ITFSTasksRepository tfsTasksRepository, ITFSUsersRepository tfsUsersRepository)
        {
            this._tfsTasksRepository = tfsTasksRepository;
            this._tfsUsersRepository = tfsUsersRepository;
        }

        private ITFSTasksRepository _tfsTasksRepository { get; set; }

        private ITFSUsersRepository _tfsUsersRepository { get; set; }

        public List<TaskModel> GetAll(string iterationId)
        {
            var users = this._tfsUsersRepository.GetAll();
            var tasks = this._tfsTasksRepository.GetAll(iterationId);

            foreach (var task in tasks)
            {
                task.User = new UserModel();
                var user = users.FirstOrDefault(u => u.PMCID == task.AssignedToUserPMCId);

                if (user != null)
                {
                    task.User.UserName = user.UserName;
                }
            }

            return tasks;
        }
    }
}