using System;
using System.Linq;

namespace Task_14._2._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "Обезьяна", "Лягушка", "Кот", "Собака", "Черепаха" };

            var animals = words
                .Select(x => new { Name = x, NameLenght = x.Length})
                .OrderBy(x => x.NameLenght);

            foreach(var animal in animals)
                Console.WriteLine(animal);

            Console.ReadKey();
        }
    }
}
