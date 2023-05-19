using iQuest.VendingMachine.DataAccess.Domaine;
using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.VendingMachine.DataAccess.Repository
{
    public interface IProductRepository
    {
        public Product GetByColumn(int selectedColumn);
        public void Decrement(int selectedColumn, int newQuantity);

        public IEnumerable<Product> GetAll();
    }
}
