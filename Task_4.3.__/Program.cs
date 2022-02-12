using System;

namespace Task_4._3.__
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 5, 6, 9, 1, 2, 3, 4 };
            int sum = 0;
            foreach (int i in arr)
            {
                Console.WriteLine($"{sum} + {i} = {sum + i}");
                sum += i;
            }
            Console.WriteLine($"Сумма = {sum}");
            Console.ReadKey();
        }
    }
}
