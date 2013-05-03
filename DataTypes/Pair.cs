using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace utility.DataTypes
{
    public class Pair<T, U>
    {
        private T _first;
        public virtual T first { set { _first = value; } get { return _first; } }

        private U _second;
        public virtual U second { set { _second = value; } get { return _second; } }

        public Pair(T first, U second)
        {
            _first = first;
            _second = second;
        }
    }
}
