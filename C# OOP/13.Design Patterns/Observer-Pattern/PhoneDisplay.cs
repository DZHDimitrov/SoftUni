using Observer_Pattern.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer_Pattern
{
    public class PhoneDisplay : IObserver
    {
        private readonly WeatherStation weatherStation;

        public int Temperature { get; set; } = 0;

        public PhoneDisplay(WeatherStation weatherStation)
        {
            this.weatherStation = weatherStation;
        }

        public void Update()
        {
            this.Temperature = this.weatherStation.GetTemperature();
        }

        public void Subscribe()
        {
            this.weatherStation.Add(this);
        }

        public void Unsubscribe()
        {
            this.weatherStation.Remove(this);
        }
    }
}
