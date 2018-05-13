using ProjectsAccounting.Common.Models;
using System.Collections.Generic;

namespace ProjectsAccountingBL.Providers.Abstract
{
    public interface ITasksProvider
    {
        List<TaskModel> GetAll(string iterationId);
    }
}
