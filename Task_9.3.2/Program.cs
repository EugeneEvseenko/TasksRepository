using System;

namespace Task_9._3._2
{
    internal class Program
    {
        delegate int CalculateDelegate(int a, int b);
        static void Main(string[] args)
        {

            CalculateDelegate calcDelegate = Calculate;
            int result = calcDelegate(100, 30);

            Console.WriteLine(result);
            Console.ReadKey();

        }

        static int Calculate(int a, int b)
        {
            return a - b;
        }
    }
}
