using System;

namespace Task_5._3._1
{
    internal class Program
    {
        static void ChangeAge(ref int age)
        {
            Console.WriteLine("Введите возраст");
            age = int.Parse(Console.ReadLine());

        }
        static void Main(string[] args)
        {
            int age = 25;
            Console.WriteLine(age);
            ChangeAge(ref age);
            Console.WriteLine(age);
            Console.ReadKey();
        }
    }
}
