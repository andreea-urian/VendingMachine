using iQuest.VendingMachine.Business.Dependencies;
using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.VendingMachine.Business.Payment
{
    public class PaymentMethod: IPaymentMethod
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public PaymentMethod(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }   
    }
}
