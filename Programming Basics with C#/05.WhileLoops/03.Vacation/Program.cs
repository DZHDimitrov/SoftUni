using System;

namespace NewExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            double budgetNeeded = double.Parse(Console.ReadLine());
            double currentBudget = double.Parse(Console.ReadLine());
            int daysInARow = 0;
            int allDays = 0;
            while (true)
            {
                string input = Console.ReadLine();
                double spendOrSave = double.Parse(Console.ReadLine());

                if (input == "spend")
                {
                    currentBudget -= spendOrSave;
                    if (currentBudget < 0)
                    {
                        currentBudget = 0;
                    }
                    daysInARow++;
                }
                else if (input == "save")
                {
                    currentBudget += spendOrSave;
                    daysInARow = 0;
                }
                allDays++;
                if (daysInARow == 5)
                {
                    Console.WriteLine("You can't save the money.");
                    Console.WriteLine($"{allDays}");
                    break;
                }
                if (currentBudget >= budgetNeeded)
                {
                    Console.WriteLine($"You saved the money for {allDays} days.");
                    break;
                }
            }

        }
    }
}
