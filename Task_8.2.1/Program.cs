using System;
using System.IO;

namespace Task_8._2._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GetCounts(@"C:\");
            Console.ReadKey();
        }
        static void GetCounts(string path)
        {
            if (Directory.Exists(path))
            {
                string[] dirs = Directory.GetDirectories(path);
                string[] files = Directory.GetFiles(path);
                Console.WriteLine($"Количество папок по пути {path}: {dirs.Length}\n" +
                    $"Количество файлов по пути {path}: {files.Length}");
            }
            else
                Console.WriteLine("Такого пути нет.");
        }
    }
}
