using System;
using System.Collections.Generic;
using iQuest.VendingMachine.Business.Exceptions;
using iQuest.VendingMachine.Business.Dependencies;
using VendingMachine.Business.Dependencies;
using VendingMachine.Presentation.Command;

namespace iQuest.VendingMachine.Business
{
    public class VendingMachineApplication:IConsoleApplication
    {
        private readonly List<ICommand> useCases;
        private readonly IMainView mainView;

        public VendingMachineApplication(IEnumerable<ICommand> useCases, IMainView mainView)
        {
            this.useCases = new List<ICommand>(useCases) ?? throw new ArgumentNullException(nameof(useCases));
            this.mainView = mainView ?? throw new ArgumentNullException(nameof(mainView));
        }

        public void Run()
        {
            mainView.DisplayApplicationHeader();

            while (true)
            {
                List<ICommand> availableUseCases = GetExecutableUseCases();
                try
                {
                    ICommand useCase = mainView.ChooseCommand(availableUseCases);
                    useCase.Execute();
                }
                catch (InvalidColumnException e)
                {
                    mainView.DisplayError(e.ToString(), ConsoleColor.Red);
                }
                catch (InsufficentStockException e2)
                {
                    mainView.DisplayError(e2.ToString(), ConsoleColor.Red);
                }
                catch(CancelException e3)
                {
                    mainView.DisplayError(e3.ToString(), ConsoleColor.Red);

                }

            }
        }

        private List<ICommand> GetExecutableUseCases()
        {
            List<ICommand> executableUseCases = new List<ICommand>();

            foreach (ICommand useCase in useCases)
            {
                if (useCase.CanExecute)
                    executableUseCases.Add(useCase);
            }

            return executableUseCases;
        }
    }
}