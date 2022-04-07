using System;

namespace Final_Task_9._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Exception[] exceptions =
            {
                new ArgumentException("исключение №1"),
                new DivideByZeroException("исключение №2"),
                new IndexOutOfRangeException("исключение №3"),
                new OverflowException("исключение №4"),
                new MyException("исключение №5")
            };
            foreach (Exception exception in exceptions)
            {
                try
                {
                    throw exception;
                }
                catch (Exception ex) 
                when (
                    ex is ArgumentException ||
                    ex is DivideByZeroException ||
                    ex is IndexOutOfRangeException ||
                    ex is OverflowException ||
                    ex is MyException
                )
                {
                    Console.WriteLine($"Обработано {ex.Message}.");
                }
            }
            Console.ReadKey();
        }
    }
}
