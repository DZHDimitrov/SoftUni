using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ThePianist
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string input = Console.ReadLine();

            while (input != "Reveal")
            {
                string[] array = input.Split(":|:", StringSplitOptions.RemoveEmptyEntries);
                string command = array[0];

                switch (command)
                {
                    case "InsertSpace":
                        int index = int.Parse(array[1]);
                        text = text.Insert(index, " ");
                        Console.WriteLine(text);
                        break;
                    case "Reverse":
                        string givenText = array[1];
                        if (text.Contains(givenText))
                        {
                            int indexoftext = text.IndexOf(givenText);
                            string substring = text.Substring(indexoftext, givenText.Length);
                            StringBuilder sb = new StringBuilder();
                            for (int i = substring.Length - 1; i >= 0; i--)
                            {
                                sb.Append(substring[i]);
                            }
                            string reversed = sb.ToString();

                            text = text.Remove(indexoftext, substring.Length);
                            text = text.Insert(text.Length, reversed);
                            Console.WriteLine(text);
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;

                    case "ChangeAll":
                        string partOfText = array[1];
                        string replacement = array[2];
                        if (text.Contains(partOfText))
                        {
                            text = text.Replace(partOfText, replacement);
                            Console.WriteLine(text);
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;

                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"You have a new text message: {text}");
        }

    }
}
