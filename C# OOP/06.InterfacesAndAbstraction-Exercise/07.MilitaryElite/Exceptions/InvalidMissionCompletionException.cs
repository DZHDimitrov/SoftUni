using System;

namespace _08.MilitaryElite_.Exceptions
{
    public class InvalidMissionCompletionException : Exception
    {
        private const string DEF_EXC_MSG = "Mission already completed!";

        public InvalidMissionCompletionException() : base(DEF_EXC_MSG)
        {

        }

        public InvalidMissionCompletionException(string message) : base(message)
        {

        }
    }
}
