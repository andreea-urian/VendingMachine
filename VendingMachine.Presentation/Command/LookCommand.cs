using iQuest.VendingMachine.Business;
using iQuest.VendingMachine.Business.Dependencies;
using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Presentation.Command
{
    public class LookCommand:ICommand
    {
        private readonly IAuthenticationService authenticationService;
        public IUseCaseFactory useCaseFactory;

        public string Name => "look";

        public string Description => "You can see all the product we have in stock.";

        public bool CanExecute => true;

        public LookCommand(IAuthenticationService authenticationService, IUseCaseFactory useCaseFactory)
        {
            this.authenticationService = authenticationService;
            this.useCaseFactory = useCaseFactory;
        }

        public void Execute()
        {
            useCaseFactory.Create<LookUseCase>().Execute();
        }
    }
}
