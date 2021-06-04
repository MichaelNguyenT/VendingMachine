using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    public class VendingMachine
    {
        //Declare the properties of a Vending Machine. Balance is used as the users amount of money currently in the machine.
        public decimal Balance { get; set; } = 0.00M;

        //Mode is used as which "mode" we are in(purchase mode, main menu mode).
        public int Mode { get; set; } = 0;

        //A collection of IItems in the vending machine(Chips, Drinks, Gum, Candy)
        public Dictionary<string, IItem> ItemDictionary = new Dictionary<string, IItem>();

        //Creates a list that is testable that goes through the Vending Machine ItemDictionary and checks
        //if it is either sold out or in stock
        public List<string> MakeCollectionOfItems()
        {
            List<string> itemCollection = new List<string>();
            foreach (KeyValuePair<string, IItem>  item in ItemDictionary)
            {
                if (item.Value.Inventory == 0)
                {
                    itemCollection.Add($"{item.Value.Slot} {item.Value.Name}: SOLD OUT");
                }
                else
                {
                    itemCollection.Add($"{item.Value.Slot} {item.Value.Name} {item.Value.Price}");
                }
            }
            return itemCollection;
        }


        //Takes an amount of money input by the user and adds it to the balance
        public decimal DepositMoney(string amount)
        {
            decimal decimalAmount = decimal.Parse(amount);

            //Loops through to make sure that the input amount is either a whole amount of 1, 2, 5, or 10
            while (!(decimalAmount == 1 || decimalAmount == 2 ||decimalAmount == 5|| decimalAmount == 10))
            {
                Console.WriteLine("Please enter a valid amount");
                amount = (Console.ReadLine());
                decimalAmount = decimal.Parse(amount);
            }
            decimal finalAmount = decimal.Parse(amount);
            Balance += (finalAmount);

            return finalAmount;
        }

        //User is able to use the PurchaseItem method to select a position
        public string PurchaseItem(string position)
        {
            string print = "";

            //Checks to see if the user has any money
            if (Balance == 0)
            {
                print = "You need to deposit funds to make a purchase";
            }
            //Checks if the amount of money the user has is less than the price of the item
            else if(Balance < ItemDictionary[position].Price)
            {
                print = "Error: Not enough funds for purchase";

            }
            //Checks if the item is in stock
            else if (ItemDictionary[position].Inventory == 0)
            {
                print = "SOLD OUT";
            }
            //User is able to purchase the item and decrements the inventory of that item, subtracts the price from balance
            //sets the print variable to the sound that the item makes, and increments the total sales
            else
            {
                ItemDictionary[position].Inventory -= 1;
                Balance -= ItemDictionary[position].Price;
                print = (ItemDictionary[position].Sound);
                ItemDictionary[position].TotalSales += 1;
            }
            return print;
        }

        //User is able to cash out and stop the transactions to recieve back change in the form of Quarters, Nickles, and Dimes
        public string FinishTransaction()
        {
            decimal quarter = 0.25M;
            decimal nickel = 0.05M;
            decimal dime = 0.10M;
            decimal updatedBalance;
            int quarterCount;
            int nickelCount;
            int dimeCount;

            //Coin count math for each coin to keep track of quarters and decrement the balance
            quarterCount = (int)(Balance / quarter);
            updatedBalance = (decimal)(Balance - quarter * quarterCount);

            dimeCount = (int)(updatedBalance / dime);
            updatedBalance = (decimal)(updatedBalance - dime * dimeCount);

            nickelCount = (int)(updatedBalance / nickel);
            string output = ($"Your change is {Balance.ToString("C2")} in {quarterCount} quarter(s), {dimeCount} dime(s), and {nickelCount} nickel(s)" );

            //Sets the balance to zero after the user recieves their change back and mode to zero for the main menu
            Balance = 0;
            Mode = 0;

            return output;

        }
    }
}
