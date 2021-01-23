using System;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int men = int.Parse(Console.ReadLine());
            int women = int.Parse(Console.ReadLine());
            int tables = int.Parse(Console.ReadLine());
            bool isFull = false;

            for (int i = 1; i <= men; i++)
            {
                for (int j = 1; j <= women; j++)
                {
                    if (tables <= 0)
                    {
                        isFull = true;
                        break;
                    }
                    Console.Write($"({i} <-> {j}) ");

                    tables -= 1;
                }
                if (isFull)
                {
                    break;
                }
            }
        }
    }
}
