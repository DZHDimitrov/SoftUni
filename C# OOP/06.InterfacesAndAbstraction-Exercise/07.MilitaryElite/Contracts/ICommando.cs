using System.Collections.Generic;

namespace _08.MilitaryElite_.Contracts
{
    public interface ICommando : ISpecialisedSoldier
    {
        IReadOnlyCollection<IMission> Missions { get; }

        void AddMission(IMission mission);
 
    }
}
