using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonDon_tGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> integers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int sumRemovedElements = 0;
            while (true)
            {
                int index = int.Parse(Console.ReadLine());
                bool isOutSide = false;
                if (index < 0)
                {
                    integers[0] = integers[integers.Count - 1];
                    index = 0;
                    isOutSide = true;
                }
                else if (index > integers.Count - 1)
                {
                    integers[integers.Count - 1] = integers[0];
                    index = integers.Count - 1;
                    isOutSide = true;
                }

                int valueAtIndex = integers[index];
                sumRemovedElements += valueAtIndex;
                if (!isOutSide)
                {
                    integers.RemoveAt(index);
                }

                if (integers.Count == 0)
                {
                    break;
                }
                integers = ModifyList(integers, valueAtIndex,index);
            }
            Console.WriteLine(sumRemovedElements);
        }
        static List<int> ModifyList(List<int> list,int value,int index)
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
                if (list[i] <= 0)
                {
                    list.RemoveAt(i--);
                }
            }
            return list;
        }
    }
}
