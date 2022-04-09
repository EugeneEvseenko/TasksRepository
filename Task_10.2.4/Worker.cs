using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_10._2._4
{
    public class Worker : IWorker
    {
        void IWorker.Build()
        {
            Console.WriteLine("Вызван метод Build()");
        }
    }
}
