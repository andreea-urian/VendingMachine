using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.VendingMachine.Business.Dependencies
{
    public interface IAuthenticationService
    {
        public bool IsUserAuthenticated { get; }
        public void Login(string password);
        public void Logout();
    }
}
