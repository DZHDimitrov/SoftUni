using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(numbers);
            string input = Console.ReadLine().ToLower();
            while (input != "end")
            {
                string[] array = input.Split();
                string command = array[0];
                switch (command)
                {
                    case "add":
                        int firstNumber = int.Parse(array[1]);
                        int secondNumber = int.Parse(array[2]);
                        stack.Push(firstNumber);
                        stack.Push(secondNumber);
                        break;
                    case "remove":
                        int removeNumbers = int.Parse(array[1]);
                        if (removeNumbers <= stack.Count)
                        {
                            for (int i = 0; i < removeNumbers; i++)
                            {
                                stack.Pop();
                            }
                        }
                        break;
                }
                input = Console.ReadLine().ToLower();
            }
            Console.WriteLine($"Sum: {stack.Sum()}");

        }
    }
}