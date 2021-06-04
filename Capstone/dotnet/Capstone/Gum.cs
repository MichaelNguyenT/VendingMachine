using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    //Gum object that utilizes the IItem Interface
    public class Gum : IItem
    {
        public string Name { get; private set; }

        public string Sound { get; private set; } = "Chew Chew, Yum!";

        public decimal Price { get; private set; }

        public int Inventory { get; set; } = 5;

        public int TotalSales { get; set; } = 0;

        public string Slot { get; private set; }
        public Gum(string slot, string name, decimal price)
        {
            Name = name;
            Slot = slot;
            Price = price;
        }
    }
}
