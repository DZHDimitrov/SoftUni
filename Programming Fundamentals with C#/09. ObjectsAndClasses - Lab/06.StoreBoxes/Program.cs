using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ObjectsAndClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Box> boxes = new List<Box>();
            while (input != "end")
            {
                string[] data = input.Split();

                string serialNumber = data[0];
                string itemName = data[1];
                int itemQuantity = int.Parse(data[2]);
                double itemPrice = double.Parse(data[3]);

                Box box = new Box();
                box.SerialNumber = serialNumber;
                box.ItemName = itemName;
                box.ItemQuantity = itemQuantity;
                box.ItemPrice = itemPrice;
                box.Price = box.ItemQuantity * box.ItemPrice;

                boxes.Add(box);

                input = Console.ReadLine();
            }
            List<Box> orderedList = boxes.OrderByDescending(x => x.Price).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (Box box in orderedList)
            {
                sb.AppendLine(box.ToString());
            }

            Console.WriteLine(sb);
        }
    }


    class Box
    {
        public string SerialNumber { get; set; }
        public string ItemName { get; set; }

        public int ItemQuantity { get; set; }

        public double ItemPrice { get; set; }

        public double Price { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{SerialNumber}");
            sb.AppendLine($"-- {ItemName} - ${ItemPrice:F2}: {ItemQuantity}");
            sb.AppendLine($"-- ${Price:F2}");

            return sb.ToString().TrimEnd();
        }
    }

}

