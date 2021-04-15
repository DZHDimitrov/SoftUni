using _08.MilitaryElite_.Enumerations;

namespace _08.MilitaryElite_.Contracts
{
    public interface IMission
    {
        string CodeName { get; }

        MissionState State { get; }

        void CompleteMission();
    }
}
