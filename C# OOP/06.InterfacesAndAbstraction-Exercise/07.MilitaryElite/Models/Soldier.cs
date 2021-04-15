using _08.MilitaryElite_.Contracts;

namespace _08.MilitaryElite_.Models
{
    public abstract class Soldier : ISoldier
    {
        protected Soldier(int id, string firstname, string lastName)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastName;
        }

        public int Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} Id: {Id}";
        }
    }
}
