﻿using ProjectsAccounting.Common.Models;
using ProjectsAccounting.DAL.DB;
using ProjectsAccounting.DAL.Mappers;
using System.Collections.Generic;
using System.Linq;

namespace ProjectsAccounting.DAL.Repositories
{
    public class InvoicedTasksRepository : RepositoryBase<ProjectsAccountingEntities>, IInvoicedTasksRepository
    {
        /// <summary>
        /// Get all invoiced tasks
        /// </summary>
        /// <param name="invoiceId"></param>
        /// <returns></returns>
        public List<InvoicedTaskModel> GetAll(int invoiceId)
        {
            return this.Context.InvoicedTasks.Where(i => i.InvoiceId == invoiceId).ToList()
                .Select(i => InvoicedTaskMapper.ToInvoicedTaskModel(i)).ToList();
        }
        
        /// <summary>
        /// Insert invoiced task
        /// </summary>
        public void Insert(InvoicedTaskModel model)
        {
            var invoiceTask = InvoicedTaskMapper.ToDBInvoicedTask(model);
            this.Context.InvoicedTasks.Add(invoiceTask);
            this.Save();
        }

        /// <summary>
        /// Insert invoiced tasks range
        /// </summary>
        public void InsertRange(List<InvoicedTaskModel> models)
        {
            var invoiceTasks = models.Select(t => InvoicedTaskMapper.ToDBInvoicedTask(t));
            this.Context.InvoicedTasks.AddRange(invoiceTasks);
            this.Save();
        }
    }
}