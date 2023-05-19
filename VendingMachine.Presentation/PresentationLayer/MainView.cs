using System;
using System.Collections.Generic;
using iQuest.VendingMachine.Business.Dependencies;
using VendingMachine.Business.Dependencies;
using VendingMachine.Presentation.Command;

namespace iQuest.VendingMachine.Presentation.PresentationLayer
{
    public class MainView : DisplayBase, IMainView
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void DisplayApplicationHeader()
        {
            ApplicationHeaderControl applicationHeaderControl = new ApplicationHeaderControl();
            applicationHeaderControl.Display();
        }

        public ICommand ChooseCommand(IEnumerable<ICommand> useCases)
        {
            CommandSelectorControl commandSelectorControl = new CommandSelectorControl
            {
                UseCases = useCases
            };
            return commandSelectorControl.Display();
        }

        public void DisplayError(string error, ConsoleColor color)
        {
            log.Error(error +"in MainView");
            Display(error, color);
        }
    }
}