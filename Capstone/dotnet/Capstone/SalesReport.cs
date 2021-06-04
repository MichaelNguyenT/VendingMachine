using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace Capstone
{
    public static class  SalesReport
    {
        //Declare the filepath and filename
        static string filePath = Environment.CurrentDirectory;
        static string fileName = "SalesReport.txt";
        static string fileLocation = Path.Combine(filePath, fileName);

        //Returning the List<string> is used for testing.
        //This method overwrites the SalesReport file to see how much was sold and how much money was made
     static public List<string> RunSalesReport(VendingMachine vendingMachine)
        {
            List<string> output = new List<string>();
            try
            {
                using StreamWriter sw = new StreamWriter(fileLocation, false);
                {
                    //Keeps track to see if we have reached the end of the Dictionary
                    //Sum is used for the total
                    int count = 0;
                    decimal sum = 0.00M;

                    //Loops through the Dictionary to write to the text file
                    foreach (KeyValuePair<string, IItem> item in vendingMachine.ItemDictionary)
                    {
                        sw.WriteLine($"{item.Value.Name}|{item.Value.TotalSales}");
                        sum += item.Value.Price * item.Value.TotalSales;

                        //Adds to the list so that we can test it
                        output.Add($"{item.Value.Name}|{item.Value.TotalSales}");

                        //Once we reach the end of the Dictionary, we write to file the TOTAL SALES and the sum of everything sold
                        count++;
                        if (count == vendingMachine.ItemDictionary.Count)
                        {
                            sw.WriteLine("");
                            sw.WriteLine("**TOTAL SALES**");
                            sw.WriteLine(sum.ToString("C2"));

                            output.Add("");
                            output.Add("**TOTAL SALES**");
                            output.Add($"{sum.ToString("C2")}"); 
                        }   
                    }
                }              
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            //Returns a List<string> for testing purposes
            return output;
         }  
    }
}
