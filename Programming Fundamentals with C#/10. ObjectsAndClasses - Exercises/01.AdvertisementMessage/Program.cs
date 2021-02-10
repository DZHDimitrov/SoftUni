using System;

namespace _01.AdvertisementMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrOne = { "Excellent product.", "Such a great product.", "I always use that product.",
                    "Best product of its category.", "Exceptional product.", "I can’t live without this product." };

            string[] arrTwo = { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };

            string[] arrThree = { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };

            string[] arrFour = { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            Random rand = new Random();

            int number = int.Parse(Console.ReadLine());
            string[] newArray = new string[4];

            for (int i = 0; i < number; i++)
            {
                int first = rand.Next(0, arrOne.Length);
                int second= rand.Next(0, arrTwo.Length);
                int third= rand.Next(0, arrThree.Length);
                int fourth= rand.Next(0, arrFour.Length);
                Console.WriteLine($"{arrOne[first]}{arrTwo[second]}{arrThree[third]} - {arrFour[fourth]}");
            }
        }
    }
}
