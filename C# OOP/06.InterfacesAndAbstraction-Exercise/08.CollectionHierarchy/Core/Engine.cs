using _09.CollectionHierachy.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _09.CollectionHierachy.Core
{
    public class Engine
    {
        public Engine()
        {

        }

        public void Run()
        {
            string[] cmdArgs = Console.ReadLine().Split();
            int remove = int.Parse(Console.ReadLine());
            AddCollection addColection = new AddCollection();
            AddRemoveCollection AddRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();
            int[] firstArr = new int[cmdArgs.Length];
            int[] secondArr = new int[cmdArgs.Length];
            int[] thirdArr = new int[cmdArgs.Length];
            for (int i = 0; i < cmdArgs.Length; i++)
            {
                int indexOne = 0;
                int indexTwo = 0;
                int indexThree = 0;
                indexOne = addColection.Add(cmdArgs[i]);
                indexTwo = AddRemoveCollection.Add(cmdArgs[i]);
                indexThree = myList.Add(cmdArgs[i]);
                firstArr[i] = indexOne;
                secondArr[i] = indexTwo;
                thirdArr[i] = indexThree;
            }
            Console.WriteLine(string.Join(" ", firstArr));
            Console.WriteLine(string.Join(" ", secondArr));
            Console.WriteLine(string.Join(" ", thirdArr));

            string[] removalsFirst = new string[firstArr.Length];
            string[] removalsSecond =new string[firstArr.Length];
            
            for (int i = 0; i < remove; i++)
            {
               removalsFirst[i] = AddRemoveCollection.Remove();
               removalsSecond[i] = myList.Remove();
            }
            Console.WriteLine(string.Join(" ", removalsFirst));
            Console.WriteLine(string.Join(" ", removalsSecond));
        }
    }
}
