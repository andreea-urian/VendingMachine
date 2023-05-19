using Autofac;
using iQuest.VendingMachine.Business;
using iQuest.VendingMachine.Business.Dependencies;
using System;
using System.Collections.Generic;
using System.Text;
using VendingMachine.Business.Dependencies;
using VendingMachine.Presentation.Command;

namespace iQuest.VendingMachine
{
    public class UseCaseFactory:IUseCaseFactory
    {
        private IComponentContext component;

        public UseCaseFactory(IComponentContext componentContext)
        {
            this.component = componentContext ?? throw new ArgumentNullException(nameof(component));
        }
        public T Create<T>() where T : IUseCase
        {
            return component.Resolve<T>();
        }
    }
}
