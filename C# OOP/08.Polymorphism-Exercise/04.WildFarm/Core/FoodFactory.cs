using _04.WildFarm.Models;
using _04.WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace _04.WildFarm.Core
{
    public class FoodFactory
    {
        public FoodFactory()
        {

        }

        public Food CreateFood(string strType, int quantity)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Type currenttype = assembly.GetTypes().FirstOrDefault(t => t.Name == strType);

            object[] ctorParams = new object[] { quantity };

            Food food = (Food)Activator.CreateInstance(currenttype, ctorParams);
            return food;

        }
    }
}
