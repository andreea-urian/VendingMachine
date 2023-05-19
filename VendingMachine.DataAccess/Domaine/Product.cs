using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace iQuest.VendingMachine.DataAccess.Domaine
{
    public class Product
    {
        [Key]
        public int ColumnId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }

        public Product(int columnId, string name, float price, int quantity)
        {
            ColumnId = columnId;
            Name = name;
            Price = price;
            Quantity = quantity;
        }
    }
}
