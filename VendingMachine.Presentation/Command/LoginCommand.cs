using iQuest.VendingMachine.Business.Dependencies;
using iQuest.VendingMachine.Business.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Presentation.Command
{
    public class LoginCommand: ICommand
    {
        private readonly IAuthenticationService authenticationService;
        public IUseCaseFactory useCaseFactory;

        public string Name => "login";

        public string Description => "Get access to administration section.";

        public bool CanExecute => !authenticationService.IsUserAuthenticated;

        public LoginCommand(IAuthenticationService authenticationService, IUseCaseFactory useCaseFactory)
        {
            this.authenticationService = authenticationService;
            this.useCaseFactory = useCaseFactory;
        }

        public void Execute()
        {
            useCaseFactory.Create<LoginUseCase>().Execute();
        }
    }
}
