using iQuest.VendingMachine.DataAccess.Domaine;
using iQuest.VendingMachine.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine.DataAccess.EntityFrameworkRepository
{
    public class EFProductRepository: IProductRepository
    {
        private readonly VendingMachineDBContext _dbContext;

        public EFProductRepository(VendingMachineDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Decrement(int columnID, int newQuantity)
        {
            var product = _dbContext.Products.FirstOrDefault(x => x.ColumnId == columnID);

            if (product is null)
            {
                throw new ArgumentNullException();
            }

            product.Quantity=newQuantity;

            _dbContext.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
        {
            var products = _dbContext.Products;

            return products;
        }

        public Product GetByColumn(int columnID)
        {
            var product = _dbContext.Products.FirstOrDefault(x => x.ColumnId == columnID);

            if (product is null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                return product;
            }
        }
    }
}
