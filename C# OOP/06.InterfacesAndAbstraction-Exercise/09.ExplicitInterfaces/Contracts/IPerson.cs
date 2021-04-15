using System;
using System.Collections.Generic;
using System.Text;

namespace _10.ExplicitInterfaces.Contracts
{
    public interface IPerson
    {
        public string Name { get; }

        public int Age { get; }

        public string GetName();
    }
}
