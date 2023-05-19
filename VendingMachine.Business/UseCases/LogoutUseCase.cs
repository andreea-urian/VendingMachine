using System;
using iQuest.VendingMachine.Business.Authentication;
using iQuest.VendingMachine.Business.Dependencies;

namespace iQuest.VendingMachine.Business.UseCases
{
    public class LogoutUseCase : IUseCase
    {
        private readonly IAuthenticationService authenticationService;

        public LogoutUseCase(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        }

        public void Execute()
        {
            authenticationService.Logout();
        }
    }
}