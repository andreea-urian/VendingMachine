using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace VendingMachine.Business.Reports
{
    public class ReportView:IReportView
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void ConsoleWriteReportContext(string fileName)
        {
            Console.WriteLine("---File context----");
            Console.WriteLine(File.ReadAllText(fileName));
            log.Info("Writing file info");
        }
    }
}
