using System;
using System.Collections.Generic;
using System.Text;

namespace _06.Raiding.Models
{
    public class Warrior : BaseHero
    {
        private const int powerByDefault = 100;
        public Warrior(string name) : base(name)
        {

        }

        public override int Power => powerByDefault;

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
