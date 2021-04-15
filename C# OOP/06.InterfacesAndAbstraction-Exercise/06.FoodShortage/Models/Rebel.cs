using _06.BirthdayCelebrations;
using _07.FoodStorage.Contracts;

namespace _07.FoodStorage.Models
{
    class Rebel : IPerson
    {
        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
        }

        public string Name { get; set; }
        public int Age { get; set; }

        public string Group { get; set; }
        public int Food { get; set; }

        public void BuyFood()
        {
            Food += 5;
        }
    }
}
