using System;

namespace Task_4._3.__
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] arr = { { -5, 6, 9, 1, 2, -3 }, { -8, 8, 1, 1, 2, -3 } };
            int counter = 0;
            foreach (int i in arr)
            {
                if (i > 0) counter++;
            }
            Console.WriteLine($"В массиве всего {counter} положительных чисел.");
            Console.ReadKey();
        }
    }
}
