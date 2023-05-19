using Autofac;
using System.Collections.Generic;
using iQuest.VendingMachine.Business.Authentication;
using iQuest.VendingMachine.Presentation.PresentationLayer;
using iQuest.VendingMachine.Business.UseCases;
using iQuest.VendingMachine.DataAccess.Repository;
using iQuest.VendingMachine.Business.Dependencies;
using iQuest.VendingMachine.Presentation;
using iQuest.VendingMachine.Business.Payment;
using VendingMachine.Presentation.Repository;
using iQuest.VendingMachine.Business;
using VendingMachine.Business.Dependencies;
using System.Reflection;
using VendingMachine.Presentation.Command;
using VendingMachine.Business.UseCases;
using VendingMachine.Business.Reports;
using VendingMachine.Presentation;
using VendingMachine.DataAccess.Repository;
using VendingMachine.DataAccess.EntityFrameworkRepository;

namespace iQuest.VendingMachine
{
    internal class Bootstrapper
    {
        public void Run()
        {
            var container = BuildApplication().BeginLifetimeScope();
            IConsoleApplication consoleApplication = container.Resolve<VendingMachineApplication>();

            consoleApplication.Run();
        }

        public static IContainer BuildApplication()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MainView>().As<IMainView>();
            builder.RegisterType<LoginView>().As<ILoginView>();
            builder.RegisterType<VendingMachineDBContext>().AsSelf();
            builder.RegisterType<EFProductRepository>().As<IProductRepository>();
            builder.RegisterType<EFSaleRepository>().As<ISalesRepository>();
            builder.RegisterType<ShelfView>().As<IShelfView>();
            builder.RegisterType<BuyView>().As<IBuyView>();
            builder.RegisterType<ReportView>().As<IReportView>();
            builder.RegisterType<SalesRepository>().As<ISalesRepository>();
            builder.RegisterType<CardPaymentTerminal>().As<ICardPaymentTerminal>();
            builder.RegisterType<CashPaymentTerminal>().As<ICashPaymentTerminal>();
            builder.RegisterType<CardPayment>().As<IPaymentAlgorithm>();
            builder.RegisterType<CashPayment>().As<IPaymentAlgorithm>();
            builder.RegisterType<PaymentUseCase>().AsSelf();
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().SingleInstance();
            builder.RegisterType<LoginUseCase>().AsSelf();
            builder.RegisterType<BuyUseCase>().AsSelf();
            builder.RegisterType<LookUseCase>().AsSelf();
            builder.RegisterType<LogoutUseCase>().AsSelf();
            builder.RegisterType<SalesReportUseCase>().AsSelf();
            builder.RegisterType<SalesReport>().AsSelf();
            builder.RegisterType<BuyCommand>().As<ICommand>();
            builder.RegisterType<LoginCommand>().As<ICommand>();
            builder.RegisterType<LookCommand>().As<ICommand>();
            builder.RegisterType<LogoutCommand>().As<ICommand>(); 
            builder.RegisterType<ReportCommand>().As<ICommand>();
            builder.RegisterType<UseCaseFactory>().As<IUseCaseFactory>();
           
            builder.RegisterType<VendingMachineApplication>().AsSelf();

            return builder.Build();
        }
    }
}