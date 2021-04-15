using _08.MilitaryElite_.Contracts;
using System;
using System.Text;

namespace _08.MilitaryElite_.Models
{
    public class Spy : Soldier, ISpy
    {
        public Spy(int id, string firstname, string lastName, int codeNumber) : base(id, firstname, lastName)
        {
            CodeNumber = codeNumber;
        }

        public int CodeNumber { get; private set; }

        public override string ToString()
        {

            return $"{base.ToString() + Environment.NewLine + $"Code Number: {CodeNumber}"}";
        }
    }
}
