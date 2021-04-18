using System;
using System.Collections.Generic;
using System.Text;

namespace _06.Raiding.Contracts
{
    public interface IBaseHero : ICastAbility
    {
        public string Name { get; }

        public int Power { get; }

        string CastAbility();
               
    }
}
