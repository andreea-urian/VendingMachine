using System;
using iQuest.VendingMachine.Business.Exceptions;
using iQuest.VendingMachine.Business.Dependencies;
using iQuest.VendingMachine.Business.Authentication;
using VendingMachine.Business.Dependencies;

namespace iQuest.VendingMachine.Business.UseCases
{
    public class LoginUseCase : IUseCase
    {
        private readonly IAuthenticationService authenticationService;
        private readonly ILoginView loginView;

        public LoginUseCase(IAuthenticationService authenticationService, ILoginView loginView)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.loginView = loginView ?? throw new ArgumentNullException(nameof(loginView));
        }

        public void Execute()
        {
            string password = loginView.AskForPassword();
            authenticationService.Login(password);
        }
    }
}