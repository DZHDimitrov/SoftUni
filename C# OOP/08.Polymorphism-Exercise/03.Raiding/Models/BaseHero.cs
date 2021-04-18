using _06.Raiding.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _06.Raiding
{
    public abstract class BaseHero : IBaseHero,ICastAbility
    {

        protected BaseHero(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public abstract int Power { get; }

        public abstract string CastAbility();
       
    }
}
