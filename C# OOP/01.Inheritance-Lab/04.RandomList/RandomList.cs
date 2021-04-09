using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    { 

        Random rand = new Random();
        public string RandomString(List<string> list)
        {
            int index = rand.Next(0, list.Count);
            string element = list[index];
            list.RemoveAt(index);
            return element;            
        }
    }
}
