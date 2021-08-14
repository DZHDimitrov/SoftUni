using CommandPattern.Core.Contracts;
using CommandPattern.Core.Models.CommandModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string _commandSuffix = "Command";

        public string Read(string args)
        {
            string[] tokens = args.Split();

            string commandName = tokens[0];
            string[] commandArgs = tokens[1..];

            var type = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == $"{commandName}{_commandSuffix}");
            ICommand command = (ICommand)Activator.CreateInstance(type);
            string result = command.Execute(commandArgs);

            return result;
        }
    }
}
