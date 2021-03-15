using System;
using System.Collections.Generic;
using System.Linq;

namespace ThePianist
{

    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string input = Console.ReadLine();

            while (input != "Travel")
            {
                string[] array = input.Split(new char[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string command = array[0];
                switch (command)
                {
                    case "Add":
                        int index = int.Parse(array[2]);
                        string currentText = array[3];
                        if (index <= text.Length - 1)
                        {
                            text = text.Insert(index, currentText);
                        }
                        Console.WriteLine(text);
                        break;
                    case "Remove":

                        int startIndex = int.Parse(array[2]);
                        int endIndex = int.Parse(array[3]);

                        if ((startIndex >= 0 && startIndex <= text.Length - 1) && (endIndex >= 0 && endIndex <= text.Length - 1))
                        {
                            text = text.Remove(startIndex, endIndex - startIndex + 1);
                        }
                        Console.WriteLine(text);
                        break;
                    case "Switch":
                        string oldString = array[1];
                        string newString = array[2];
                        if (text.Contains(oldString))
                        {
                            text = text.Replace(oldString, newString);
                        }
                        Console.WriteLine(text);
                        break;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {text}");
        }
    }
}
