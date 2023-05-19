using System;
using System.Collections.Generic;
using System.Text;
using VendingMachine.Business.Dependencies;

namespace iQuest.VendingMachine.Presentation.PresentationLayer
{
    public class CardPaymentTerminal:DisplayBase, ICardPaymentTerminal
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public string AskForCardNumber()
        {
            string cardNumber;
            Display("The card number is required", ConsoleColor.Green);
            cardNumber = Console.ReadLine();

            if(cardNumber != null)
            {
                log.Info("The card number " + cardNumber + " is valid");
                Display("The card number is valid", ConsoleColor.White);
                return cardNumber;
            }

            else
            {
                log.Error("The card number is null");
                return null;
            }
        }
    }
}
