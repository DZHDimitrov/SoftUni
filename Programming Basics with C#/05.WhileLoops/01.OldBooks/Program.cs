using System;

namespace NewExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            string book = Console.ReadLine();
            bool isTrue = false;
            int booksCounter = 0;

            while (true)
            {
                string findBook = Console.ReadLine();

                if (findBook == "No More Books")
                {
                    break;
                }

                else if (findBook == book)
                {
                    isTrue = true;
                    break;
                }
                booksCounter++;
            }
            if (isTrue)
            {
                Console.WriteLine($"You checked {booksCounter} books and found it.");
            }
            else if (isTrue == false)
            {
                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {booksCounter} books.");
            }
        }
    }
}
