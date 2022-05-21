using System;
using System.Linq;
using System.Collections.Generic;

namespace Task_15._2._8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new();
            while (true)
            {
                
                enternumber: Console.WriteLine("Введите новое число:");
                var inputLine = Console.ReadLine();
                Console.Clear();
                if (int.TryParse(inputLine, out int number))
                    numbers.Add(number);
                else
                {
                    Console.WriteLine("Вводить нужно число."); goto enternumber;
                }

                Console.WriteLine($"Сейчас в списке чисел: {numbers.Count}\n" +
                    $"Сумма чисел: {numbers.Sum()}\n" +
                    $"Наибольшее из них: {numbers.Max()}\n" +
                    $"Наименьшее: {numbers.Min()}\n" +
                    $"Среднее ариметическое: {numbers.Average()}\n");
            }
            
        }
    }
}
