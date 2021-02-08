using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            List<string> integers = new List<string>();

            for (int i = text.Length - 1; i >= 0; i--)
            {
                if (text[i] == '|' || i == 0)
                {
                    for (int j = i; j < text.Length; j++)
                    {

                        if (Char.IsDigit(text[j]))
                        {
                            integers.Add(text[j].ToString());
                        }

                        if (j == text.Length -1)
                        {
                            break;
                        }

                        if (text[j+1] == '|')
                        {
                            break;
                        }

                    }
                }
            }

            Console.WriteLine(string.Join(" ", integers));
        }
    }
}
