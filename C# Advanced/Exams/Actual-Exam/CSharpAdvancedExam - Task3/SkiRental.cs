using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private IList<Ski> data;

        public SkiRental(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Ski>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => this.data.Count;

        public void Add(Ski ski)
        {
            if (this.Capacity > this.data.Count)
            {
                this.data.Add(ski);
            }
        }

        public bool Remove(string manufacturer,string model)
        {
            return this.data.Remove(this.data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model));
        }

        public Ski GetNewestSki()
        {
            return this.data.OrderByDescending(x => x.Year).FirstOrDefault();
        }

        public Ski GetSki(string manufacturer,string model)
        {
            return this.data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The skis stored in {this.Name}:");
            sb.AppendLine(string.Join(Environment.NewLine, this.data));

            return sb.ToString().TrimEnd();
        }
    }
}
