using _08.MilitaryElite_.Contracts;
using _08.MilitaryElite_.Enumerations;
using System;
using _08.MilitaryElite_.Exceptions;
using System.Collections.Generic;

namespace _08.MilitaryElite_.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id, string firstname, string lastName, decimal salary,string corps) : base(id, firstname, lastName, salary)
        {
            Corps = TryParse(corps);
        }

        public Corps_SpecilisedSolder Corps { get; private set; }

        private Corps_SpecilisedSolder TryParse(string corp)
        {
            Corps_SpecilisedSolder corps;
            bool parsed = Enum.TryParse<Corps_SpecilisedSolder>(corp,out corps);
            if (!parsed)
            {
                throw new InvalidCorpsException();
            }
            return corps;
        }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + $"Corps: {Corps.ToString()}";
        }
    }
}
