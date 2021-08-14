using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Core.Models.CommandModels
{
    using System;
    using CommandPattern.Core.Contracts;

    public class ExitCommand : ICommand
    {
        public string Execute(string[] args)
        {
            return null;
        }
    }
}
