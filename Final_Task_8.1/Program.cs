using System;
using System.IO;

namespace Final_Task_8._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь до папки. exit - выход");
            string text = Console.ReadLine();
            while (text != "exit")
            {
                DirectoryInfo dir = new DirectoryInfo(text);
                if (dir.Exists)
                {
                    try
                    {
                        foreach (DirectoryInfo directory in dir.GetDirectories())
                        {
                            if (directory.LastAccessTime <= DateTime.Now.AddMinutes(-30))
                            {
                                Console.WriteLine($"Удаляем папку {directory.Name}.");
                                directory.Delete(true);
                            }
                        }
                        foreach (FileInfo file in dir.GetFiles())
                        {
                            if (file.LastAccessTime <= DateTime.Now.AddMinutes(-30))
                            {
                                Console.WriteLine($"Удаляем файл {file.Name}.");
                                file.Delete();
                            }
                        }
                        Console.WriteLine($"Очистка папки {dir.Name} завершена.");
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
