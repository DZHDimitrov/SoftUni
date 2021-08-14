using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Core.Models
{
    public class Engine : IEngine
    {
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter command)
        {
            this.commandInterpreter = command;
        }

        public void Run()
        {
            while (true)
            {
                string inputLine = Console.ReadLine();

                string result = this.commandInterpreter.Read(inputLine);

                Console.WriteLine(result);
            }
        }
    }
}
