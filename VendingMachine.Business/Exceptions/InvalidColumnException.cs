using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.VendingMachine.Business.Exceptions
{
    public class InvalidColumnException : Exception
    {
        private const string message = "You have chosen an invalid column!";
        public InvalidColumnException() : base(message) { }
    }
}
