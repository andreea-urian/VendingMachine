using iQuest.VendingMachine.Business;
using iQuest.VendingMachine.Business.Dependencies;
using iQuest.VendingMachine.DataAccess.Domaine;
using iQuest.VendingMachine.DataAccess.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace VendingMachineTests
{
    [TestClass]
    public class LookUseCaseTest
    {
        private Mock<IProductRepository> productRepository = new Mock<IProductRepository>();
        private Mock<IShelfView> shelfView = new Mock<IShelfView>();
        private LookUseCase lookUseCase;

        public LookUseCaseTest()
        {
            lookUseCase = new LookUseCase(productRepository.Object, shelfView.Object);
        }

        [TestMethod]
        public void HavingALookUseCase_WhenProductExist_ThenShowProductSuccessfully()
        {
            List<Product> product = new List<Product>();
            product.Add(new Product(4, "Mars", 5, 2));

            productRepository.Setup(x => x.GetAll()).Returns((IEnumerable<Product>)product);

            lookUseCase.Execute();
        }


        [TestMethod]
        public void HavingALookUseCase_WhenProductsExists_ThenReturnAllProducts()
        {
            List<Product> product = new List<Product>();
            product.Add(new Product(4, "Mars", 5, 2));

            productRepository.Setup(x => x.GetAll()).Returns(product);

            Assert.IsNotNull(productRepository.Object.GetAll());

        }

        [TestMethod]
        public void HavingALookUseCase_WhenProductsNotExists_ThenReturnNull()
        {
            List<Product> product = null;

            productRepository.Setup(x => x.GetAll()).Returns(product);

            Assert.IsNull(productRepository.Object.GetAll());

        }

    }
}


