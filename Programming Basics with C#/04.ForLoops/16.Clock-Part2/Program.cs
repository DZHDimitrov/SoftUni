using System;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int hours = 0; hours < 24; hours++)
            {
                for (int mins = 0; mins < 60; mins++)
                {
                    for (int sec = 0; sec < 60; sec++)
                    {
                        Console.WriteLine($"{hours} : {mins} : {sec}");
                    }

                }
            }
        }
    }
}