using ProjectAccountingBL.Providers.Implementation;
using ProjectsAccounting.DAL.Repositories;
using ProjectsAccounting.TFS.Repositories;
using ProjectsAccountingBL.Providers.Abstract;
using ProjectsAccountingBL.Providers.Implementation;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace ProjectsAccounting.UI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ICompanyInfoRepository, CompanyInfoRepository>();
            container.RegisterType<IInvoicedTasksRepository, InvoicedTasksRepository>();
            container.RegisterType<IInvoicesRepository, InvoicesRepository>();
            container.RegisterType<IProjectRateRepository, ProjectRateRepository>();
            container.RegisterType<IProjectRepository, ProjectRepository>();
            container.RegisterType<IUsersRepository, UsersRepository>();

            container.RegisterType<ITFSIterationsRepository, TFSIterationsRepository>();
            container.RegisterType<ITFSProjectsRepository, TFSProjectsRepository>();
            container.RegisterType<ITFSTasksRepository, TFSTasksRepository>();
            container.RegisterType<ITFSUsersRepository, TFSUsersRepository>();

            container.RegisterType<IIterationsProvider, IterationsProvider>();
            container.RegisterType<IProjectRatesProvider, ProjectRatesProvider>();
            container.RegisterType<IProjectsProvider, ProjectsProvider>();
            container.RegisterType<ITasksProvider, TasksProvider>();
            container.RegisterType<IUsersProvider, UsersProvider>();
            container.RegisterType<ICompanyInfoProvider, CompanyInfoProvider>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}