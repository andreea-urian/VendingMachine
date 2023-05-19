using iQuest.VendingMachine.Business.Dependencies;
using System;
using System.Collections.Generic;
using System.Text;
using VendingMachine.Presentation.Command;

namespace VendingMachine.Business.Dependencies
{
    public interface IMainView
    {
        public void DisplayApplicationHeader();
        public ICommand ChooseCommand(IEnumerable<ICommand> useCases);
        public void DisplayError(string error, ConsoleColor color);
    }
}
