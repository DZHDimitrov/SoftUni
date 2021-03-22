using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int capacity = int.Parse(Console.ReadLine());
            Stack<int> box = new Stack<int>(clothes);
            int counter = 0;
            while (box.Count > 1)
            {

                int currentDress = box.Pop();
                if (currentDress + box.Peek() <= capacity)
                {
                    box.Push(currentDress + box.Pop());
                }
                else
                {
                    box.Push(box.Pop());
                    counter++;
                }
            }
            Console.WriteLine(counter + 1);

        }
    }
}