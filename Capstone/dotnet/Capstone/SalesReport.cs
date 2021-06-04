using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace Capstone
{
    static class  SalesReport
    {
        static string filePath = Environment.CurrentDirectory;
        static string fileName = "SalesReport.txt";
        static string fileLocation = Path.Combine(filePath, fileName);
        static Dictionary<string, int> inputSalesReport = new Dictionary<string, int>();
       
        
     static public void RunSalesReport(VendingMachine vendingMachine)
        {
            try
            {
                using StreamReader sr = new StreamReader(fileLocation);

                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        if (line == "")
                        {
                            sr.Close();
                            break;
                        }
                        string[] inputSalesArray = line.Split("|");
                        int numberParse = int.Parse(inputSalesArray[1]);
                        inputSalesReport.Add(inputSalesArray[0], numberParse);

                    }
                }
                using StreamWriter sw = new StreamWriter(fileLocation);
                {
                        
                    int count = 0;
                    foreach (KeyValuePair<string, IItem> item in vendingMachine.ItemDictionary)
                    {
                        count++;
                        if (count == vendingMachine.ItemDictionary.Count)
                        {

                            sw.WriteLine("");
                            sw.WriteLine("**TOTAL SALES**");
                        }
                        else
                        {
                                
                            if (inputSalesReport.ContainsKey(item.Value.Name))
                            {
                                inputSalesReport[item.Value.Name] += item.Value.TotalSales;
                                sw.WriteLine($"{item.Value.Name}|{inputSalesReport[item.Value.Name]}");
                            }
                            else
                            {
                                sw.WriteLine($"{item.Value.Name}|{item.Value.TotalSales}");
                            }
                                
                        }


                    }
                }
                
            
                
            }
            catch (Exception e)
            {

                Console.WriteLine(e.StackTrace);
        
            }
         }  
        
        
        
        
	
    }
}
