using System.Collections.Generic;
using System.Linq;
using ProjectsAccounting.DAL.Repositories;
using ProjectsAccounting.TFS.Repositories;
using ProjectsAccounting.Common.Models;
using ProjectsAccountingBL.Providers.Abstract;
using System.Transactions;
using System;

namespace ProjectAccountingBL.Providers.Implementation
{
    public class InvoicesProvider : IInvoicesProvider
    {
        public InvoicesProvider(
            IInvoicedTasksRepository invoicedTasksRepository, 
            IInvoicesRepository invoicesRepository,
            IUsersRepository usersRepository,
            IProjectRateRepository projectRateRepository,
            ICompanyInfoRepository companyInfoRepository,
            IProjectRepository projectRepository,
            ITFSTasksRepository tfsTasksRepository)
        {
            this._invoicedTasksRepository = invoicedTasksRepository;
            this._invoicesRepository = invoicesRepository;
            this._usersRepository = usersRepository;
            this._projectRateRepository = projectRateRepository;
            this._companyInfoRepository = companyInfoRepository;
            this._projectRepository = projectRepository;
            this._tfsTasksRepository = tfsTasksRepository;
        }

        private IInvoicedTasksRepository _invoicedTasksRepository { get; set; }

        private IInvoicesRepository _invoicesRepository { get; set; }

        private IUsersRepository _usersRepository { get; set; }

        private IProjectRateRepository _projectRateRepository { get; set; }
        
        private ICompanyInfoRepository _companyInfoRepository { get; set; }

        private IProjectRepository _projectRepository { get; set; }

        private ITFSTasksRepository _tfsTasksRepository { get; set; }

        public InvoiceModel Get(int invoiceId)
        {
            return this._invoicesRepository.Get(invoiceId);
        }

        public List<InvoiceModel> GetAll()
        {
            return this._invoicesRepository.GetAll();
        }

        public void SaveInvoice(InvoiceModel invoiceModel)
        {
            var users = this._usersRepository.GetAll();
            var project = this._projectRepository.Get(invoiceModel.ProjectId);
            var rates = this._projectRateRepository.GetForProject(invoiceModel.ProjectId);
            var tasks = this._tfsTasksRepository.GetAll(invoiceModel.IterationId.ToString());
            var companyInfo = this._companyInfoRepository.GetCompanyInfo();

            this.FillCompanyInfo(invoiceModel, companyInfo);
            this.FillProjectCustomerInfo(invoiceModel, project);

            using (var scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                this._invoicesRepository.Insert(invoiceModel);
                this.FillInvoicedTasks(invoiceModel, users, tasks, rates);
                this._invoicedTasksRepository.InsertRange(invoiceModel.InvoicedTasks);

                //The Transaction will be completed
                scope.Complete();
            }
        }

        private void FillInvoicedTasks(
            InvoiceModel invoiceModel,
            List<UserModel> users, 
            List<TaskModel> tasks,
            List<ProjectRateModel> rates)
        {
            invoiceModel.InvoicedTasks = new List<InvoicedTaskModel>();

            foreach (var task in tasks)
            {
                var internalRate = 0.0;
                var externalRate = 0.0;

                var user = users.FirstOrDefault(u => u.PMCID == task.AssignedToUserPMCId);
                if (user != null)
                {
                    internalRate = Math.Round(user.InternalRate, 2);
                    var projectUserRate = rates.FirstOrDefault(r => r.UserId == user.UserId);

                    if (projectUserRate != null)
                    {
                        externalRate = Math.Round(projectUserRate.ExternalRate, 2);
                    }
                }

                invoiceModel.InvoicedTasks.Add(new InvoicedTaskModel() {
                    InvoiceId = invoiceModel.InvoiceId,
                    UserId = user == null ? 0 : user.UserId,
                    ReportedHours = task.HoursReported,
                    UserInternalRate = internalRate,
                    UserExternalRate = externalRate,
                    TaskName = task.Name
                });
            }
        }

        private void FillCompanyInfo(InvoiceModel invoiceModel, CompanyInfoModel companyInfo)
        {
            invoiceModel.CompanyName = companyInfo.CompanyName;
            invoiceModel.MainAccpuntantName = companyInfo.MainAccpuntantName;
            invoiceModel.OwnerName = companyInfo.OwnerName;
            invoiceModel.LocationAddress = companyInfo.LocationAddress;
            invoiceModel.Fax = companyInfo.Fax;
            invoiceModel.Phone = companyInfo.Phone;
            invoiceModel.TaxRate = companyInfo.TaxRate;
            invoiceModel.OfficeRate = companyInfo.OfficeRate;
        }

        private void FillProjectCustomerInfo(InvoiceModel invoiceModel, ProjectModel project)
        {
            invoiceModel.CustomerName = project.CustomerName;
            invoiceModel.CustomerAddress = project.CustomerAddress;
            invoiceModel.CustomerEmail = project.CustomerEmail;
            invoiceModel.CustomerPhone = project.CustomerPhone;
        }
    }
}