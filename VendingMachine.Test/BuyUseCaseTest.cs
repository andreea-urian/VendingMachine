using iQuest.VendingMachine.Business.Dependencies;
using iQuest.VendingMachine.Business.Exceptions;
using iQuest.VendingMachine.Business.UseCases;
using iQuest.VendingMachine.DataAccess.Domaine;
using iQuest.VendingMachine.DataAccess.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace VendingMachineTests
{
    [TestClass]
    public class BuyUseCaseTest
    {
        private Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
        private Mock<IBuyView> buyView = new Mock<IBuyView>();
        private Mock<IAuthenticationService> authenticationService = new Mock<IAuthenticationService>();
        private Mock<PaymentUseCase> paymentUseCase = new Mock<PaymentUseCase>();
        private BuyUseCase buyUseCase;

        public BuyUseCaseTest()
        {

            buyUseCase = new BuyUseCase(productRepository.Object, buyView.Object, authenticationService.Object, paymentUseCase.Object);
        }

        [TestMethod]
        public void HavingABuyUseCase_WhenProductRequestIsNull_ThenThrowCancelException()
        {
            buyView.Setup(x => x.ProductRequest()).Returns(value: null);

            Assert.ThrowsException<CancelException>(() => buyUseCase.Execute());
        }

        [TestMethod]
        public void HavingABuyUseCase_WhenBuyingOneProduct_ThenQuantityIsDecrementedByOne()
        {
            List<Product> product = new List<Product>();
            product.Add(new Product(4, "Mars", 5, 2));

            productRepository.Setup(x => x.GetByColumn(It.IsAny<int>())).Returns(product[0]);
            buyView.Setup(x => x.ProductRequest()).Returns("4");
            buyUseCase.Execute();

            productRepository.Verify(x => x.Decrement(It.IsAny<int>(),It.IsAny<int>()), Times.Once());

        }

        [TestMethod]
        public void HavingABuyUseCase_WhenColumnDoesNotExist_ThenThrowInvalidColumnException()
        {
            List<Product> product = new List<Product>();
            product.Add(new Product(4, "Mars", 5, 2));

            productRepository.Setup(x => x.GetByColumn(It.IsAny<int>())).Returns(product[0]);
            buyView.Setup(x => x.ProductRequest()).Returns("5tg");

            Assert.ThrowsException<InvalidColumnException>(() => buyUseCase.Execute());

        }

        [TestMethod]
        public void HavingABuyUseCase_WhenRequestingTooManyProducts_ThenThrowInsufficentStockException()
        {
            List<Product> product = new List<Product>();
            product.Add(new Product(4, "Mars", 5, 0));

            productRepository.Setup(x => x.GetByColumn(It.IsAny<int>())).Returns(product[0]);
            buyView.Setup(x => x.ProductRequest()).Returns("4");

            Assert.ThrowsException<InsufficentStockException>(() => buyUseCase.Execute());

        }
    }
}


