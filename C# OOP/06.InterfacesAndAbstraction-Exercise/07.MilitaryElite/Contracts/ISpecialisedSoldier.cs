using _08.MilitaryElite_.Enumerations;

namespace _08.MilitaryElite_.Contracts
{
    public interface ISpecialisedSoldier : IPrivate
    {
        Corps_SpecilisedSolder Corps { get; }
    }
}
