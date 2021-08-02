using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Models.Bunnies
{
    public abstract class Bunny : IBunny
    {
        private string name;
        private int energy;
        private readonly ICollection<IDye> dyes;

        public Bunny(string name,int energy)
        {
            this.dyes = new List<IDye>();
            this.Name = name;
            this.Energy = energy;
        }

        public string Name 
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBunnyName);
                }
                this.name = value;
            }
        }

        public int Energy 
        {
            get
            {
                return this.energy;
            }
            protected set
            {
                if (value < 0)
                {
                    this.energy = 0;
                }
                else
                {
                    this.energy = value;
                }
            }
        }

        public ICollection<IDye> Dyes => this.dyes;

        public void AddDye(IDye dye)
        {
            this.dyes.Add(dye);
        }

        public virtual void Work()
        {
            this.Energy -= 10;
            if (this.Energy < 0)
            {
                this.Energy = 0;
            }
            else
            {
                while (Dyes.Any())
                {
                    if (Dyes.First().IsFinished() == false)
                    {
                        Dyes.First().Use();
                        break;
                    }
                    Dyes.Remove(Dyes.First());
                }
            }
        }
    }
}
