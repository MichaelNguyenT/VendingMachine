using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    //Candy object that utilizes the IItem Interface
    public class Candy : IItem 
    {
        public string Name { get; private set; }

        public string Sound { get; private set; } = "Munch Munch, Yum!";

        public decimal Price { get; private set; }

        public int Inventory { get; set; } = 5;

        public int TotalSales { get; set; } = 0;
             
        public string Slot { get; private set; }
        public Candy(string slot, string name,  decimal price)
        {
            Name = name;
            Slot = slot;
            Price = price;
        }

    }
}
