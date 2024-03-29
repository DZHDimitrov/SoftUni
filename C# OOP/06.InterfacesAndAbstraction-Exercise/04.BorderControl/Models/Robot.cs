﻿using _05.BorderControl.Contracts;

namespace _05.BorderControl.Models
{
    public class Robot : IID
    {
        public Robot(string model, string id)
        {
            Model = model;
            ID = id;
        }
        public string Model { get; set; }
        public string ID { get; set; }
    }
}
