using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Streams_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            string input = Console.ReadLine();

            while (input != "3:1")
            {
                string[] data = input.Split();
                string command = data[0];

                if (command == "merge")
                {
                    int startIndex = int.Parse(data[1]);
                    int endIndex = int.Parse(data[2]);

                    StringBuilder sb = new StringBuilder();

                    if (startIndex < 0 || startIndex > names.Count - 1)
                    {
                        startIndex = 0;
                    }
                    if (endIndex >= names.Count || endIndex < 0)
                    {
                        endIndex = names.Count - 1;
                    }

                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        sb.Append(names[i]);
                    }
                    names.RemoveRange(startIndex, endIndex - startIndex + 1);
                    names.Insert(startIndex, sb.ToString());

                }
                else if (command == "divide")
                {
                    List<string> currentList = Division(names[int.Parse(data[1])], int.Parse(data[2]));
                    names.RemoveAt(int.Parse(data[1]));

                    for (int i = currentList.Count - 1; i >= 0; i--)
                    {
                        names.Insert(int.Parse(data[1]), currentList[i]);
                    }
                }

                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", names));


        }
        static List<string> Division(string text, int number)
        {
            List<string> substrings = new List<string>();
            if (text.Length % number == 0)
            {
                for (int i = 0; i < text.Length; i++)
                {
                    string currentText = text.Substring(i, text.Length / number);
                    i += text.Length / number - 1;
                    substrings.Add(currentText);
                }
            }
            else if (text.Length % number != 0)
            {
                int remainder = text.Length % number;
                int result = text.Length / number;
                for (int i = 0; i < text.Length; i++)
                {
                    string currentText = text.Substring(i, text.Length / number);
                    i += text.Length / number - 1;
                    substrings.Add(currentText);

                    if (currentText.Length + i + remainder == text.Length - 1)
                    {
                        currentText = text.Substring(i + 1);
                        substrings.Add(currentText);
                        break;
                    }
                }

            }
            return substrings;

        }
    }
}
