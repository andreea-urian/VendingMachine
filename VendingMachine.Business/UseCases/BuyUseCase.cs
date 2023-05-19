using iQuest.VendingMachine.Business.Authentication;
using iQuest.VendingMachine.Business.Exceptions;
using iQuest.VendingMachine.Business.Dependencies;
using System;
using System.Collections.Generic;
using System.Text;
using iQuest.VendingMachine.DataAccess.Domaine;
using iQuest.VendingMachine.DataAccess.Repository;

namespace iQuest.VendingMachine.Business.UseCases
{
    public class BuyUseCase : IUseCase
    {
        private readonly IProductRepository productRepository;
        private readonly IBuyView buyView;
        private readonly IAuthenticationService authenticationService;
        private PaymentUseCase paymentUseCase;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public BuyUseCase(IProductRepository productRepository, IBuyView buyView, IAuthenticationService authenticationService,PaymentUseCase paymentUseCase)
        {
            this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            this.buyView = buyView ?? throw new ArgumentNullException(nameof(buyView));
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            this.paymentUseCase = paymentUseCase ?? throw new ArgumentNullException(nameof(paymentUseCase));
        }

        public void Execute()
        {
            bool cancel = false;
            String columnRequest = buyView.ProductRequest();
           
            if (String.IsNullOrEmpty(columnRequest))
            {
                cancel = true;
            }

            if (cancel == false)
            {
                int id;
                bool success = int.TryParse(columnRequest, out id);
                if (success is false)
                {
                    log.Error(new InvalidColumnException());
                    throw new InvalidColumnException();
                }

                Product selectedProduct = productRepository.GetByColumn(id)?? throw new InvalidColumnException();
                log.Info(selectedProduct);
                if (selectedProduct != null)
                {
                    if (selectedProduct.Quantity > 0)
                    {
                        paymentUseCase.Execute(selectedProduct.Price);
                        productRepository.Decrement(selectedProduct.ColumnId, selectedProduct.Quantity-1);
                        buyView.DispenseProduct(selectedProduct.Name);

                    }
                    else
                    {
                        log.Error(new InsufficentStockException());
                        throw new InsufficentStockException();
                    }
                        
                }
            }
            else
            {
                log.Error(new CancelException());
                throw new CancelException();
            }
                
        }
    }
}
