using System;
using System.Collections.Generic;
using System.Text;
using VendingMachine.Business.Dependencies;

namespace iQuest.VendingMachine.Presentation.PresentationLayer
{
    public class CashPaymentTerminal:DisplayBase, ICashPaymentTerminal
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public float AskForMoney()
        {
            log.Info("The money are required");
            Display("Insert money please", ConsoleColor.Green);
            return Convert.ToInt32(Console.ReadLine());
        }
        public void GiveBackChange(float change)
        {
            log.Info("The change " + change);
          Display("There is your change " + change+"\n", ConsoleColor.White);
        }
    }
}
