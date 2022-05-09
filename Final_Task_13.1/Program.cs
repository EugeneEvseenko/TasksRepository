using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Final_Task_13._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // чтение файла и разбивка текста
            var splitItems = File.ReadAllText($"{AppDomain.CurrentDomain.BaseDirectory}\\Text1.txt").Split();

            List<string> list = new();
            LinkedList<string> linkedList = new();

            // замер для List
            var stopwatch = Stopwatch.StartNew();
            foreach (string item in splitItems)
                list.Add(item);
            Console.WriteLine(
                $"Добавлено элементов в List: {list.Count}\n" +
                $"Затрачено времени: {stopwatch.ElapsedMilliseconds} ms\n\n");

            // замер для LinkedList
            stopwatch = Stopwatch.StartNew();
            foreach (string item in splitItems)
                linkedList.AddFirst(item);
            Console.WriteLine(
                $"Добавлено элементов в LinkedList: {linkedList.Count}\n" +
                $"Затрачено времени: {stopwatch.ElapsedMilliseconds} ms");

            /* процесс вставки в коллекцию List(~4 мс) занимает 
             * намного меньше времени чем в LinkedList(~20 мс) */

            Console.ReadKey();
        }
    }
}
