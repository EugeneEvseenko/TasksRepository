using System;
using System.Linq;

namespace Task_15._1._6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку");
            string line = Console.ReadLine();
            var exceptSymbols = new char[] { ',', '.', ';', ':',  '?', '!' };

            //var uniqueChars = line.Except(exceptSymbols).Distinct();
            var uniqueChars = line.Where(x => !char.IsPunctuation(x)).Distinct();

            foreach (var ch in uniqueChars)
                Console.Write($" {ch}");

            Console.ReadKey();
        }
    }
}
