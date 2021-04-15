using _06.BirthdayCelebrations;

namespace _07.FoodStorage.Contracts
{
    public interface IPerson : IBuyer
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
