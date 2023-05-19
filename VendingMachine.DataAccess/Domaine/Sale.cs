using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace iQuest.VendingMachine.DataAccess.Domaine
{
    public class Sale
    {
        [Key]
        [DataMember]
        public DateTime DateTime { get; set; }

        [DataMember]
        public string ProductName { get; set; }

        [DataMember]
        public float Price { get; set; }

        [DataMember]
        public string PaymentMethod { get; set; }

        public Sale(string productName, float price, string paymentMethod)
        {
            DateTime = DateTime.Now;
            ProductName = productName;
            Price = price;
            PaymentMethod = paymentMethod;
        }

        public Sale() { }
    }
}
