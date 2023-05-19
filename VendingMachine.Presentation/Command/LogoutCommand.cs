using iQuest.VendingMachine.Business.Dependencies;
using iQuest.VendingMachine.Business.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Presentation.Command
{
    public class LogoutCommand:ICommand
    {
        private readonly IAuthenticationService authenticationService;
        public IUseCaseFactory useCaseFactory;

        public string Name => "logout";

        public string Description => "Restrict access to administration section.";

        public bool CanExecute => authenticationService.IsUserAuthenticated;

        public LogoutCommand(IAuthenticationService authenticationService, IUseCaseFactory useCaseFactory)
        {
            this.authenticationService = authenticationService;
            this.useCaseFactory = useCaseFactory;
        }

        public void Execute()
        {
            useCaseFactory.Create<LogoutUseCase>().Execute();
        }
    }
}
