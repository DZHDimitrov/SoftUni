using System.Collections.Generic;

namespace _08.MilitaryElite_.Contracts
{
    public interface IEngineer : ISpecialisedSoldier
    {
        IReadOnlyCollection<IRepair> Repairs { get; }

        void AddRepair(IRepair repair);

    }
}
