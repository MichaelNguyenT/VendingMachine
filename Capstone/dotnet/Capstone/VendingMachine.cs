using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    class VendingMachine
    {

        public decimal Balance { get; private set; } = 0.00M;

        public int Mode { get; set; } = 0;

        public Dictionary<string, IItem> ItemDictionary = new Dictionary<string, IItem>();

        public void CheckAll()
        {
            foreach (KeyValuePair<string, IItem>  item in ItemDictionary)
            {
                if (item.Value.Inventory == 0)
                {
                    Console.WriteLine($"{item.Value.Slot} {item.Value.Name}: SOLD OUT");
                }
                else
                {
                    Console.WriteLine($"{item.Value.Slot} {item.Value.Name} {item.Value.Price}");


                }
            }
                
        }

        public void DepositMoney(decimal amount)
        {
            Balance += amount;
            
        }

        public void PurchaseItem(string position)
        {
            if (Balance == 0)
            {
                Console.WriteLine("You need to deposit funds to make a purchase");
            }
            else if(Balance < ItemDictionary[position].Price)
            {
                Console.WriteLine("Error: Not enough funds for purchase");

            }
            else if (ItemDictionary[position].Inventory == 0)
            {
                Console.WriteLine("SOLD OUT");
            }
            else
            {
                ItemDictionary[position].Inventory -= 1;
                Balance -= ItemDictionary[position].Price;
                Console.WriteLine(ItemDictionary[position].Sound);
            }
        }

        public void FinishTransaction()
        {
            decimal quarter = 0.25M;
            decimal nickel = 0.05M;
            decimal dime = 0.10M;
            decimal updatedBalance;
            int quarterCount;
            int nickelCount;
            int dimeCount;

            quarterCount = (int)(Balance / quarter);
            updatedBalance = (decimal)(Balance - quarter * quarterCount);

            dimeCount = (int)(updatedBalance / dime);
            updatedBalance = (decimal)(updatedBalance - dime * dimeCount);

            nickelCount = (int)(updatedBalance / nickel);
            Console.WriteLine($"Your change is {Balance.ToString("C2")} in {quarterCount} quarter(s), {dimeCount} dime(s), and {nickelCount} nickel(s)" );
            Balance = 0;
            
            Mode = 0;

            

        }
    }
}
