﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace CSharpAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            decimal sum = 0;
            for (int i = 0; i < numbers; i++)
            {
                decimal curNum = decimal.Parse(Console.ReadLine());
                sum += curNum;
            }
            Console.WriteLine(sum);
        }
    }
}
