using System;
using System.Collections.Generic;
using System.Text;
using iQuest.VendingMachine;
using iQuest.VendingMachine.DataAccess.Domaine;

namespace iQuest.VendingMachine.DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        
        private List<Product> Products = new List<Product>();

        public void AddToList(int columnId, string name, float price, int quantity)
        {
            Products.Add(new Product(columnId, name, price, quantity));
        }
        public ProductRepository()
        {
            AddToList(1, "Cola", 5, 10);
            AddToList(2, "Pepsi", 6, 12);
            AddToList(3, "Snickers", 5, 2);
        }

        public IEnumerable<Product> GetAll()
        {
            return Products;
        }

        public Product GetByColumn(int selectedColumn)
        {
            Product product=null;
            if (Products.Exists(P => P.ColumnId == selectedColumn) == true)
            {
                product = Products.Find(P => P.ColumnId == selectedColumn);
                
            }
            return product;
        }

        public void Decrement(int selectedColumn, int newQuantity)
        {
            foreach (Product product in Products)
            {
                if (product.ColumnId == selectedColumn)
                {
                    product.Quantity = newQuantity;
                }
            }

        }
       
    }
}