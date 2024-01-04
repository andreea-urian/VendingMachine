using System;
using System.Collections.Generic;
using iQuest.VendingMachine.Business.Dependencies;
using iQuest.VendingMachine.Business.Payment;
using iQuest.VendingMachine.Business.UseCases;
using Moq;
using NUnit.Framework;

namespace VendingMachine.Tests.UseCases
{
    public class PaymentUseCaseTest
    {
        private Mock<IBuyView> _buyView = new Mock<IBuyView>();
        private Mock<IPaymentAlgorithm> paymentAlgorithmMock = new Mock<IPaymentAlgorithm>();
        private List<IPaymentAlgorithm> _paymentAlgorithmList = new List<IPaymentAlgorithm>();
        private PaymentUseCase paymentUseCase;

        [SetUp]
        public void Setup()
        {
            _paymentAlgorithmList.Add(paymentAlgorithmMock.Object);
            paymentUseCase = new PaymentUseCase(_buyView.Object, _paymentAlgorithmList);
        }

        [Test]
        public void HavingAPaymentUseCase_WhenMethodIdIsInvalid_ThenThrowException()
        {
            _buyView.Setup(x => x.AskForPaymentMethod(It.IsAny<IEnumerable<PaymentMethod>>())).Throws(new Exception());
            Assert.Throws<Exception>(() => paymentUseCase.Execute(5));
        }

        [Test]
        public void HavingAPaymentUseCase_WhenMethodIdIsValid()
        {
            _buyView.Setup(x => x.AskForPaymentMethod(It.IsAny<IEnumerable<PaymentMethod>>())).Returns(1);
            paymentAlgorithmMock.Setup(x => x.Name).Returns("card");
            paymentAlgorithmMock.Setup(x => x.Run(It.IsAny<float>())).Returns(true);

            Assert.DoesNotThrow(() => paymentUseCase.Execute(5));
        }

        [Test]
        public void HavingAPaymentUseCase_WhenMethodIdIsValid_ButThePaymentUseCaseFail()
        {
            _buyView.Setup(x => x.AskForPaymentMethod(It.IsAny<IEnumerable<PaymentMethod>>())).Returns(1);
            paymentAlgorithmMock.Setup(x => x.Name).Returns("card");
            paymentAlgorithmMock.Setup(x => x.Run(It.IsAny<float>())).Returns(false);

            Assert.Throws<Exception>(() => paymentUseCase.Execute(5));
        }
    }
}
