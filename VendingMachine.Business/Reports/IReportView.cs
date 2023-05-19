using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Business.Reports
{
    public interface IReportView
    {
        public void ConsoleWriteReportContext(string filename);
    }
}
