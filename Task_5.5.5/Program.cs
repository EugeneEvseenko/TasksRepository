using System;

namespace Task_5._5._5
{
    internal class Program
    {
        static decimal Factorial(int x)
        {
            if (x == 0)
            {
                return 1;
            }
            else
            {
                return x * Factorial(x - 1);
            }
        }
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine($"Факториал {num} = {Factorial(num)}");
            Console.ReadKey();
        }
    }
}
