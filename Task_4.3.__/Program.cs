using System;

namespace Task_4._3.__
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите своё имя");
            string name = Console.ReadLine();
            Console.WriteLine("\nВаше имя в обратном порядке:");
            for(int i = name.Length - 1; i >= 0; i--)
            {
                Console.Write(name[i]);
            }
            Console.ReadKey();
        }
    }
}
