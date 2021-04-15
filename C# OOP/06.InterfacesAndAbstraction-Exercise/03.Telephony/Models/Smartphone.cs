using _04.Telephony.Contracts;
using System;

namespace _04.Telephony.Models
{
    public class Smartphone : ICall,IBrowse
    {
        public void Browse(string site)
        {
            Console.WriteLine($"Browsing: {site}!");
        }

        public void Call(string number)
        {
            Console.WriteLine($"Calling... {number}");
        }
    }
}
