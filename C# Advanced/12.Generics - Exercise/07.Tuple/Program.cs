using System;
using System.Collections.Generic;

namespace Tuples
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split();
            string name = arr[0] + " " + arr[1];
            string city = arr[2];
            Tuple<string, string> myTuple = new Tuple<string, string>(name,city);
            Console.WriteLine(myTuple.ToString());
            string[] arrTwo = Console.ReadLine().Split();
            string nameTwo = arrTwo[0];
            int litersOfBeer = int.Parse(arrTwo[1]);
            Tuple<string, int> myTupleTwo = new Tuple<string, int>(nameTwo, litersOfBeer);
            Console.WriteLine(myTupleTwo.ToString());
            string[] arrThree = Console.ReadLine().Split();
            int integer = int.Parse(arrThree[0]);
            double currentDouble = double.Parse(arrThree[1]);
            Tuple<int, double> myTupleThree = new Tuple<int, double>(integer, currentDouble);
            Console.WriteLine(myTupleThree.ToString());

            
                              
        }
    }
}
