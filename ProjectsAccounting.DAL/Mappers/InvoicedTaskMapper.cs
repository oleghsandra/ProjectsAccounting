using ProjectsAccounting.Common.Models;
using ProjectsAccounting.DAL.DB;

namespace ProjectsAccounting.DAL.Mappers
{
    class InvoicedTaskMapper
    {
        public static InvoicedTaskModel ToInvoicedTaskModel(InvoicedTasks dbModel)
        {
            return new InvoicedTaskModel()
            {
                InvoicedTaskId = dbModel.InvoicedTaskId,
                InvoiceId = dbModel.InvoiceId ?? 0,
                UserId = dbModel.UserId ?? 0,
                UserInternalRate = dbModel.UserInternalRate ?? 0,
                UserExternalRate = dbModel.UserExternalRate ?? 0,
                ReportedHours = dbModel.ReportedHours ?? 0,
                TaskName = dbModel.TaskName,
            };
        }

        public static InvoicedTasks ToDBInvoicedTask(InvoicedTaskModel model)
        {
            return new InvoicedTasks()
            {
                InvoicedTaskId = model.InvoicedTaskId,
                InvoiceId = model.InvoiceId,
                UserId = model.UserId,
                UserInternalRate = model.UserInternalRate,
                UserExternalRate = model.UserExternalRate,
                ReportedHours = model.ReportedHours,
                TaskName = model.TaskName,
            };
        }
    }
}
