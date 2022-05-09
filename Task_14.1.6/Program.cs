using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_14._1._6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numsList = new List<int[]>()
            {
               new[] {2, 3, 7, 1},
               new[] {45, 17, 88, 0},
               new[] {23, 32, 44, -6},
            };

            var orderedNums = numsList
                .SelectMany(s => s)
                .OrderBy(s => s);

            foreach (var num in orderedNums)
                Console.WriteLine(num);

            Console.ReadKey();
        }
    }
}
