﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    class Gum : IItem
    {
        public string Name { get; private set; }

        public string Sound { get; private set; } = "Chew Chew, Yum!";

        public decimal Price { get; private set; }

        public int Inventory { get; set; } = 5;

        public string Slot { get; private set; }
    }
}