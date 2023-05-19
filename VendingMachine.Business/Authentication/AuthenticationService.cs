using iQuest.VendingMachine.Business.Dependencies;

namespace iQuest.VendingMachine.Business.Authentication
{
    public class AuthenticationService: IAuthenticationService
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public bool IsUserAuthenticated { get; private set; }

        public void Login(string password)
        {
            if (password == "123")
            {
                log.Info("The user logged in successfully"); 
                IsUserAuthenticated = true;
            }
               
            else
            {
                log.Error(new InvalidPasswordException());
                throw new InvalidPasswordException();
            }
                
        }

        public void Logout()
        {
            log.Info("The user logged out in successfully");
            IsUserAuthenticated = false;
        }
    }
}