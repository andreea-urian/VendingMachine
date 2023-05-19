using iQuest.VendingMachine.Business.Dependencies;
using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Presentation.Command
{
    public interface IUseCaseFactory
    {
        public T Create<T>() where T : IUseCase;
    }
}
