using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ObjectsAndClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split();
            Random rnd = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                int randomIndex = rnd.Next(0, array.Length);
                string currentWord = array[i];
                array[i] = array[randomIndex];
                array[randomIndex] = currentWord;

            }

            Console.WriteLine(string.Join(Environment.NewLine, array));

        }
    }
}

