using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    //Loads the vending maching by reading the file and outputs the dictionary so that the vending machine can equal that
    public static class LoadVendingMachine
    {
        public static Dictionary<string, IItem> LoadVending(string fileLocation)
        {
            //Declare Dictionary to be loaded
            Dictionary<string, IItem> fullVendingMachine = new Dictionary<string, IItem>();

            try
            {
                using (StreamReader sr = new StreamReader(fileLocation))
                {
                    //Loops through the text file and checks to see what type of IItem it is
                    //Creates the object and loads it into the dictionary
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] lineArray = line.Split("|");
                        if (lineArray[lineArray.Length - 1] == "Candy")
                        {
                            Candy myCandy = new Candy(lineArray[0], lineArray[1], decimal.Parse(lineArray[2]));
                            fullVendingMachine.Add(myCandy.Slot, myCandy);
                        }
                        else if (lineArray[lineArray.Length - 1] == "Chip")
                        {
                            Chip myChip = new Chip(lineArray[0], lineArray[1], decimal.Parse(lineArray[2]));
                            fullVendingMachine.Add(myChip.Slot, myChip);
                        }
                        else if (lineArray[lineArray.Length - 1] == "Drink")
                        {
                            Drink myDrink = new Drink(lineArray[0], lineArray[1], decimal.Parse(lineArray[2]));
                            fullVendingMachine.Add(myDrink.Slot, myDrink);
                        }
                        else if (lineArray[lineArray.Length - 1] == "Gum")
                        {
                            Gum myGum = new Gum(lineArray[0], lineArray[1], decimal.Parse(lineArray[2]));
                            fullVendingMachine.Add(myGum.Slot, myGum);
                        }
                    }
                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }
            return fullVendingMachine;
        }
    }
}
