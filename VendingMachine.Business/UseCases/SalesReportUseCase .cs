using iQuest.VendingMachine.Business.Dependencies;
using System;
using System.Collections.Generic;
using System.Text;
using VendingMachine.Business.Reports;

namespace VendingMachine.Business.UseCases
{
    public class SalesReportUseCase : IUseCase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private SalesReport salesReport;
        public SalesReportUseCase(SalesReport salesReport)
        {
            this.salesReport = salesReport;
        }

        public void Execute()
        {
            salesReport.SaveReportAsXMLFile(30);
            salesReport.SaveReportAsJSON_File(20);
            log.Info("Save report as XML File");
            log.Info("Save report as JSON File");
        }
    }
}
