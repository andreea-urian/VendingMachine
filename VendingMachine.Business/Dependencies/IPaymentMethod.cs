using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.VendingMachine.Business.Dependencies
{
    public interface IPaymentMethod
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
