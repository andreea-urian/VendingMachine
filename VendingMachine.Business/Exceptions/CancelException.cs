using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.VendingMachine.Business.Exceptions
{
    public class CancelException : Exception
    {
        private const string message = "You have canceled the transaction.";
        public CancelException() : base(message) { }

    }
}
