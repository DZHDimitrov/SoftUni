using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            int operations = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();
            Stack<string> texts = new Stack<string>();
            texts.Push(sb.ToString());
            for (int i = 0; i < operations; i++)
            {
                string[] array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string cmd = array[0];

                switch (cmd)
                {
                    case "1":
                        sb.Append(array[1]);
                        texts.Push(sb.ToString());
                        break;
                    case "2":
                        int number = int.Parse(array[1]);
                        sb.Remove(sb.Length - number, number);
                        texts.Push(sb.ToString());
                        break;
                    case "3":
                        int index = int.Parse(array[1]);
                        Console.WriteLine(sb[index - 1]);
                        break;
                    case "4":
                        texts.Pop();
                        sb = new StringBuilder();
                        sb.Append(texts.Peek());
                        break;
                }
            }
        }
    }
}