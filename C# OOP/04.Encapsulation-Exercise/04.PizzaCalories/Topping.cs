using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    class Topping
    {
        private const double CaloriesPerGramByDefault = 2;

        private double toppingModifier;

        private string topping;
        private int weight;

        public Topping(string typeOfTopping,int weight)
        {
            TypeOFTopping = typeOfTopping;
            Weight = weight;

            toppingModifier = GetToppingModifier(typeOfTopping);
        }

        public string TypeOFTopping 
        {
            get
            {
                return topping;
            }
            set
            {
                if (value != "meat" && value != "veggies" && value != "cheese" && value != "sauce")
                {
                    string letter = value[0].ToString().ToUpper();
                    string textToReturn = letter + value.Substring(1);
                    throw new ArgumentException($"Cannot place {textToReturn} on top of your pizza.");
                }
                topping = value;
            }
        }

        public int Weight 
        {
            get
            {
                return weight;
            }
            set
            {
                if (value < 1 || value > 50)
                {
                    string letter = TypeOFTopping[0].ToString().ToUpper();
                    string textToReturn = letter + TypeOFTopping.Substring(1);
                    throw new ArgumentException($"{textToReturn} weight should be in the range [1..50].");
                }
                weight = value;
            }
        }

        public double Calories 
        {
            get
            {
                return toppingModifier * Weight * CaloriesPerGramByDefault;
            }
        }

        private double GetToppingModifier(string toppingType)
        {
            switch (toppingType.ToLower())
            {
                case "meat":
                    return 1.2;
                case "veggies":
                    return 0.8;
                case "cheese":
                    return 1.1;
                case "sauce":
                    return 0.9;
            }
            return 0;
        }


    }
}
