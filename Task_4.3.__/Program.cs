using System;

namespace Task_4._3.__
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter чтобы начать");
            while (Console.ReadLine() != "exit")
            {
                int[] array = new int[20];
                for (int i = 0; i < 20; i++)
                {
                    array[i] = new Random().Next(-100, 100);
                    Console.Write($"{array[i]} ");
                }
                Console.WriteLine();
                int counter = 0;
                foreach (int i in array)
                {
                    if (i > 0) counter++;
                }
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"В массиве всего {counter} положительных чисел.");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine($"Введите exit чтобы выйти.");
            }
        }
    }
}
