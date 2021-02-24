using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MovingTarget
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split().Select(int.Parse).ToList();

            string input = Console.ReadLine();
            
            while (input != "End")
            {
                string[] cmdArgs = input.Split();
                string command = cmdArgs[0];
                int index = int.Parse(cmdArgs[1]);
                int integerArgs = int.Parse(cmdArgs[2]);
                
                switch (command)
                {
                    case "Shoot":
                        if (index < 0 || index >= targets.Count)
                        {
                            input = Console.ReadLine();
                            continue;
                        }
                        targets[index] -= integerArgs;
                        if (targets[index] <= 0)
                        {
                            targets.RemoveAt(index);
                        }
                        break;
                    case "Add":
                        if (index < 0 || index >= targets.Count)
                        {
                            Console.WriteLine("Invalid placement!");
                            input = Console.ReadLine();
                            continue;
                        }
                        targets.Insert(index, integerArgs);
                        break;
                    case "Strike":
                        if (index < 0 || index >= targets.Count)
                        {
                            input = Console.ReadLine();
                            continue;
                        }
                        if (index - integerArgs < 0 || index + integerArgs >= targets.Count)
                        {
                            Console.WriteLine("Strike missed!");
                            input = Console.ReadLine();
                            continue;
                        }
                        targets.RemoveRange(index+1, integerArgs);
                        targets.RemoveRange(index - integerArgs, integerArgs);
                        targets.RemoveAt(index - integerArgs);
                        break;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join("|", targets));
        }
    }
}
