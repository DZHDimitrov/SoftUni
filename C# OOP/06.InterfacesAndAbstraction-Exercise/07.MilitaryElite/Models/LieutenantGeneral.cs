using _08.MilitaryElite_.Contracts;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite_.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private ICollection<ISoldier> privates;
        public LieutenantGeneral(int id, string firstname, string lastName, decimal salary) : base(id, firstname, lastName, salary)
        {
            privates = new List<ISoldier>();
        }

        public IReadOnlyCollection<ISoldier> Privates
        {
            get
            {
                return (IReadOnlyCollection<ISoldier>)privates;
            }
        }

        public void AddPrivate(ISoldier @private)
        {
            privates.Add(@private);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");
            foreach (var soldier in privates)
            {
                sb.AppendLine($"  {soldier.ToString()}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
