using iQuest.VendingMachine.Business.Dependencies;
using System;
using System.Collections.Generic;
using System.Text;
using VendingMachine.Business.UseCases;

namespace VendingMachine.Presentation.Command
{
    public class ReportCommand:ICommand
    {
        private readonly IAuthenticationService authenticationService;

        private IUseCaseFactory useCaseFactory;

        public string Name => "report";

        public string Description => "Generate reports for the bought items";

        public bool CanExecute => authenticationService.IsUserAuthenticated;

        public ReportCommand(IAuthenticationService authenticationService, IUseCaseFactory useCaseFactory)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.useCaseFactory = useCaseFactory ?? throw new ArgumentNullException(nameof(useCaseFactory));
        }

        public void Execute()
        {
            useCaseFactory.Create<SalesReportUseCase>().Execute();
        }
    }
}
