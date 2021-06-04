using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    [TestClass]
    public class VendingMachineTests
    {

        [TestMethod]
        public void LoadingVendingMachineTest()
        {
            //This doesnt work for some reason, not even Joe knows
            VendingMachine vendingMachineTester = new VendingMachine();
            Dictionary<string, IItem> expectedTestResult = new Dictionary<string, IItem>()
            {
                {"A1", (new Chip("A1", "Potato Crisps", 3.05M))},
                {"B1", (new Candy("B1", "Moonpie", 1.80M))},
                {"C1", (new Drink("C1", "Cola", 1.25M))},
                {"D1", (new Gum("D1", "U-Chews", 0.85M))}
            };
            string filePath = Environment.CurrentDirectory;
            string fileName = "TestFile.txt";
            string fileLocation = Path.Combine(filePath, fileName);
            Dictionary<string, IItem> testResult = LoadVendingMachine.LoadVending(fileLocation);
            CollectionAssert.AreEquivalent(expectedTestResult, testResult);
        }

        [TestMethod]
        public void CheckAllTest()
        {
            VendingMachine vendingMachineTester = new VendingMachine();
            string filePath = Environment.CurrentDirectory;
            string fileName = "TestFile.txt";
            string fileLocation = Path.Combine(filePath, fileName);
            List<string> expectedCollection = new List<string>()
            { 
                {"A1 Potato Crisps 3.05" },
                {"B1 Moonpie 1.80" },
                {"C1 Cola 1.25" },
                {"D1 U-Chews 0.85" }
            };
            vendingMachineTester.ItemDictionary = LoadVendingMachine.LoadVending(fileLocation);
            List<string> testCollection = vendingMachineTester.MakeCollectionOfItems();
            CollectionAssert.AreEquivalent(expectedCollection, testCollection);
        }

        [TestMethod]
        public void DepositMoneyTest()
        {
            VendingMachine vendingMachineTester = new VendingMachine();
            string filePath = Environment.CurrentDirectory;
            string fileName = "TestFile.txt";
            string fileLocation = Path.Combine(filePath, fileName);
            vendingMachineTester.ItemDictionary = LoadVendingMachine.LoadVending(fileLocation);
            decimal expectedResult = 1.00M;
            decimal testResult = vendingMachineTester.DepositMoney("1");
            Assert.AreEqual(expectedResult, testResult);
        }

        [TestMethod]
        public void PutchaseItemTest()
        {
            VendingMachine vendingMachineTester = new VendingMachine();
            string filePath = Environment.CurrentDirectory;
            string fileName = "TestFile.txt";
            string fileLocation = Path.Combine(filePath, fileName);
            vendingMachineTester.ItemDictionary = LoadVendingMachine.LoadVending(fileLocation);
            vendingMachineTester.Balance = 10.00M;
            
            string testValue = vendingMachineTester.PurchaseItem("A1");
            string expectedValue = "Crunch Crunch, Yum!";
            Assert.AreEqual(expectedValue, testValue);
            Assert.AreEqual(vendingMachineTester.ItemDictionary["A1"].Inventory, 4);
            Assert.AreEqual(vendingMachineTester.Balance, 6.95M);
            Assert.AreEqual(vendingMachineTester.ItemDictionary["A1"].TotalSales, 1);
        }

        [TestMethod]
        public void FinishTransactionTest()
        {
            VendingMachine vendingMachineTester = new VendingMachine();
            string filePath = Environment.CurrentDirectory;
            string fileName = "TestFile.txt";
            string fileLocation = Path.Combine(filePath, fileName);
            vendingMachineTester.ItemDictionary = LoadVendingMachine.LoadVending(fileLocation);
            vendingMachineTester.Balance = 10.00M;

            string testValue = vendingMachineTester.FinishTransaction();
            string expectedValue = $"Your change is $10.00 in 40 quarter(s), 0 dime(s), and 0 nickel(s)";
            Assert.AreEqual(expectedValue, testValue);
        }

    }
}