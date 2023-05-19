using iQuest.VendingMachine.Business.Dependencies;
using System;
using System.Collections.Generic;
using System.Text;
using VendingMachine.Business.Dependencies;

namespace iQuest.VendingMachine.Business.Payment
{
    public class CardPayment : IPaymentAlgorithm
    {
        ICardPaymentTerminal cardTerminal;
        public string Name => "card";

        public CardPayment(ICardPaymentTerminal cardTerminal)
        {
            this.cardTerminal = cardTerminal;
        }

        public bool Run(float price)
        {
            while(true)
            {
                if (cardTerminal.AskForCardNumber() !=null)
                {
                    return true;
                }
                    
            }
            
        }

    }
}
