﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    class Animal
    {
        public string Name { get; set; }

        public Animal(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
