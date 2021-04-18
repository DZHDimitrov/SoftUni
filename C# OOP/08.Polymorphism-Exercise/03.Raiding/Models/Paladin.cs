using System;
using System.Collections.Generic;
using System.Text;

namespace _06.Raiding.Models
{
    public class Paladin : BaseHero
    {
        private const int powerByDefault = 100;

        public Paladin(string name) : base(name)
        {

        }

        public override int Power => powerByDefault;

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} healed for {Power}";
        }
    }
}
