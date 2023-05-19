using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.VendingMachine.Business.Exceptions
{
    public class InsufficentStockException : Exception
    {
        private const string message = "This product has insufficent stock";
        public InsufficentStockException() : base(message) { }
    }
}
