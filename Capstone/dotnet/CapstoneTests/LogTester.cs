using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;

namespace Capstone
{
    [TestClass]
    public class LogTester
    {
        
        [TestMethod]
        public void LogFedInTest()
        {
            VendingMachine vendingMachineTester = new VendingMachine();
            DateTime now = DateTime.Now;
            string filePath = Environment.CurrentDirectory;
            string fileName = "TestFile.txt";
            string fileLocation = Path.Combine(filePath, fileName);
            vendingMachineTester.ItemDictionary = LoadVendingMachine.LoadVending(fileLocation);
            vendingMachineTester.Balance = 10.00M;

            string testResult = Log.WriteLogFedIn(1.00M, vendingMachineTester.Balance);
            string expectedResult = $"{now.ToString()} FEED MONEY: $1.00 $11.00";

        }

        [TestMethod]
        public void LogPurchaseTest()
        {
            VendingMachine vendingMachineTester = new VendingMachine();
            DateTime now = DateTime.Now;
            string filePath = Environment.CurrentDirectory;
            string fileName = "TestFile.txt";
            string fileLocation = Path.Combine(filePath, fileName);
            vendingMachineTester.ItemDictionary = LoadVendingMachine.LoadVending(fileLocation);
            vendingMachineTester.Balance = 10.00M;

            vendingMachineTester.PurchaseItem("A1");
            string testResult = Log.WriteLogPurchase(vendingMachineTester.ItemDictionary["A1"], vendingMachineTester.Balance);
            string expectedResult = $"{now.ToString()} Potato Crisps A1 $3.05 $6.95";
            Assert.AreEqual(expectedResult, testResult);
        }

        [TestMethod]
        public void WriteLogCompleteTest()
        {
            VendingMachine vendingMachineTester = new VendingMachine();
            DateTime now = DateTime.Now;
            string filePath = Environment.CurrentDirectory;
            string fileName = "TestFile.txt";
            string fileLocation = Path.Combine(filePath, fileName);
            vendingMachineTester.ItemDictionary = LoadVendingMachine.LoadVending(fileLocation);
            vendingMachineTester.Balance = 10.00M;

            vendingMachineTester.PurchaseItem("A1");
            string testResult = Log.WriteLogComplete(vendingMachineTester.Balance);
            string expectedResult = $"{now.ToString()} GIVE CHANGE: $6.95 $0.00";
            Assert.AreEqual(expectedResult, testResult);
        }
    }
}
