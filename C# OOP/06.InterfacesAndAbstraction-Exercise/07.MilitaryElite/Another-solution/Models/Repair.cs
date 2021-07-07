using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Models
{
    public class Repair : IRepair
    {
        public Repair(string name,int hoursWorked)
        {
            this.Name = name;
            this.HoursWorked = hoursWorked;
        }

        public string Name { get; }

        public int HoursWorked { get; }

        public override string ToString()
        {
            return $"Part Name: {this.Name} Hours Worked: {this.HoursWorked}";
        }
    }
}
