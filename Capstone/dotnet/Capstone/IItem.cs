using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    interface IItem
    {
        public string Name { get;  }

        public string Sound { get;  }

        public decimal Price { get; }

        public string Slot { get; }

        public int Inventory { get; set; }

    }
}
