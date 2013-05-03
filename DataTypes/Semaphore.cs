using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace utility.DataTypes
{
    public class Semaphore
    {
        private int value;
        private int minlimit, maxlimit;

        public static Semaphore operator ++(Semaphore semaphore)
        {
            return semaphore.increment();
        }

        public static Semaphore operator --(Semaphore semaphore)
        {
            return semaphore.decrement();
        }

        public static implicit operator bool(Semaphore semaphore)
        {
            return (semaphore.value != 0);
        }


        public Semaphore() : this(8) { }

        public Semaphore(int limit) : this(-limit, limit) { }

        public Semaphore(int minlimit, int maxlimit)
        {
            if (minlimit >= maxlimit) throw new ArgumentOutOfRangeException();

            value = 0;
            this.minlimit = minlimit;
            this.maxlimit = maxlimit;
        }

        public Semaphore increment()
        {
            value++;
            if (value > maxlimit)
            {
                throw new ArgumentOutOfRangeException();
            }
            return this;
        }

        public Semaphore decrement()
        {
            value--;
            if (value < minlimit)
            {
                throw new ArgumentOutOfRangeException();
            }
            return this;
        }
    }

}
