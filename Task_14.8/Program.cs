using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_14._8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var objects = new List<object>()
            {
               1,
               "Сергей ",
               "Андрей ",
               300,
            };

            var names = objects.Where(x => x is string).OrderBy(n => n);
            foreach (var name in names)
                Console.WriteLine(name);
            Console.ReadKey();
        }
    }
}
