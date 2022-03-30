using System;
using System.IO;

namespace Final_Task_8._3
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
                if (dir.Exists)
                {
                    long BeforeSize = 0;
                    BeforeSize = GetDirSize(dir, ref BeforeSize);
                    Console.WriteLine($"Размер до очистки: {BeforeSize} байт");
                    try
                    {
                        foreach (DirectoryInfo directory in dir.GetDirectories())
                        {
                            if (directory.LastAccessTime <= DateTime.Now.AddMinutes(-30))
                            {
                                directory.Delete(true);
                            }
                        }
                        foreach (FileInfo file in dir.GetFiles())
                        {
                            if (file.LastAccessTime <= DateTime.Now.AddMinutes(-30))
                            {
                                file.Delete();
                            }
                        }
                        long AfterSize = 0;
                        AfterSize = GetDirSize(dir, ref AfterSize);
                        Console.WriteLine($"Освобождено: {BeforeSize - AfterSize} байт");
                        Console.WriteLine($"Размер после очистки: {AfterSize} байт");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Произошла ошибка доступа к папке {dir.Name}.");
                        Console.WriteLine(ex.ToString());
                    }
                }
                else
                {
                    Console.WriteLine($"Папка {text} не существует.");
                }
                Console.WriteLine("Введите путь до папки. exit - выход");
                text = Console.ReadLine();
            }
        }
    }
}
