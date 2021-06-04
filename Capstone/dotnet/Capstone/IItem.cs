using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    //An interface for the items that require these properties to be made
    public interface IItem
    {
        public string Name { get;  }

        public string Sound { get;  }

        public decimal Price { get; }

        public string Slot { get; }

        public int Inventory { get; set; }

        public int TotalSales { get; set; }

    }
}
