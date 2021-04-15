using _08.MilitaryElite_.Contracts;
using _08.MilitaryElite_.Enumerations;
using _08.MilitaryElite_.Exceptions;
using System;

namespace _08.MilitaryElite_.Models
{
    public class Mission : IMission
    {
        public Mission(string codeName, string state)
        {
            CodeName = codeName;

            State = TryParse(state);
        }

        public string CodeName { get; private set; }

        public MissionState State { get; private set; }

        public void CompleteMission()
        {
            if (State == MissionState.Finished)
            {
                throw new InvalidMissionCompletionException();
            }
            State = MissionState.Finished;
        }
        private MissionState TryParse(string state)
        {
            MissionState currentState;
            bool parsed = Enum.TryParse<MissionState>(state, out currentState);

            if (!parsed)
            {
                throw new InvalidMissionException();
            }

            return currentState;
        }

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {State.ToString()}";
        }
    }
}
