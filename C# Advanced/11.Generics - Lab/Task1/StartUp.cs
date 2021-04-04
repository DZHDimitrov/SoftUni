using System;

namespace BoxOfT
{
    class StartUp

    {
        static void Main(string[] args)
        {
            Box<int> box = new Box<int>();
            box.Add(5);
            box.Add(5);
            box.Add(5);
            box.Remove();
            box.Remove();
            Console.WriteLine(box.Count);
        }
    }
}
