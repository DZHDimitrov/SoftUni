using System;
using System.Collections.Generic;
using System.Text;

namespace _06.Raiding.Models
{
    public class Druid : BaseHero
    {
        private const int powerByDefault = 80;

        public Druid(string name) : base(name)
        {

        }

        public override int Power => powerByDefault;

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} healed for {Power}";
        }
    }
}
