using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Business.Dependencies
{
    public interface ICashPaymentTerminal
    {
        public float AskForMoney();
        public void GiveBackChange(float change);
    }
}
