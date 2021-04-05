using System;
using System.Collections.Generic;
using System.Text;

namespace Tuples
{
    public class Tuple<First,Second>
    {
        public First Item1 { get; set; }
        public Second Item2 { get; set; }

        public Tuple(First first,Second second)
        {
            Item1 = first;
            Item2 = second;
        }

        public override string ToString()
        {
            return $"{Item1} -> {Item2}";
        }
    }
}
