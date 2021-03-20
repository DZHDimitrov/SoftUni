using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string input = Console.ReadLine();

            while (input != "Generate")
            {
                string[] cmdArgs = input.Split(">>>", StringSplitOptions.RemoveEmptyEntries);
                string command = cmdArgs[0];

                if (command == "Contains")
                {
                    string substring = cmdArgs[1];
                    if (text.Contains(substring))
                    {
                        Console.WriteLine($"{text} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (command == "Flip")
                {
                    int startIndex = int.Parse(cmdArgs[2]);
                    int endIndex = int.Parse(cmdArgs[3]);

                    Console.WriteLine(text = FlipCommand(text, cmdArgs.Skip(1).ToArray(), startIndex, endIndex));
                }
                else if (command == "Slice")
                {
                    int startIndex = int.Parse(cmdArgs[1]);
                    int endIndex = int.Parse(cmdArgs[2]);
                    Console.WriteLine(text = SliceCommand(text, startIndex, endIndex));

                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Your activation key is: {text}");
        }

        private static string SliceCommand(string text, int startIndex, int endIndex)
        {
            List<string> changedText = text.ToCharArray().Select(x => x.ToString()).ToList();

            if (endIndex == text.Length - 1)
            {
                changedText.RemoveRange(startIndex, endIndex - startIndex + 1);
            }
            else
            {
                changedText.RemoveRange(startIndex, endIndex - startIndex);
            }


            text = string.Join("", changedText);

            return text;
        }
        private static string FlipCommand(string text, string[] cmdArgs, int startIndex, int endIndex)
        {
            string upperOrLower = cmdArgs[0];
            List<string> changedText = text.ToCharArray().Select(x => x.ToString()).ToList();
            if (upperOrLower == "Upper")
            {
                for (int i = startIndex; i < endIndex; i++)
                {
                    changedText[i] = changedText[i].ToUpper();
                }
            }
            else if (upperOrLower == "Lower")
            {
                for (int i = startIndex; i < endIndex; i++)
                {
                    changedText[i] = changedText[i].ToLower();
                }
            }

            text = string.Join("", changedText);

            return text;
        }
    }
}
