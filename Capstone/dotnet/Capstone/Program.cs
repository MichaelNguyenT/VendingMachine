using System;
using System.IO;
using System.Collections.Generic;
namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            VendingMachine myVendingMachine = new VendingMachine();
            string filePath = Environment.CurrentDirectory;
            string fileName = "vendingmachine.csv";
            string fileLocation = Path.Combine(filePath, fileName);

            //reads and loads everything into the dictionary of items in the vending machine
            try
            {
                using (StreamReader sr = new StreamReader(fileLocation))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] lineArray = line.Split("|");
                        if (lineArray[lineArray.Length - 1] == "Candy")
                        {
                            Candy myCandy = new Candy(lineArray[0], lineArray[1], decimal.Parse(lineArray[2]));
                            myVendingMachine.ItemDictionary.Add(myCandy.Slot, myCandy);
                        }
                        else if (lineArray[lineArray.Length - 1] == "Chip")
                        {
                            Chip myChip = new Chip(lineArray[0], lineArray[1], decimal.Parse(lineArray[2]));
                            myVendingMachine.ItemDictionary.Add(myChip.Slot, myChip);
                        }
                        else if (lineArray[lineArray.Length - 1] == "Drink")
                        {
                            Drink myDrink = new Drink(lineArray[0], lineArray[1], decimal.Parse(lineArray[2]));
                            myVendingMachine.ItemDictionary.Add(myDrink.Slot, myDrink);
                        }
                        else if (lineArray[lineArray.Length - 1] == "Gum")
                        {
                            Gum myGum = new Gum(lineArray[0], lineArray[1], decimal.Parse(lineArray[2]));
                            myVendingMachine.ItemDictionary.Add(myGum.Slot, myGum);
                        }
                    }
                }
                
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }
            
            
            while (myVendingMachine.Mode == 0)
            {
                Console.WriteLine("\n(1) Display Vending Machine Items");
                Console.WriteLine("(2) Purchase Items");
                Console.WriteLine("(3) Exit");
                string modeSelection = Console.ReadLine();
                if (modeSelection == "1")
                {
                    myVendingMachine.CheckAll();
                }
                else if (modeSelection == "2")
                {

                    myVendingMachine.Mode = 1;
                    while (myVendingMachine.Mode == 1)
                    {
                        Console.WriteLine("\n(1) Feed Money");
                        Console.WriteLine("(2) Purchase Product");
                        Console.WriteLine("(3) Finish Transaction");
                        Console.WriteLine($"Current money provided: ${myVendingMachine.Balance}");
                        string inputSelection = Console.ReadLine();
                        if (inputSelection == "1")
                        {
                            Console.WriteLine("Please insert a whole dollar amount (e.g. $1, $2, $5, or $10)");
                            string insertAmount = (Console.ReadLine());
                            decimal finalAmount = myVendingMachine.DepositMoney(insertAmount);
                            
                            Log.WriteLogFedIn(finalAmount, myVendingMachine.Balance);
                        }
                        else if (inputSelection == "2")
                        {
                            Console.Write("Enter the item position you would like to purchase: ");
                            string inputPosition = Console.ReadLine().ToUpper();
                            while(!myVendingMachine.ItemDictionary.ContainsKey(inputPosition))
                            {
                                Console.Write("Please enter a valid item position.");
                                inputPosition = Console.ReadLine().ToUpper();
                            }
                             myVendingMachine.PurchaseItem(inputPosition);
                            Log.WriteLogPurchase(myVendingMachine.ItemDictionary[inputPosition], myVendingMachine.Balance);
                        }
                        else if (inputSelection == "3")
                        {
                            Log.WriteLogComplete(myVendingMachine.Balance);
                            myVendingMachine.FinishTransaction();

                        }
                    }   
                }

                else if (modeSelection == "3")
                {
                    Environment.Exit(0);
                }

                //else if (modeSelection == "4")
                //{
                //    SalesReport.RunSalesReport(myVendingMachine);
                //}
            }
        }
    }
}
