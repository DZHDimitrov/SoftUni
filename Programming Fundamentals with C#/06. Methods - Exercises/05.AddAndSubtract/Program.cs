using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _11.ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());
            int firstResult = GetSum(first, second);
            int secondReSult = Subtract(firstResult, third);

            Console.WriteLine(secondReSult);

        }

        static int GetSum(int first,int second)
        {
            return first + second;
        }
        static int Subtract(int result, int third)
        {
            return result - third;
        }

        
    }
}
