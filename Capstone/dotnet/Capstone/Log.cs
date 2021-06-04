using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;

namespace Capstone
{
    static class Log
    {
        static string filePath = Environment.CurrentDirectory;
        static string fileName = "Log.txt";
        static string fileLocation = Path.Combine(filePath, fileName);
        static StreamWriter sw;
        static DateTime now = DateTime.Now;
        public static void WriteLogFedIn(decimal insertedMoney, decimal balance)
        {
            try
            {
                now = DateTime.Now;
                using (sw = new StreamWriter(fileLocation, true))
                {
                    sw.WriteLine($"{now.ToString()} FEED MONEY: {insertedMoney.ToString("C2")} {balance.ToString("C2")}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void WriteLogPurchase(IItem itemPurchased, decimal balance)
        {
            try
            {
                now = DateTime.Now;
                using (sw = new StreamWriter(fileLocation, true))
                {
                    sw.WriteLine($"{now.ToString()} {itemPurchased.Name} {itemPurchased.Slot} {itemPurchased.Price.ToString("C2")} {balance.ToString("C2")}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void WriteLogComplete(decimal balance)
        {
            try
            {
                now = DateTime.Now;
                using (sw = new StreamWriter(fileLocation, true))
                {
                    sw.WriteLine($"{now.ToString()} GIVE CHANGE: {balance.ToString("C2")} $0.00");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
