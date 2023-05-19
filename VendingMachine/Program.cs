using System;

namespace iQuest.VendingMachine
{
    internal class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();

            log.Info("Hello logging world!");

            try
            {
                Bootstrapper bootstrapper = new Bootstrapper();
                bootstrapper.Run();
            }
            catch (Exception ex)
            {
                DisplayError(ex);
                Pause();
            }
        }

        private static void DisplayError(Exception ex)
        {
            log.Error(ex);
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex);
            Console.ForegroundColor = oldColor;
        }

        private static void Pause()
        {
            Console.WriteLine();
            Console.Write("Press any key to continue...");
            Console.ReadKey(true);
            Console.WriteLine();
        }
    }
}