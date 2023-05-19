using iQuest.VendingMachine.DataAccess.Domaine;
using iQuest.VendingMachine.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace VendingMachine.DataAccess.EntityFrameworkRepository
{
    public class EFSaleRepository:ISalesRepository
    {

        private readonly VendingMachineDBContext _dbContext;

        public EFSaleRepository(VendingMachineDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddSale(Sale sale)
        {
            if (sale == null)
            {
                throw new ArgumentNullException(nameof(sale));
            }

            _dbContext.Add(sale);

            _dbContext.SaveChanges();
        }

        public List<Sale> GetAll()
        {
            var sales = _dbContext.Sale.ToList();

            return sales;
        }
    }
}
