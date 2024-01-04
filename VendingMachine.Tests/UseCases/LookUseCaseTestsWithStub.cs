using System;
using iQuest.VendingMachine.Business;
using iQuest.VendingMachine.Business.Exceptions;
using iQuest.VendingMachine.DataAccess.Domaine;
using iQuest.VendingMachine.DataAccess.Repository;
using iQuest.VendingMachine.Presentation;
using VendingMachine.DataAccess.EntityFrameworkRepository;

namespace VendingMachine.Tests.UseCases
{
	public class LookUseCaseTestsWithStub
	{
        private class ProductRepositoryStub : IProductRepository
        {
            public int countDecrement = 0;
            private List<Product> product;
            public ProductRepositoryStub()
            {
                product = new List<Product>() {
                    new Product(1, "Cola", 5, 2),
                    new Product(2, "Fanta", 5, 2),
                    new Product(3, "Sprite", 5, 2),
                };
            }

            public ProductRepositoryStub(List<Product> products)
            {
                product = products;
            }

            public void Decrement(int selectedColumn, int newQuantity)
            {
                countDecrement++;
            }

            public IEnumerable<Product> GetAll()
            {
                return product;
            }

            public Product GetByColumn(int selectedColumn)
            {
                return product[0];
            }
        }
        private ProductRepositoryStub productRepository;
        private ShelfView shelfView = new ShelfView();
        private LookUseCase lookUseCase;
        private StringWriter stringWriter;
        private TextWriter originalOutput;

        [SetUp]
        public void Setup()
        {
            originalOutput = Console.Out;
            stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
        }

        [Test]
        public void HavingALookUseCase_WhenProductExist_ThenShowProductSuccessfully()
        {
            List<Product> product = new List<Product>();
            product.Add(new Product(1, "Cola", 5, 2));
            product.Add(new Product(2, "Fanta", 5, 2));
            product.Add(new Product(3, "Sprite", 5, 2));
            product.Add(new Product(4, "Mars", 5, 2));
            productRepository = new(product);
            lookUseCase = new LookUseCase(productRepository, shelfView);

            lookUseCase.Execute();
            Assert.That(stringWriter.ToString(), Is.EqualTo("1 Cola 5 2\n2 Fanta 5 2\n3 Sprite 5 2\n4 Mars 5 2\n"));
        }

        [Test]
        public void HavingALookUseCase_WhenProductExist_ButNoStock()
        {
            List<Product> product = new List<Product>();
            product.Add(new Product(1, "Cola", 5, 0));
            product.Add(new Product(2, "Fanta", 5, 0));
            product.Add(new Product(3, "Sprite", 5, 0));
            product.Add(new Product(4, "Mars", 5, 0));
            productRepository = new(product);
            lookUseCase = new LookUseCase(productRepository, shelfView);

            lookUseCase.Execute();
            Assert.That(stringWriter.ToString(), Is.EqualTo(String.Empty));
        }

        [Test]
        public void HavingALookUseCase_WhenProductExist_ButSomeOfThemHasNoStock()
        {
            List<Product> product = new List<Product>();
            product.Add(new Product(1, "Cola", 5, 2));
            product.Add(new Product(2, "Fanta", 5, 2));
            product.Add(new Product(3, "Sprite", 5, 2));
            product.Add(new Product(4, "Mars", 5, 0));
            productRepository = new(product);
            lookUseCase = new LookUseCase(productRepository, shelfView);

            lookUseCase.Execute();
            Assert.That(stringWriter.ToString(), Is.EqualTo("1 Cola 5 2\n2 Fanta 5 2\n3 Sprite 5 2\n"));
        }

        [Test]
        public void HavingALookUseCase_WhenProductDoseNotExist()
        {
            List<Product> product = new List<Product>();
            productRepository = new(product);
            lookUseCase = new LookUseCase(productRepository, shelfView);

            Assert.Throws<InsufficentStockException>(() => lookUseCase.Execute());
        }

        [Test]
        public void HavingALookUseCase_WhenProductsIsNull()
        {
            List<Product> product = null;
            productRepository = new(product);
            lookUseCase = new LookUseCase(productRepository, shelfView);

            Assert.Throws<ArgumentNullException>(() => lookUseCase.Execute());
        }

        [TearDown]
        public void TearDown()
        {
            Console.SetOut(originalOutput);
            stringWriter.Dispose();
        }
    }
}

