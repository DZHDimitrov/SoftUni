using System;
using System.Linq;

namespace _10.TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "END")
            {
                string number = input;
                bool isPalindrome = CheckIfPalindrome(number);
                if (isPalindrome)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
                input = Console.ReadLine();
            }
        }

        static bool CheckIfPalindrome(string input)
        {
            string[] array = new string[input.Length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = input[i].ToString();
            }

            for (int i = 0; i < array.Length / 2; i++)
            {
                if (array[i] != array[array.Length - 1 - i])
                {
                    return false;
                }
            }
            return true;

        }
    }
}

