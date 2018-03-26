using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Tuple.MyOwnTuple
{
    public class Tuple<T1, T2, T3>
    {
        public Tuple(T1 element1, T2 element2, T3 element3)
        {
            this.Element1 = element1;
            this.Element2 = element2;
            this.Element3 = element3;
        }

        public T1 Element1 { get; private set; }

        public T2 Element2 { get; private set; }

        public T3 Element3 { get; private set; }

        public override string ToString()
        {
            return $"{this.Element1.ToString()} -> {this.Element2.ToString()} -> {this.Element3.ToString()}";
        }
    }
}
