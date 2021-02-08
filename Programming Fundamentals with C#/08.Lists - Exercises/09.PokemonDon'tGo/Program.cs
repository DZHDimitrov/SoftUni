using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonDon_tGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> integers = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int sumRemovedElements = 0;
            int valueAtIndex = 0;
            while (true)
            {
                int index = int.Parse(Console.ReadLine());
                bool isOutSide = false;

                if (index < 0)
                {
                    valueAtIndex = integers[0];
                    integers[0] = integers[integers.Count - 1];
                    isOutSide = true;
                }
                else if (index > integers.Count - 1)
                {
                    valueAtIndex = integers[integers.Count - 1];
                    integers[integers.Count - 1] = integers[0];
                    isOutSide = true;
                }
                else
                {
                    valueAtIndex = integers[index];
                }

                sumRemovedElements += valueAtIndex;
                if (!isOutSide)
                {
                    integers.RemoveAt(index);
                }

                if (integers.Count == 0)
                {
                    break;
                }
                integers = ModifyList(integers, valueAtIndex);
            }
            Console.WriteLine(sumRemovedElements);
        }
        static List<int> ModifyList(List<int> list,int value)
        {
            for (int i = 0; i < list.Count; i++)
            {
                
                if (list[i] <= value)
                {
                    list[i] += value;
                }
                else if (list[i] > value)
                {
                    list[i] -= value;
                }
            }
            return list;
        }
    }
}
