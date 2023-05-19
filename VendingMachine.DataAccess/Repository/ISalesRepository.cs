using iQuest.VendingMachine.DataAccess.Domaine;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace iQuest.VendingMachine.DataAccess.Repository
{
    public interface ISalesRepository
    {
        public void AddSale(Sale sale);

        public List<Sale> GetAll();
    }
}
