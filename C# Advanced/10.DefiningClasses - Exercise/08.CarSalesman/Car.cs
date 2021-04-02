using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (Weight != 0)
            {
                sb.AppendLine($" Weight: {Weight}");
            }
            else
            {
                sb.AppendLine($" Weight: n/a");
            }
            if (Color != null)
            {
                sb.AppendLine($" Color: {Color}");
            }
            else
            {
                sb.AppendLine($" Color: n/a");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
