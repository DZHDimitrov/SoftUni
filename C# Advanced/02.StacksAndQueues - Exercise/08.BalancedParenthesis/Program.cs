using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Stack<string> stack = new Stack<string>();
            Queue<string> queue = new Queue<string>();

            for (int i = 0; i < text.Length / 2; i++)
            {
                stack.Push(text[i].ToString());
            }
            for (int i = text.Length / 2; i < text.Length; i++)
            {
                queue.Enqueue(text[i].ToString());
            }
            bool areEqual = true;
            while (stack.Count > 0 && queue.Count > 0)
            {
                string first = stack.Pop();
                string second = queue.Dequeue();

                if (!((first == "[" && second == "]") || (first == "(" && second == ")") || (first == "{" && second == "}")))
                {
                    areEqual = false;
                    break;
                }

            }
            if (areEqual && queue.Count == 0)
            {
                Console.WriteLine("YES");
            }

            else
            {
                Console.WriteLine("NO");
            }

        }
    }
}