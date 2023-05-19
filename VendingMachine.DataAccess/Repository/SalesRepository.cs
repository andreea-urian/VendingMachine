using iQuest.VendingMachine.DataAccess.Domaine;
using iQuest.VendingMachine.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace VendingMachine.DataAccess.Repository
{
    [DataContract]
    [XmlRoot(ElementName = "SalesReport")]

    public class SalesRepository:ISalesRepository
    {
        [DataMember(Name = "SalesReport")]
        [XmlElement(ElementName = "Sale")]

        public List<Sale> Sales{ get; set; }=new List<Sale>(); 

        public SalesRepository()
        {
            Sales.Add(new Sale("pepsi", 5.5f, "card"));
            Sales.Add(new Sale("cola", 6.0f, "cash"));
            Sales.Add(new Sale("kit-kat", 4.5f, "card"));
            Sales.Add(new Sale("milkyway", 3.5f, "cash"));
        }

        public void AddSale(Sale sale)
        {
            Sales.Add(sale);
        }

        public List<Sale> GetAll()
        {
            return Sales;
        }
    }
}
