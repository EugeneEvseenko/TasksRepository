using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Task_9._1
{
    public class MyException : Exception
    {
        public MyException() { }
        public MyException(string message) : base(message) { }
    }
}
