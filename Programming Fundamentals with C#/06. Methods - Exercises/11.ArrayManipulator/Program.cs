using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _11.ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] data = input.Split(" ");

                switch (data[0])
                {
                    case "exchange":
                        int index = int.Parse(data[1]);
                        if (index < 0 || index > numbers.Count - 1)
                        {
                            Console.WriteLine("Invalid index");
                            input = Console.ReadLine();
                            continue;
                        }
                        numbers = ExchangePlaces(numbers, index);
                        break;
                    case "max":
                        if (data[1] == "even" && numbers.Any(x => x % 2 == 0))
                        {
                            int maxEvenIndex = MaxEvenElement(numbers);
                            Console.WriteLine(maxEvenIndex);
                        }

                        else if (data[1] == "odd" && numbers.Any(x => x % 2 != 0))
                        {
                            int maxOddIndex = MaxOddElement(numbers);
                            Console.WriteLine(maxOddIndex);
                        }
                        else
                        {
                            Console.WriteLine("No matches");
                        }
                        break;
                    case "min":
                        if (data[1] == "even" && numbers.Any(x => x % 2 == 0))
                        {
                            int minEvenIndex = MinEvenElement(numbers);

                            Console.WriteLine(minEvenIndex);
                        }
                        else if (data[1] == "odd" && numbers.Any(x => x % 2 != 0))
                        {
                            int minOddIndex = MinOddElement(numbers);

                            Console.WriteLine(minOddIndex);
                        }
                        else
                        {
                            Console.WriteLine("No matches");
                        }
                        break;
                    case "first":
                        if (int.Parse(data[1]) > numbers.Count)
                        {
                            Console.WriteLine("Invalid count");
                            input = Console.ReadLine();
                            continue;
                        }
                        if (data[2] == "even" && numbers.Any(x => x % 2 == 0))
                        {
                            PrintFirstTwoEven(numbers, int.Parse(data[1]));
                        }
                        else if (data[2] == "odd" && numbers.Any(x => x % 2 != 0))
                        {
                            PrintFirstTwoOdd(numbers, int.Parse(data[1]));
                        }
                        break;
                    case "last":
                        if (int.Parse(data[1]) > numbers.Count)
                        {
                            Console.WriteLine("Invalid count");
                            input = Console.ReadLine();
                            continue;
                        }
                        if (data[2] == "even")
                        {
                            PrintLastTwoEven(numbers, int.Parse(data[1]));
                        }
                        else if (data[2] == "odd")
                        {
                            PrintLastTwoOdd(numbers, int.Parse(data[1]));
                        }
                        break;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"[{string.Join(", ", numbers)}]");
        }

        static List<int> ExchangePlaces(List<int> numbers, int index)
        {
            List<int> numbersToReplace = new List<int>();
            for (int i = index + 1; i < numbers.Count; i++)
            {
                numbersToReplace.Add(numbers[i]);
                numbers.RemoveAt(i--);
            }
            for (int i = numbersToReplace.Count - 1; i >= 0; i--)
            {
                numbers.Insert(0, numbersToReplace[i]);
            }

            return numbers;
        }
        static int MaxEvenElement(List<int> numbers)
        {

            int maxEvenNumber = numbers.Where(x => x % 2 == 0).Max();
            int index = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == maxEvenNumber)
                {
                    index = i;
                }
            }
            return index;
        }
        static int MaxOddElement(List<int> numbers)
        {

            int maxOddNumber = numbers.Where(x => x % 2 != 0).Max();
            int index = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == maxOddNumber)
                {
                    index = i;
                }
            }
            return index;
        }
        static int MinEvenElement(List<int> numbers)
        {

            int minEvenNumber = numbers.Where(x => x % 2 == 0).Min();
            int index = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == minEvenNumber)
                {
                    index = i;
                }
            }
            return index;
        }
        static int MinOddElement(List<int> numbers)
        {
            int minOddNumber = numbers.Where(x => x % 2 != 0).Min();
            int index = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == minOddNumber)
                {
                    index = i;
                }
            }
            return index;
        }
        static void PrintFirstTwoEven(List<int> numbers, int neededNumbers)
        {
            List<int> currentNumbers = new List<int>();
            int counter = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    currentNumbers.Add(numbers[i]);
                    counter++;
                }
                if (counter == neededNumbers)
                {
                    break;
                }
            }
            Console.WriteLine($"[{string.Join(", ", currentNumbers)}]");
        }
        static void PrintFirstTwoOdd(List<int> numbers, int neededNumbers)
        {
            List<int> currentNumbers = new List<int>();
            int counter = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] % 2 != 0)
                {
                    currentNumbers.Add(numbers[i]);
                    counter++;
                }
                if (counter == neededNumbers)
                {
                    break;
                }
            }
            Console.WriteLine($"[{string.Join(", ", currentNumbers)}]");
        }

        static void PrintLastTwoEven(List<int> numbers, int neededNumbers)
        {
            List<int> currentNumbers = new List<int>();
            int counter = 0;
            for (int i = numbers.Count - 1; i >= 0; i--)
            {
                if (numbers[i] % 2 == 0)
                {
                    currentNumbers.Add(numbers[i]);
                    counter++;
                }
                if (counter == neededNumbers)
                {
                    break;
                }
            }
            Console.WriteLine($"[{string.Join(", ", currentNumbers)}]");
        }
        static void PrintLastTwoOdd(List<int> numbers, int neededNumbers)
        {
            List<int> currentNumbers = new List<int>();
            int counter = 0;
            for (int i = numbers.Count - 1; i >= 0; i--)
            {
                if (numbers[i] % 2 != 0)
                {
                    currentNumbers.Add(numbers[i]);
                    counter++;
                }
                if (counter == neededNumbers)
                {
                    break;
                }
            }
            Console.WriteLine($"[{string.Join(", ", currentNumbers)}]");
        }
    }
}
