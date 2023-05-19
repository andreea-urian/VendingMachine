using System;

namespace iQuest.VendingMachine.Presentation.PresentationLayer
{
    public class DisplayBase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected void DisplayLine(string message, ConsoleColor color)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = oldColor;
            log.Info(message);
        }

        protected void Display(string message, ConsoleColor color)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ForegroundColor = oldColor;
            log.Info(message);
        }
    }
}