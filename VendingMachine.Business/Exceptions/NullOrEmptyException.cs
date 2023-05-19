using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.VendingMachine.Business.Exceptions
{
    public class NullOrEmptyException:Exception
    {
        private const string message = "Error, something went wrong";
        public NullOrEmptyException() : base(message) { }
    }
}
