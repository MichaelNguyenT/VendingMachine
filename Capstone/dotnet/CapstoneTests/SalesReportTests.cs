using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    [TestClass]
    public class SalesReportTests
    {
        [TestMethod]
        public void SalesReportTest()
        {
            VendingMachine vendingMachineTester = new VendingMachine();
            DateTime now = DateTime.Now;
            string filePath = Environment.CurrentDirectory;
            string fileName = "TestFile.txt";
            string fileLocation = Path.Combine(filePath, fileName);
            vendingMachineTester.ItemDictionary = LoadVendingMachine.LoadVending(fileLocation);
            vendingMachineTester.Balance = 10.00M;

            List<string> expectedOutput = new List<string>()
            {
                {"Potato Crisps|0"},
                {"Moonpie|0"},
                {"Cola|0"},
                {"U-Chews|0"},
                {""},
                {"**TOTAL SALES**"},
                {"$0.00"}
            };
            List<string> testOutput = SalesReport.RunSalesReport(vendingMachineTester);
            CollectionAssert.AreEquivalent(expectedOutput, testOutput);
        }
        
    }
}
