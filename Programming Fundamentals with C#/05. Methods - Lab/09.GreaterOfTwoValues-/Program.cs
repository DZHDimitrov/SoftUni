using System;

namespace _09.GreaterOfTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string variableType = Console.ReadLine();
            string firstElement = Console.ReadLine();
            string secondElement = Console.ReadLine();

            switch (variableType)
            {
                case "int":
                    int maxNumber = MaxFromInts(int.Parse(firstElement), int.Parse(secondElement));
                    Console.WriteLine(maxNumber);
                    break;
                case "char":
                    char maxChar = MaxFromChars(char.Parse(firstElement), char.Parse(secondElement));
                    Console.WriteLine(maxChar);
                    break;
                case "string":
                    string maxText = MaxFromText(firstElement, secondElement);
                    Console.WriteLine(maxText);
                    break;
            }
        }

        static int MaxFromInts(int first, int second)
        {
            if (first > second)
            {
                return first;
            }
            else if (first < second)
            {
                return second;
            }
            throw new ArgumentException();
        }
        static char MaxFromChars(char first, char second)
        {
            if (first > second)
            {
                return first;
            }
            else if (first < second)
            {
                return second;
            }
            throw new ArgumentException();
        }
        static string MaxFromText(string first, string second)
        {
            if (first[0] > second[0])
            {
                return first;
            }
            else if (first[0] < second[0])
            {
                return second;
            }
            throw new ArgumentException();
        }
    }
}
