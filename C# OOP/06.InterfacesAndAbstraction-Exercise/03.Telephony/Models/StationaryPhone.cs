using _04.Telephony.Contracts;
using System;

namespace _04.Telephony.Models
{
    public class StationaryPhone : ICall
    {
        public void Call(string number)
        {
            Console.WriteLine($"Dialing... {number}");
        }
    }
}
