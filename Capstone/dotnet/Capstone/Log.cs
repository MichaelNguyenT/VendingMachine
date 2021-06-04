using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;

namespace Capstone
{
    //Class that writes to a Log file, appends
    public static class Log
    {
        //Declare filepath and Date Time
        static string filePath = Environment.CurrentDirectory;
        static string fileName = "Log.txt";
        static string fileLocation = Path.Combine(filePath, fileName);
        static StreamWriter sw;
        static DateTime now = DateTime.Now;

        //Returns a string only for testing purposes
        //Takes an inserted money amount and the balance to write to file
        public static string WriteLogFedIn(decimal insertedMoney, decimal balance)
        {
            string output = "";
            try
            {
                //Current time
                now = DateTime.Now;
                using (sw = new StreamWriter(fileLocation, true))
                {
                    //Writes to the log file how much money was fed in
                    output = ($"{now.ToString()} FEED MONEY: {insertedMoney.ToString("C2")} {balance.ToString("C2")}");
                    sw.WriteLine(output);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return output;
        }

        //Returns a string only for testing purposes
        //Takes the item purchased and the balance to write to file
        public static string WriteLogPurchase(IItem itemPurchased, decimal balance)
        {
            string output = "";
            try
            {
                now = DateTime.Now;
                using (sw = new StreamWriter(fileLocation, true))
                {
                    //Writes to file what was purchased
                    output = ($"{now.ToString()} {itemPurchased.Name} {itemPurchased.Slot} {itemPurchased.Price.ToString("C2")} {balance.ToString("C2")}");
                    sw.WriteLine(output);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return output;
        }

        //Returns a string only for testing purposes
        //Takes a balance amount to write to file
        public static string WriteLogComplete(decimal balance)
        {
            string output = "";
            try
            {
                now = DateTime.Now;
                using (sw = new StreamWriter(fileLocation, true))
                {
                    //Writes the change and balance to log
                    output = ($"{now.ToString()} GIVE CHANGE: {balance.ToString("C2")} $0.00");
                    sw.WriteLine(output);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return output;
        }
    }
}