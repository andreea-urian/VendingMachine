using iQuest.VendingMachine.DataAccess.Domaine;
using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Business.Dependencies
{
    public interface ISalesReport
    { 
        public void Add(Sale item);
        public void SaveReportAsXMLFile(double interval);
        public void SaveReportAsJSON_File(double interval);
    }
}
