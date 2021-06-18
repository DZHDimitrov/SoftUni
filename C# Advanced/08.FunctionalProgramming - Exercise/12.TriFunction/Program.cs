using System;

namespace _12.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Func<string, int, bool> myFunc = (name, length) =>
            {
                int counter = 0;
                for (int i = 0; i < name.Length; i++)
                {
                    counter += name[i];
                }
                if (counter >= length)
                {
                    return true;
                }
                return false;
            };

            foreach (var name in names)
            {
                if (myFunc(name, number))
                {
                    Console.WriteLine(name);
                    break;
                }
            }
        }
    }
}
