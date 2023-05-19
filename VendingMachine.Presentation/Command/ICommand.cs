using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Presentation.Command
{
    public interface ICommand
    {
        public string Name { get; }

        public string Description { get; }

        public bool CanExecute { get; }

        public void Execute();
    }
}
