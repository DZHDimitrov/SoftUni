using System;
using System.Collections.Generic;
using System.Text;

namespace Tuples
{
    public class Tuple<First,Second,Third> where Third : IConvertible
    {
        public First Item1 { get; set; }

        public Second Item2 { get; set; }

        public Third Item3 { get; set; }      
        public Tuple(First first,Second second,Third third)
        {
            Item1 = first;
            Item2 = second;
            Item3 = third;
        }

        public override string ToString()
        {
            return $"{Item1} -> {Item2} -> {Item3}";
        }
    }
}
