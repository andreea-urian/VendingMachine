using iQuest.VendingMachine.Business.Dependencies;
using System;
using System.Collections.Generic;
using System.Text;
using VendingMachine.Business.Dependencies;

namespace iQuest.VendingMachine.Business.Payment
{
    public class CashPayment:IPaymentAlgorithm
    {
        ICashPaymentTerminal cashTerminal;
        public string Name => "cash";

        public CashPayment(ICashPaymentTerminal cashTerminal)
        {
            this.cashTerminal = cashTerminal;
        }

        public bool Run(float price)
        {
            float sold = 0;
            while (sold < price)
            {
                sold += cashTerminal.AskForMoney();
            }
            float change = sold - price;
            if (change > 0)
                cashTerminal.GiveBackChange(change);
            return true;
        }
    }
}
