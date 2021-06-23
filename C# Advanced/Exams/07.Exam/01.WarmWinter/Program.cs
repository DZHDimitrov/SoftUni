using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace CSharpAdvanced
{
    class Program
    {
        class MySet
        {
            public int FirstValue { get; set; }

            public int SecondValue { get; set; }

            public int Total => this.FirstValue + this.SecondValue;
        }
        static void Main(string[] args)
        {
            int[] hats = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] scarfs = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> stackHats = new Stack<int>(hats);
            Queue<int> queueScarfs = new Queue<int>(scarfs);
            List<MySet> values = new List<MySet>();

            while (stackHats.Count > 0 && queueScarfs.Count > 0)
            {
                if (stackHats.Peek() > queueScarfs.Peek())
                {
                    MySet set = new MySet();
                    set.FirstValue = stackHats.Pop();
                    set.SecondValue = queueScarfs.Dequeue();
                    values.Add(set);
                }
                else if (stackHats.Peek() < queueScarfs.Peek())
                {
                    stackHats.Pop();
                }
                else
                {
                    queueScarfs.Dequeue();
                    var hatValue = stackHats.Pop();
                    hatValue++;
                    stackHats.Push(hatValue);
                }
            }
            var test = values.OrderByDescending(x => x.Total).First();
            Console.WriteLine($"The most expensive set is: {values.OrderByDescending(x => x.Total).First().Total}");
            Console.WriteLine(string.Join(" ", values.Select(x => x.Total).ToArray()));
        }


        static string[][] FillMatrix(int size)
        {
            string[][] matrix = new string[size][];

            for (int i = 0; i < matrix.Length; i++)
            {
                string[] line = string.Join("", Console.ReadLine().ToCharArray().Select(x => x.ToString()).ToArray()).Split(' ', StringSplitOptions.RemoveEmptyEntries);
                matrix[i] = new string[line.Length];
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = line[j];
                }
            }

            return matrix;
        }

        static void PrintMatrix(string[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(string.Join("", matrix[i]));
            }
        }

    }
}