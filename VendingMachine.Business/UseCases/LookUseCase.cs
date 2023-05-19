using System;
using System.Collections.Generic;
using System.Text;
using iQuest.VendingMachine.Business.Authentication;
using iQuest.VendingMachine.Business.Dependencies;
using iQuest.VendingMachine.Business.Exceptions;
using iQuest.VendingMachine.DataAccess.Domaine;
using iQuest.VendingMachine.DataAccess.Repository;

namespace iQuest.VendingMachine.Business
{
    public class LookUseCase :IUseCase
    {
        private readonly IProductRepository productRepository;
        private readonly IShelfView shelfView;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public LookUseCase(IProductRepository productRepository, IShelfView shelfView)
        {
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            this.shelfView=shelfView ?? throw new ArgumentNullException(nameof(shelfView));
        }

        public void Execute()
        {
            IEnumerable<Product> allProducts = productRepository.GetAll();
            List<Product> displayProducts = new List<Product>();
            log.Info("Products were displayed succesfully");
            shelfView.DisplayAvailableProducts(allProducts, displayProducts);
        }
    }
}
