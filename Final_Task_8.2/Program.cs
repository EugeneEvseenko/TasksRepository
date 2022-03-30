using System;
using System.IO;

namespace Final_Task_8._2
{
    internal class Program
    {
        public static long GetDirSize(DirectoryInfo directory, ref long size)
        {
            DirectoryInfo[] dirs = directory.GetDirectories();
            foreach (FileInfo file in directory.GetFiles())
            {
                size += file.Length;
            }
            foreach (DirectoryInfo dir in dirs)
            {
                GetDirSize(dir, ref size);
            }
            return size;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь до папки. exit - выход");
            string text = Console.ReadLine();
            while (text != "exit")
            {
                DirectoryInfo dir = new DirectoryInfo(text);
                try
                {
                    if (dir.Exists)
                    {
                        long dirSize = 0;
                        dirSize = GetDirSize(dir, ref dirSize);
                        Console.WriteLine(dirSize > 0 ? $"Размер папки: {dirSize} байт" : "Папка пуста.");
                    }
                    else
                    {
                        Console.WriteLine($"Папка {text} не существует.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка доступа к папке {dir.Name}.");
                    Console.WriteLine(ex.ToString());
                }

                Console.WriteLine("Введите путь до папки. exit - выход");
                text = Console.ReadLine();
            }
        }
    }
}
