using iQuest.VendingMachine.Business.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using iQuest.VendingMachine.Business.Dependencies;
using iQuest.VendingMachine.Business.Payment;

namespace iQuest.VendingMachine.Presentation.PresentationLayer
{
    public class BuyView : DisplayBase, IBuyView
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public string ProductRequest()
        {
            log.Info("Choose an item:");
            Display("Choose an item:", ConsoleColor.White);
            string columnRequest = Console.ReadLine();
            return columnRequest;

        }

        public void DispenseProduct(string productName)
        {
            log.Info(productName + " have been dispensed");
            Display($"You have bought {productName}!", ConsoleColor.White);
        }

        public int AskForPaymentMethod(IEnumerable <PaymentMethod> paymentMethods)
        {
           while(true)
            {
                
                Display("\nPayment methods: ", ConsoleColor.DarkBlue);
                foreach (PaymentMethod paymentMethod in paymentMethods)
                    Display($"{paymentMethod.Name} ", ConsoleColor.DarkBlue);
                Display("\nSelect the payment method:", ConsoleColor.DarkBlue);
                string method = Console.ReadLine();
                if (string.IsNullOrEmpty(method) == true)
                { 
                    log.Error("The method is null or empty");
                    throw new Exception("The method was not chosen") ;
                   
                }
                    

                log.Info("The selected method is:"+method);

                foreach (PaymentMethod paymentMethod in paymentMethods)
                {
                    if (paymentMethod.Name == method)
                    {
                            return paymentMethod.Id;
                    }
                        
                }
            }
        }
    }
}
