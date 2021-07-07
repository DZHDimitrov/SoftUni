using MilitaryElite.Common.Enums;
using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Models
{
    public class SpecialisedSoldier : Private,ISpecialisedSoldier
    {
        private string corps;

        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary,string corps) : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        public string Corps 
        {
            get
            {
                return this.corps;
            }
            set
            {
                if (!Enum.TryParse<Corps>(value,out _))
                {
                    throw new ArgumentException("Invalid corps");
                }
                this.corps = value;
            }
        }

        public override string ToString()
        {
            return base.ToString()
                  + Environment.NewLine
                  + $"Corps: {this.Corps}"
                  + Environment.NewLine;
        }
    }
}
