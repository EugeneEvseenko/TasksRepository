using System;

namespace Task_7._2._4
{
    class BaseClass
    {
        public virtual int Counter
        {
            get;
            set;
        }
    }

    class DerivedClass : BaseClass
    {
        private int counter;
        public override int Counter
        {
            get { return counter; }
            set
            {
                if(value >= 0)
                {
                    counter = value;
                }
            }
        }
    }
}
