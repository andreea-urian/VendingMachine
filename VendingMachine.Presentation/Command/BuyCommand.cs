using iQuest.VendingMachine.Business.Dependencies;
using iQuest.VendingMachine.Business.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Presentation.Command
{
    public class BuyCommand: ICommand
    {
        private readonly IAuthenticationService authenticationService;
        public IUseCaseFactory useCaseFactory;

        public string Name => "buy";

        public string Description => "You can buy a product that we have in stock.";

        public bool CanExecute => !authenticationService.IsUserAuthenticated;

       
        public BuyCommand(IAuthenticationService authenticationService, IUseCaseFactory useCaseFactory)
        {
            this.authenticationService = authenticationService;
            this.useCaseFactory = useCaseFactory;
        }

        public void Execute()
        {
            useCaseFactory.Create<BuyUseCase>().Execute();
        }
    }
}
