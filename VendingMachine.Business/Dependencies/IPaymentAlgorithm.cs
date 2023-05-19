using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.VendingMachine.Business.Dependencies
{
    public interface IPaymentAlgorithm
    {
        public string Name { get; }

        public bool Run(float price);

    }
}
