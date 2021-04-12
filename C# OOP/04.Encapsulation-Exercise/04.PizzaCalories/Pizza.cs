using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    class Pizza
    {
        private string name;
        private List<Topping> toppings;
        public Pizza(string name, Dough dough)
        {
            Name = name;
            PizzasDough = dough;
            Toppings = new List<Topping>();

        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value == "" || value == " " || value == null || value.Length > 15 || value.Length < 1)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }

        public Dough PizzasDough { private get; set; }
        public double Calories
        {
            get
            {
                double calories = 0;
                foreach (var item in Toppings)
                {
                    calories += item.Calories;
                }
                calories += PizzasDough.Calories;

                return calories;
            }
        }
        public List<Topping> Toppings
        {
            get
            {
                return toppings;
            }
            set
            {
                if (value.Count > 10)
                {
                    throw new ArgumentException("Number of toppings should be in range [0..10].");
                }
                toppings = value;
            }
        }

        public void AddingTopping(Topping topping)
        {
            if (toppings.Count == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            Toppings.Add(topping);
        }

        public override string ToString()
        {
            return $"{Name} - {Calories:F2} Calories.";
        }
    }
}
