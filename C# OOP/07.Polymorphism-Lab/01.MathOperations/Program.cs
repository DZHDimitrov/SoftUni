﻿using _01.MathOperations;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Operations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            MathOperations mo = new MathOperations();
            Console.WriteLine(mo.Add(2, 3));
            Console.WriteLine(mo.Add(2.2, 3.3, 5.5));
            Console.WriteLine(mo.Add(2.2m, 3.3m, 4.4m));


        }
    }
}
