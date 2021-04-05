using System;
using System.Collections.Generic;
using System.Linq;

namespace Tuples
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split();
            string name = arr[0] + " " + arr[1];
            string city = arr[2];
            List <string> list = arr.Skip(3).ToList();
            string town = string.Join(" ", list);

            Tuple<string, string,string> myTuple = new Tuple<string,string, string>(name,city,town);

            string[] arrTwo = Console.ReadLine().Split();
            bool drunk = arrTwo[2] == "drunk" ? true : false;
            Tuple<string, int,bool> myTupleTwo = new Tuple<string, int,bool>(arrTwo[0],int.Parse(arrTwo[1]),drunk);

            string[] arrThree = Console.ReadLine().Split();

            Tuple<string, double, string> myTupleThree = new Tuple<string, double,string>(arrThree[0], double.Parse(arrThree[1]), arrThree[2]);

            Console.WriteLine(myTuple);
            Console.WriteLine(myTupleTwo);
            Console.WriteLine(myTupleThree);

            
                              
        }
    }
}
