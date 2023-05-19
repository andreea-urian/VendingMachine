using iQuest.VendingMachine.DataAccess.Domaine;
using System;
using System.Collections.Generic;
using System.Text;


namespace iQuest.VendingMachine.Business.Dependencies
{
    public interface IShelfView
    {
        public void DisplayProducts(IEnumerable<Product> products);
        public void DisplayAvailableProducts(IEnumerable<Product> allProducts, List<Product> displayProducts);
    }
}
