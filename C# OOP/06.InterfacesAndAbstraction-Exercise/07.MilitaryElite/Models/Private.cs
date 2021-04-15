using _08.MilitaryElite_.Contracts;

namespace _08.MilitaryElite_.Models
{
    public class Private : Soldier, IPrivate
    {
        public Private(int id, string firstname, string lastName, decimal salary) : base(id, firstname, lastName)
        {
            Salary = salary;
        }

        public decimal Salary { get; private set; }

        public override string ToString()
        {
            return $"{base.ToString()} Salary: {Salary:F2}";
        }
    }
}
