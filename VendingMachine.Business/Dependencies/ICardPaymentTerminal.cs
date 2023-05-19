using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Business.Dependencies
{
    public interface ICardPaymentTerminal
    {
        public string AskForCardNumber();
    }
}
