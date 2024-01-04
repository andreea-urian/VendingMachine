using System;
using iQuest.VendingMachine.Business.Dependencies;
using iQuest.VendingMachine.Business.Exceptions;
using iQuest.VendingMachine.Business.UseCases;
using iQuest.VendingMachine.DataAccess.Domaine;
using iQuest.VendingMachine.DataAccess.Repository;
using Moq;

namespace VendingMachine.Tests.UseCases
{
	public class BuyUseCaseTestsWithStub
	{
        private class ProductRepositoryStub : IProductRepository
        {
            public int countDecrement = 0;
            private List<Product> product;
            public ProductRepositoryStub()
            {
                product = new List<Product>() { new Product(4, "Mars", 5, 2) };
            }

            public ProductRepositoryStub(List<Product>products)
            {
                product = products;
            }

            public void Decrement(int selectedColumn, int newQuantity)
            {
                countDecrement++;
            }

            public IEnumerable<Product> GetAll()
            {
                throw new NotImplementedException();
            }

            public Product GetByColumn(int selectedColumn)
            {
                return product[0];
            }
        }
        private ProductRepositoryStub productRepository = new ProductRepositoryStub();
        private Mock<IBuyView> buyView = new Mock<IBuyView>();
        private Mock<IAuthenticationService> authenticationService = new Mock<IAuthenticationService>();
        private Mock<IUseCase> paymentUseCase = new Mock<IUseCase>();
        private BuyUseCase buyUseCase;

        [SetUp]
        public void Setup()
        {
            buyUseCase = new BuyUseCase(productRepository, buyView.Object, authenticationService.Object, paymentUseCase.Object);
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

            buyView.Setup(x => x.ProductRequest()).Returns("4");
            buyUseCase.Execute();

            Assert.That(productRepository.countDecrement, Is.EqualTo(1));

        }

        [Test]
        public void HavingABuyUseCase_WhenColumnDoesNotExist_ThenThrowInvalidColumnException()
        {
            buyView.Setup(x => x.ProductRequest()).Returns("5tg");

            Assert.Throws<InvalidColumnException>(() => buyUseCase.Execute());
        }

        [Test]
        public void HavingABuyUseCase_WhenRequestingTooManyProducts_ThenThrowInsufficentStockException()
        {
            List<Product> products = new List<Product>();
            products.Add(new Product(4, "Mars", 5, 0));

            productRepository = new ProductRepositoryStub(products);
            buyView.Setup(x => x.ProductRequest()).Returns("4");

            buyUseCase = new BuyUseCase(productRepository, buyView.Object, authenticationService.Object, paymentUseCase.Object);
            Assert.Throws<InsufficentStockException>(() => buyUseCase.Execute());

        }
    }
}

