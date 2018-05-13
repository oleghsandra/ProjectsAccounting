using System.Collections.Generic;
using ProjectsAccounting.Common.Models;

namespace ProjectsAccounting.TFS.Repositories
{
    public interface ITFSTasksRepository
    {
        List<TaskModel> GetAll(string iterationId);
    }
}

