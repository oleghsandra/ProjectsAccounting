using ProjectsAccounting.TFS.TFSDB;
using System.Collections.Generic;
using System.Linq;
using ProjectsAccounting.Common;
using ProjectsAccounting.Common.Models;
using System;

namespace ProjectsAccounting.TFS.Repositories
{
    public class TFSTasksRepository : RepositoryBase<Tfs_DefaultCollectionEntities>
    {
        public List<TaskModel> GetAll(string iterationId)
        {
            var iterationIdNumber = Convert.ToInt32(iterationId);

            var result = from task in this.Context.vw_denorm_WorkItemCoreLatest
                         let reportedField = this.Context.WorkItemLongTexts
                            .Where(f => f.ID == task.Id && f.FldID == 52)
                            .OrderByDescending(f => f.AddedDate)
                            .FirstOrDefault()

                         let nameField = this.Context.WorkItemLongTexts
                            .Where(f => f.ID == task.Id && f.FldID == 1)
                            .OrderByDescending(f => f.AddedDate)
                            .FirstOrDefault()

                         where task.IterationId == iterationIdNumber
                         select new { task, reportedField, nameField };
            
            return result.ToList().Select(i => new TaskModel()
            {
               PMCID = i.task.Id.ToString(),
               AssignedToUserPMCId = i.task.System_AssignedTo_TeamFoundationId == null 
                ? "" : i.task.System_AssignedTo_TeamFoundationId.ToString(),

               Name = i.nameField == null ? "" : i.nameField.Words,
               Description = i.reportedField == null ? "" : i.reportedField.Words,
               HoursReported = i.reportedField == null ? 0.0 : (double.TryParse(i.reportedField.Words, out double value) ? value : 0)
            }).ToList();
        }
    }
}

