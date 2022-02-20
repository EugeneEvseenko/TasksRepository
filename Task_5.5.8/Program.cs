using System;

namespace Task_5._5._8
{
    internal class Program
    {
        private static int PowerUp(int N, byte pow)
        {
            if(pow == 0)
            {
                return 1;
            }else if(pow == 1)
            {
                return N;
            }
            else
            {
                return N * PowerUp(N, --pow);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите степень");
            byte pow = byte.Parse(Console.ReadLine());
            Console.WriteLine($"\n{num} в степени {pow} равна {PowerUp(num, pow)}");
            Console.ReadKey();
        }
    }
}
