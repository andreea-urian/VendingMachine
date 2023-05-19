using System;
using System.Reflection;

namespace iQuest.VendingMachine.Presentation.PresentationLayer
{
    public class ApplicationHeaderControl : DisplayBase
    {
        private readonly string applicationName;
        private readonly Version applicationVersion;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ApplicationHeaderControl()
        {
            Assembly assembly = Assembly.GetEntryAssembly();

            AssemblyProductAttribute assemblyProductAttribute = assembly.GetCustomAttribute<AssemblyProductAttribute>();
            applicationName = assemblyProductAttribute.Product;

            AssemblyName assemblyName = assembly.GetName();
            applicationVersion = assemblyName.Version;
        }

        public void Display()
        {
            log.Info("Display from ApplicationHeaderControl class");
            Console.WriteLine("{0} {1}", applicationName, applicationVersion.ToString(2));
            Console.WriteLine(new string('=', 79));
        }
    }
}