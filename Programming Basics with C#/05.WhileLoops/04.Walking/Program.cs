using System;

namespace NewExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int stepsSum = 0;
            int goal = 10000;
            bool isHome = false;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Going home")
                {
                    isHome = true;
                    continue;
                }
                int currentSteps = int.Parse(input);

                stepsSum += currentSteps;
                if (stepsSum >= goal)
                {
                    Console.WriteLine($"Goal reached! Good job!");
                    Console.WriteLine($"{stepsSum - goal} steps over the goal!");
                    break;
                }
                if (isHome)
                {
                    Console.WriteLine($"{goal - stepsSum} more steps to reach goal.");
                    break;
                }
            }
        }
    }
}
