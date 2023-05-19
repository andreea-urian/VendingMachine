using System.Configuration;
using System.IO;
using System.Linq;
using System.Text.Json;
using iQuest.VendingMachine.Business.Payment;
using System;
using System.Collections.Generic;
using VendingMachine.Presentation;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using VendingMachine.Business.Dependencies;
using VendingMachine.DataAccess.Repository;
using iQuest.VendingMachine.DataAccess.Repository;
using iQuest.VendingMachine.DataAccess.Domaine;

namespace VendingMachine.Business.Reports
{
    public class SalesReport: ISalesReport
    {
        private readonly IReportView reportView;

        private ISalesRepository report;

        private string XML_Location;

        private string JSON_Location;

        List<PaymentMethod> paymentMethods = new List<PaymentMethod>
        {
            new PaymentMethod(1, "card"),
            new PaymentMethod(2, "cash"),
        };

        public SalesReport(ISalesRepository report, IReportView reportView)
        {
            XML_Location = ConfigurationManager.AppSettings["XML_Location"];
            JSON_Location = ConfigurationManager.AppSettings["JSON_Location"];
            this.report = report;
            this.reportView = reportView;
        }

        public void Add(Sale item)
        {
            report.AddSale(item);
        }

        private void CheckExistingDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }


        private List<Sale> GetCustomInterval(double interval)
        {
            DateTime startDate = DateTime.Today.AddDays(-interval);
            DateTime endDate = DateTime.Now;
            List<Sale> salesInRange = report.GetAll()
                .Where(s =>s.DateTime <= endDate && s.DateTime >= startDate)
                .ToList();

            return salesInRange;
        }

        public void SaveReportAsXMLFile(double interval)
        {
            if (interval < 0)
                throw new ArgumentNullException("The value is negative");

            CheckExistingDirectory(XML_Location);

            string currentDate = DateTime.Now.ToString("yyyy MM dd HHmmss");

            string fileName = "Sales Report - " + currentDate + ".xml";

            List<Sale> customInterval =GetCustomInterval(interval);

            XmlSerializer xmlser = new XmlSerializer(typeof(List<Sale>));
            using (FileStream fileStr = new FileStream(XML_Location + fileName, FileMode.Create))
            {
                xmlser.Serialize(fileStr, customInterval);
            }

            reportView.ConsoleWriteReportContext(XML_Location + fileName);
        }

        public void SaveReportAsJSON_File(double interval)
        {
            if (interval < 0)
                throw new ArgumentNullException("The value is negative");

            CheckExistingDirectory(JSON_Location);

            string currentDate = DateTime.Now.ToString("yyyy MM dd HHmmss");

            string fileName = "Sales Report - " + currentDate + ".json";

            List<Sale> customInterval = GetCustomInterval(interval);

            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(customInterval, options);

            using (StreamWriter writer = new StreamWriter(JSON_Location + fileName))
            {
                writer.Write(jsonString);
            }

            reportView.ConsoleWriteReportContext(JSON_Location + fileName);
        }

    }
}
