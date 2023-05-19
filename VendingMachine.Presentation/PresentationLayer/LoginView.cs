using System;
using VendingMachine.Business.Dependencies;

namespace iQuest.VendingMachine.Presentation.PresentationLayer
{
    public class LoginView : DisplayBase, ILoginView
    {
        public string AskForPassword()
        {
            Console.WriteLine();
            Display("Type the admin password: ", ConsoleColor.Cyan);
            return Console.ReadLine();
        }
    }
}