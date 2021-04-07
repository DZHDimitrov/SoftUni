using System;
using System.Collections.Generic;
using System.Linq;

namespace ListyIterator
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();
            ListyIterator<string> currentIterator = null;
            while (input != "END")
            {
                string[] arr = input.Split();

                switch (arr[0])
                {
                    case "Create":
                        List<string> currentList = arr.Skip(1).ToList();
                       currentIterator = new ListyIterator<string>(currentList);
                        break;
                    case "Move":
                        Console.WriteLine(currentIterator.Move());
                        break;
                    case "Print":
                        currentIterator.Print();
                        break;
                    case "HasNext":
                        Console.WriteLine(currentIterator.HasNext());
                        break;
                }
                input = Console.ReadLine();
            }
        }
    }
}
