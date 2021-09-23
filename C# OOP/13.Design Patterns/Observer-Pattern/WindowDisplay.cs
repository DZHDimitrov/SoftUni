using Observer_Pattern.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer_Pattern
{
    public class WindowDisplay : IObserver
    {
        private readonly WeatherStation weatherStation;

        public int Temperature { get; set; } = 0;

        public WindowDisplay(WeatherStation weatherStation)
        {
            this.weatherStation = weatherStation;
        }

        public void Subscribe()
        {
            this.weatherStation.Add(this);
        }

        public void Unsubscribe()
        {
            this.weatherStation.Remove(this);
        }

        public void Update()
        {
            this.Temperature = this.weatherStation.GetTemperature();
        }
    }
}
