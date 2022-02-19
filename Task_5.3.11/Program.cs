using System;

namespace Task_5._3._11
{
    internal class Program
    {
        public static int SumNumbers(ref int num1, in int num2, out int num3, int num4)
        {
            num3 = num1 + num2;
            return num3 * num4;
        }
        static void Main(string[] args)
        {
            int num1 = 4, num2 = 5, num4 = 5;
            Console.WriteLine($"num1 = {num1}\nnum2 = {num2}\nnum3 = null\nnum4 = {num4}\n\n");
            var result = SumNumbers(ref num1, in num2, out int num3, num4);
            Console.WriteLine($"num1 = {num1}\nnum2 = {num2}\nnum3 = {num3}\nnum4 = {num4}\nresult = {result}");
            Console.ReadKey();
        }
    }
}
