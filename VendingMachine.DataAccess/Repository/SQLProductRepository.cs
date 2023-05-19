using iQuest.VendingMachine.DataAccess.Domaine;
using iQuest.VendingMachine.DataAccess.Repository;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace VendingMachine.Presentation.Repository
{
    public class SQLProductRepository : IProductRepository
    {
        private readonly MySqlConnection dataBase;
        public SQLProductRepository(string connectionString)
        {
            if (connectionString == null) throw new ArgumentNullException(nameof(connectionString));
            dataBase = new MySqlConnection();
            dataBase.ConnectionString = connectionString;
            dataBase.Open();

            dataBase.Close();

        }

        public void Decrement(int selectedColumn, int newQuantity)
        {
            string decrementCommand = "UPDATE Products SET Quantity=Quantity-1 Where ColumnID = @ColumnID";
            MySqlCommand command = new MySqlCommand(decrementCommand, dataBase);
            dataBase.Open();
            command.Parameters.AddWithValue("@ColumnID", selectedColumn);
            command.ExecuteReader();
            dataBase.Close();

        }

        public IEnumerable<Product> GetAll()
        {
            List<Product> products = new List<Product>();
            dataBase.Open();
            string selectAllCommand = "Select * from Products";
            var command = new MySqlCommand(selectAllCommand, dataBase);
            MySqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                products.Add(new Product(reader.GetInt32(0), reader.GetString(1), reader.GetFloat(2), reader.GetInt32(3)));
            }
            dataBase.Close();
            return products;
            
        }

        public Product GetByColumn(int selectedColumn)
        {
            string selectByColumn = "Select * from Products where ColumnID = @ColumnID";
            MySqlCommand command = new MySqlCommand(selectByColumn, dataBase);
            dataBase.Open();
            command.Parameters.AddWithValue("@ColumnID", selectedColumn);
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            Product selectedProduct = new Product(reader.GetInt32(0), reader.GetString(1), reader.GetFloat(2), reader.GetInt32(3));
            dataBase.Close();
            return selectedProduct;

        }
    }
}
