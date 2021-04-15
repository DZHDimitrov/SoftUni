using _08.MilitaryElite_.Contracts;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite_.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private ICollection<IMission> missions;

        public Commando(int id, string firstname, string lastName, decimal salary, string corps) : base(id, firstname, lastName, salary, corps)
        {

            missions = new List<IMission>();
        }

        public IReadOnlyCollection<IMission> Missions
        {
            get
            {
                return (IReadOnlyCollection<IMission>)missions;
            }
        }

        public void AddMission(IMission mission)
        {
            missions.Add(mission);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Missions:");
            foreach (var mission in missions)
            {
                sb.AppendLine($"  {mission.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
