using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Task_9._2
{
    public class InvalidSortTypeException : Exception
    {
        public InvalidSortTypeException() { }
        public InvalidSortTypeException(string message) : base(message) { }
    }
}
