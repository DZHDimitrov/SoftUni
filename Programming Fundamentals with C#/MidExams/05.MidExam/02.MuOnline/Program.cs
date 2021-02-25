using System;

namespace _02.MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split('|',StringSplitOptions.RemoveEmptyEntries);
            int Health = 100;
            int bitcoins = 0;
            bool passedThrough = true;
            for (int i = 0; i < array.Length; i++)
            {
                string[] currentRoom = array[i].Split();
                string command = currentRoom[0];
                int valueArgs = int.Parse(currentRoom[1]);

                if (command == "potion")
                {
                    int amountOfHealNeeded = 0;
                    if (Health + valueArgs > 100)
                    {
                        amountOfHealNeeded = 100 - Health;
                    }
                    else
                    {
                        amountOfHealNeeded = valueArgs;
                    }
                    Health += amountOfHealNeeded;
                    Console.WriteLine($"You healed for {amountOfHealNeeded} hp.");
                    Console.WriteLine($"Current health: {Health} hp.");
                }
                else if (command == "chest")
                {
                    bitcoins += valueArgs;
                    Console.WriteLine($"You found {valueArgs} bitcoins.");
                }
                else
                {
                    Health -= valueArgs;
                    if (Health > 0)
                    {
                        Console.WriteLine($"You slayed {command}.");
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {command}.");
                        Console.WriteLine($"Best room: {i+1}");
                        passedThrough = false;
                        break;
                    }
                }
            }
            if (passedThrough)
            {
                Console.WriteLine($"You've made it!"+ Environment.NewLine + $"Bitcoins: {bitcoins}" + Environment.NewLine +  $"Health: {Health}");
            }

        }
    }
}
