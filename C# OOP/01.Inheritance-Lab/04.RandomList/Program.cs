using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList();
            list.Add("Penko");
            list.Add("Pesho");
            list.Add("Gosho");
            list.Add("Misho");
            list.Add("Nacho");
            Console.WriteLine(list.RandomString(list));
        }
    }
}
