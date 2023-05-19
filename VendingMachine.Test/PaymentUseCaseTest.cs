using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using iQuest.VendingMachine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using iQuest.VendingMachine.Business.Dependencies;
using iQuest.VendingMachine.Business.UseCases;
using iQuest.VendingMachine.Business.Payment;

namespace VendingMachineTests
{
    internal class PaymentUseCaseTest
    {
        private Mock<IPaymentAlgorithm> _paymentAlgorithmList = new Mock<IPaymentAlgorithm>();
        private Mock<IBuyView> _buyView = new Mock<IBuyView>();
        private PaymentUseCase paymentUseCase;

        public PaymentUseCaseTest()
        {
            paymentUseCase = new PaymentUseCase(_buyView.Object, (List<IPaymentAlgorithm>)_paymentAlgorithmList.Object);
        }

        [TestMethod]
        public void HavingAPaymentUseCase_WhenMethodIdIsInvalid_ThenThrowException()
        {
           IEnumerable <PaymentMethod> paymentMethods = new List<PaymentMethod>() {
                new PaymentMethod(1, "card"),
                new PaymentMethod(2, "cash"),
            };
            _buyView.Setup(x => x.AskForPaymentMethod(paymentMethods)).Returns(value: 10);

            Assert.ThrowsException<Exception>(() => paymentUseCase.Execute(5));
        }
    }
}
