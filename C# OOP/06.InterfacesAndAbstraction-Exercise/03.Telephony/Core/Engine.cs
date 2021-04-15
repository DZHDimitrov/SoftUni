using _04.Telephony.Contracts;
using _04.Telephony.Models;
using System;

namespace _04.Telephony.Core
{
    public class Engine
    {

        public Engine()
        {

        }

        public void Run()
        {
            string[] phoneNumbers = Console.ReadLine().Split();
            string[] sites = Console.ReadLine().Split();

            for (int i = 0; i < phoneNumbers.Length; i++)
            {
                string currentNumber = phoneNumbers[i];
                if (ValidateNumber(currentNumber))
                {
                    if (currentNumber.Length == 10)
                    {
                        ICall smartphone = new Smartphone();
                        smartphone.Call(currentNumber);
                    }
                    else if (currentNumber.Length == 7)
                    {
                        ICall stationaryphone = new StationaryPhone();
                        stationaryphone.Call(currentNumber);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }

            }
            for (int i = 0; i < sites.Length; i++)
            {
                string currentSite = sites[i];
                if (ValidateSite(currentSite))
                {
                    IBrowse smartphone = new Smartphone();
                    smartphone.Browse(currentSite);
                }
                else
                {
                    Console.WriteLine("Invalid URL!");
                }
            }
        }
        private static bool ValidateSite(string site)
        {
            for (int i = 0; i < site.Length; i++)
            {
                if (Char.IsDigit(site[i]))
                {
                    return false;
                }
            }
            return true;
        }
        private static bool ValidateNumber(string number)
        {
            for (int i = 0; i < number.Length; i++)
            {
                if (!Char.IsDigit(number[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
