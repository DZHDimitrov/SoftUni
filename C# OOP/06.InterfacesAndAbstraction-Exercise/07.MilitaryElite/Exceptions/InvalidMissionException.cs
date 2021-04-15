using System;

namespace _08.MilitaryElite_.Exceptions
{
    public class InvalidMissionException : Exception
    {
        private const string DEF_INV_MISSION_MSG = "Invalid mission state!";
        public InvalidMissionException() : base(DEF_INV_MISSION_MSG)
        {

        }

        public InvalidMissionException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
