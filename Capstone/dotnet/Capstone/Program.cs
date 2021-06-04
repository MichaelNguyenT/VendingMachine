using System;
using System.IO;
using System.Collections.Generic;
namespace Capstone
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Declare and instantiate the use of vending machine and file
            VendingMachine myVendingMachine = new VendingMachine();
            string filePath = Environment.CurrentDirectory;
            string fileName = "vendingmachine.csv";
            string fileLocation = Path.Combine(filePath, fileName);
            myVendingMachine.ItemDictionary = LoadVendingMachine.LoadVending(fileLocation);
            
            //Loops as long as we are in the main menu (0)
            while (myVendingMachine.Mode == 0)
            {
                //Provides the options for the user to select
                Console.WriteLine("\n(1) Display Vending Machine Items");
                Console.WriteLine("(2) Purchase Items");
                Console.WriteLine("(3) Exit");
                string modeSelection = Console.ReadLine();

                //This is the method to display all of the items in the Vending Machine
                if (modeSelection == "1")
                {
                    List<string> listOfItems = myVendingMachine.MakeCollectionOfItems();
                    foreach (string item in listOfItems)
                    {
                        Console.WriteLine(item);
                    }
                }

                //Purchase mode
                else if (modeSelection == "2")
                {
                    myVendingMachine.Mode = 1;
                    while (myVendingMachine.Mode == 1)
                    {
                        //Provides options to insert money, purchase, and finish the transaction
                        Console.WriteLine("\n(1) Feed Money");
                        Console.WriteLine("(2) Purchase Product");
                        Console.WriteLine("(3) Finish Transaction");
                        Console.WriteLine($"Current money provided: ${myVendingMachine.Balance}");
                        string inputSelection = Console.ReadLine();

                        //Detects if the user wants to insert money
                        if (inputSelection == "1")
                        {
                            Console.WriteLine("Please insert a whole dollar amount (e.g. $1, $2, $5, or $10)");
                            string insertAmount = (Console.ReadLine());
                            decimal finalAmount = myVendingMachine.DepositMoney(insertAmount);
                            
                            Log.WriteLogFedIn(finalAmount, myVendingMachine.Balance);
                        }

                        //Detects if the user wants to purchase an item
                        else if (inputSelection == "2")
                        {
                            Console.Write("Enter the item position you would like to purchase: ");
                            string inputPosition = Console.ReadLine().ToUpper();

                            //Checks to make sure the user put in a valid item position and loops until sucessful
                            while(!myVendingMachine.ItemDictionary.ContainsKey(inputPosition))
                            {
                                Console.Write("Please enter a valid item position.");
                                inputPosition = Console.ReadLine().ToUpper();
                            }
                            Console.WriteLine(myVendingMachine.PurchaseItem(inputPosition));

                            //Writes to the log that the user purchased an item
                            Log.WriteLogPurchase(myVendingMachine.ItemDictionary[inputPosition], myVendingMachine.Balance);
                        }

                        //Calls the finish transaction method to dispense change and go back to the main menu
                        else if (inputSelection == "3")
                        {
                            Log.WriteLogComplete(myVendingMachine.Balance);
                            Console.WriteLine(myVendingMachine.FinishTransaction());
                        }
                    }   
                }

                //Exits the program
                else if (modeSelection == "3")
                {
                    Environment.Exit(0);
                }

                //Secret mode to output a salesreport file
                else if (modeSelection == "4")
                {
                    SalesReport.RunSalesReport(myVendingMachine);
                }
            }
        }
    }
}
