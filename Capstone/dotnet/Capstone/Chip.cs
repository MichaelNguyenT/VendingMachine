using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    class Chip : IItem
    {
        public string Name { get; private set; }

        public string Sound { get; private set; } = "Crunch Crunch, Yum!";

        public decimal Price { get; private set; }

        public int Inventory { get; set; } = 5;

        public string Slot { get; private set; }
        public Chip(string slot, string name,  decimal price)
        {
            Name = name;
            Slot = slot;
            Price = price;
        }
    }

}
