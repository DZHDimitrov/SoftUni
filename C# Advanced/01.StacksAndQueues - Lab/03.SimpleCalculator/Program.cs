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
            string[] numbers = Console.ReadLine().Split();
            Stack<string> stack = new Stack<string>(numbers.Reverse());

            while (stack.Count > 1)
            {
                int firstNumber = int.Parse(stack.Pop());
                string currentOperator = stack.Pop();
                int secondNumber = int.Parse(stack.Pop());
                switch (currentOperator)
                {
                    case "+":
                        stack.Push((firstNumber + secondNumber).ToString());
                        break;
                    case "-":
                        stack.Push((firstNumber - secondNumber).ToString());
                        break;
                }
            }
            Console.WriteLine(stack.Pop());
        }
    }
}