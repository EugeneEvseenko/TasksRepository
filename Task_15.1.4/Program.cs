using System;
using System.Linq;

namespace Task_15._1._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите первое слово");
            string first = Console.ReadLine();

            Console.WriteLine("Введите второе слово");
            string second = Console.ReadLine();

            var kek = first.Intersect(second);
            Console.WriteLine("Пересечиния:");
            if(kek.Count() > 0)
                foreach (var item in kek)
                    Console.Write($"{item} ");
            else
                Console.WriteLine($"В словах '{first}' и '{second}' пересечений нет.");

            Console.ReadKey();
        }
    }
}
