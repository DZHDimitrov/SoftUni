using System;

namespace Observer_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherStation weatherStation = new WeatherStation();

            PhoneDisplay phoneDisplay = new PhoneDisplay(weatherStation);
            WindowDisplay windowDsiplay = new WindowDisplay(weatherStation);

            phoneDisplay.Subscribe();
            windowDsiplay.Subscribe();

            weatherStation.Temperature = 5;
            Console.WriteLine($"PhoneDisplay recieves new data... {phoneDisplay.Temperature} ");
            Console.WriteLine($"WindowDisplay recieves new data... {windowDsiplay.Temperature}");
            Console.WriteLine();
            weatherStation.Temperature = 10;
            Console.WriteLine($"PhoneDisplay recieves new data... {phoneDisplay.Temperature}");
            Console.WriteLine($"WindowDisplay recieves new data... {windowDsiplay.Temperature}");
            Console.WriteLine();
            windowDsiplay.Unsubscribe();
            weatherStation.Temperature = 15;
            Console.WriteLine($"PhoneDisplay recieves new data... {phoneDisplay.Temperature}");
            Console.WriteLine($"WindowDisplay does not recieve data because of unsubscribe... {windowDsiplay.Temperature}");
            Console.WriteLine();
            Console.WriteLine("Expected result: 5-5/10-10/15-10");
        }
    }
}
