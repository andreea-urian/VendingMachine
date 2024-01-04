using System;
using System.IO;
using iQuest.VendingMachine.Business;
using iQuest.VendingMachine.Business.Dependencies;
using iQuest.VendingMachine.Business.Exceptions;
using iQuest.VendingMachine.Business.UseCases;
using iQuest.VendingMachine.DataAccess.Domaine;
using iQuest.VendingMachine.DataAccess.Repository;
using iQuest.VendingMachine.Presentation;
using Moq;

namespace VendingMachine.Tests.UseCases
{
	public class LookUseCaseTests
	{
        private Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
        private ShelfView shelfView = new ShelfView();
        private LookUseCase lookUseCase;
        private StringWriter stringWriter;
        private TextWriter originalOutput;

        [SetUp]
        public void Setup()
        {
            lookUseCase = new LookUseCase(productRepository.Object, shelfView);
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

            productRepository.Setup(x => x.GetAll()).Returns((IEnumerable<Product>)product);

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

            productRepository.Setup(x => x.GetAll()).Returns((IEnumerable<Product>)product);

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

            productRepository.Setup(x => x.GetAll()).Returns((IEnumerable<Product>)product);

            lookUseCase.Execute();
            Assert.That(stringWriter.ToString(), Is.EqualTo("1 Cola 5 2\n2 Fanta 5 2\n3 Sprite 5 2\n"));
        }

        [Test]
        public void HavingALookUseCase_WhenProductDoseNotExist()
        {
            List<Product> product = new List<Product>();

            productRepository.Setup(x => x.GetAll()).Returns((IEnumerable<Product>)product);

            Assert.Throws<InsufficentStockException>(() => lookUseCase.Execute());
        }

        [Test]
        public void HavingALookUseCase_WhenProductsIsNull()
        {
            List<Product> product = null;

            productRepository.Setup(x => x.GetAll()).Returns((IEnumerable<Product>)product);

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

