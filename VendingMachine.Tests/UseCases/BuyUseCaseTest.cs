using System;
using iQuest.VendingMachine.Business.Dependencies;
using iQuest.VendingMachine.Business.Exceptions;
using iQuest.VendingMachine.Business.UseCases;
using iQuest.VendingMachine.DataAccess.Domaine;
using iQuest.VendingMachine.DataAccess.Repository;
using Moq;

namespace VendingMachine.Tests.UseCases
{
	public class BuyUseCaseTest
	{
        private Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
        private Mock<IBuyView> buyView = new Mock<IBuyView>();
        private Mock<IAuthenticationService> authenticationService = new Mock<IAuthenticationService>();
        private Mock<IUseCase> paymentUseCase = new Mock<IUseCase>();
        private BuyUseCase buyUseCase;

        [SetUp]
        public void Setup()
        {
            buyUseCase = new BuyUseCase(productRepository.Object, buyView.Object, authenticationService.Object, paymentUseCase.Object);
        }

        [Test]
        public void HavingABuyUseCase_WhenProductRequestIsNull_ThenThrowCancelException()
        {
            buyView.Setup(x => x.ProductRequest()).Returns(value: null);

            Assert.Throws<CancelException>(() => buyUseCase.Execute());
        }

        [Test]
        public void HavingABuyUseCase_WhenBuyingOneProduct_ThenQuantityIsDecrementedByOne()
        {
            List<Product> product = new List<Product>();
            product.Add(new Product(4, "Mars", 5, 2));

            productRepository.Setup(x => x.GetByColumn(It.IsAny<int>())).Returns(product[0]);
            buyView.Setup(x => x.ProductRequest()).Returns("4");
            buyUseCase.Execute();

            productRepository.Verify(x => x.Decrement(It.IsAny<int>(), It.IsAny<int>()), Times.Once());

        }

        [Test]
        public void HavingABuyUseCase_WhenColumnDoesNotExist_ThenThrowInvalidColumnException()
        {
            List<Product> product = new List<Product>();
            product.Add(new Product(4, "Mars", 5, 2));

            productRepository.Setup(x => x.GetByColumn(It.IsAny<int>())).Returns(product[0]);
            buyView.Setup(x => x.ProductRequest()).Returns("5tg");

            Assert.Throws<InvalidColumnException>(() => buyUseCase.Execute());
        }

        [Test]
        public void HavingABuyUseCase_WhenRequestingTooManyProducts_ThenThrowInsufficentStockException()
        {
            List<Product> product = new List<Product>();
            product.Add(new Product(4, "Mars", 5, 0));

            productRepository.Setup(x => x.GetByColumn(It.IsAny<int>())).Returns(product[0]);
            buyView.Setup(x => x.ProductRequest()).Returns("4");

            Assert.Throws<InsufficentStockException>(() => buyUseCase.Execute());

        }
    }
}

