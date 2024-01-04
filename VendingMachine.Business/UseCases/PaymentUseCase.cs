using System;
using System.Collections.Generic;
using System.Text;
using iQuest.VendingMachine.Business.Exceptions;
using iQuest.VendingMachine.Business.Dependencies;
using iQuest.VendingMachine.Business.Payment;


namespace iQuest.VendingMachine.Business.UseCases
{
    public class PaymentUseCase : IUseCase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        List<IPaymentAlgorithm> _paymentAlgorithmList;

        private IBuyView _buyView;

        List<PaymentMethod> paymentMethods = new List<PaymentMethod>
        {
            new PaymentMethod(1, "card"),
            new PaymentMethod(2, "cash"),
        };
        public string Name => "Payment";

        public string Description => "Pay your product with cash or card";

        public bool CanExecute => true;

        public PaymentUseCase(IBuyView buyView, IEnumerable<IPaymentAlgorithm> paymentAlgorithm)
        {
            if (buyView == null)
            {
                log.Error(new NullOrEmptyException());
                throw new NullOrEmptyException();
            }
                

            this._buyView = buyView;
            this._paymentAlgorithmList = new List<IPaymentAlgorithm>(paymentAlgorithm);
        }

        public void Execute(float price)
        {
            int idPaymentMethod;
            idPaymentMethod = _buyView.AskForPaymentMethod(paymentMethods);
            string paymentMethodSelected = null;
            foreach(PaymentMethod paymentMethod in paymentMethods)
            {
                if (idPaymentMethod == paymentMethod.Id)
                    paymentMethodSelected = paymentMethod.Name;
            }
            foreach(IPaymentAlgorithm paymentAlgorithm in _paymentAlgorithmList)
            {
                if (paymentAlgorithm.Name == paymentMethodSelected)
                    if(!paymentAlgorithm.Run(price))
                    {
                        throw new Exception("Payment Fail");
                    }
            }
        }
    }
}
