using _08.MilitaryElite_.Contracts;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite_.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private ICollection<IRepair> repairs;
        public Engineer(int id, string firstname, string lastName, decimal salary, string corps) : base(id, firstname, lastName, salary, corps)
        {
            repairs = new List<IRepair>();
        }

        public IReadOnlyCollection<IRepair> Repairs
        {
            get
            {
                return (IReadOnlyCollection<IRepair>)repairs;
            }
        }

        public void AddRepair(IRepair repair)
        {
            repairs.Add(repair);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Repairs:");
            foreach (var rpr in repairs)
            {
                sb.AppendLine($"  {rpr.ToString()}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
