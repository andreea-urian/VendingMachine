using System;
using System.Collections.Generic;
using System.Text;
using LiteDB;
using iQuest.VendingMachine.DataAccess.Repository;
using iQuest.VendingMachine.DataAccess.Domaine;

namespace VendingMachine.Presentation.Repository
{
    internal class LiteDBProductRepository : IProductRepository
    {
        private readonly ILiteCollection<Product> products;
        public LiteDBProductRepository(string connection)
        {
            if(connection == null) throw new ArgumentNullException(nameof(connection)); 
            LiteDatabase database=new LiteDatabase(connection);
            products = database.GetCollection<Product>();


        }

        private void CreateTable()
        {
            IEnumerable<Product> productsList = new List<Product> { 
                new Product(1,"Pepsi", 5,10),
                new Product(2,"Coca-Cola",6,10),
                new Product(2,"Seven-Days",7,10),
            };

            if (products.Count() == 0)
                products.InsertBulk(productsList);

        }
        public void Decrement(int selectedColumn, int newQuantity)
        {
            IEnumerable<Product> productsList = products.FindAll();
            List<Product> newProducts = new List<Product>(productsList);
            newProducts.Find(x => x.ColumnId == selectedColumn).Quantity--;
            products.DeleteAll();
            products.InsertBulk(newProducts);
        }

        public IEnumerable<Product> GetAll()
        {
            IEnumerable<Product> productsList = products.FindAll();
            return new List<Product>(productsList);

        }

        public Product GetByColumn(int selectedColumn)
        {
            return products.FindOne(x => x.ColumnId == selectedColumn);
        }
    }
}
