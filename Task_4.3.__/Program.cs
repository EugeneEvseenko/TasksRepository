using System;

namespace Task_4._3.__
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите своё имя");
            string name = Console.ReadLine();
            Console.WriteLine("Ваше имя по буквам:");
            foreach (var ch in name)
            {
                Console.Write($"{ch} ");
            }
            Console.Write($"Последняя буква имени: {name[^1]}");
            Console.ReadKey();
        }
    }
}
