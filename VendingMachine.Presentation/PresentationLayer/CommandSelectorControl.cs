using System;
using System.Collections.Generic;
using iQuest.VendingMachine.Business.Dependencies;
using VendingMachine.Presentation.Command;

namespace iQuest.VendingMachine.Presentation.PresentationLayer
{
    public class CommandSelectorControl : DisplayBase
    {
        public IEnumerable<ICommand> UseCases { get; set; }
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ICommand Display()
        {
            DisplayUseCases();
            return SelectUseCase();
        }

        private void DisplayUseCases()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Available commands:");
            Console.WriteLine();

            foreach (ICommand useCase in UseCases)
                DisplayUseCase(useCase);
        }

        private static void DisplayUseCase(ICommand useCase)
        {
            ConsoleColor oldColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(useCase.Name);

            Console.ForegroundColor = oldColor;
            log.Info(useCase.Name+" is available");
            Console.WriteLine(" - " + useCase.Description);
        }

        private ICommand SelectUseCase()
        {
            while (true)
            {
                string rawValue = ReadCommandName();
                ICommand selectedUseCase = FindUseCase(rawValue);

                if (selectedUseCase != null)
                    return selectedUseCase;
                log.Error("Invalid command selected");
                DisplayLine("Invalid command. Please try again.", ConsoleColor.Red);
            }
        }

        private ICommand FindUseCase(string rawValue)
        {
            ICommand selectedUseCase = null;

            foreach (ICommand x in UseCases)
            {
                if (x.Name == rawValue)
                {
                    selectedUseCase = x;
                    break;
                }
            }

            return selectedUseCase;
        }

        private string ReadCommandName()
        {
            Console.WriteLine();
            Display("Choose command: ", ConsoleColor.Cyan);
            string rawValue = Console.ReadLine();
            Console.WriteLine();
            log.Info(rawValue + " have been selected");
            return rawValue;
        }
    }
}