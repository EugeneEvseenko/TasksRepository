using System;

namespace Task_10._2._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var worker = new Worker();
            ((IWorker)worker).Build(); // явный вызов, worker.Build(); не сработает.
            Console.ReadKey();
        }
    }
}
