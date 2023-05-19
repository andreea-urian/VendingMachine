using iQuest.VendingMachine.Business.Payment;
using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.VendingMachine.Business.Dependencies
{
    public interface IBuyView
    {
        public string ProductRequest();
        public void DispenseProduct(string productName);
        public int AskForPaymentMethod(IEnumerable<PaymentMethod> paymentMethods);
    }
}
