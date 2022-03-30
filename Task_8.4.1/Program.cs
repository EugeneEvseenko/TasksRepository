using System;
using System.IO;

namespace Task_8._4._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // сохраняем путь к файлу (допустим, вы его скачали на рабочий стол)
            string filePath = $"{AppDomain.CurrentDomain.BaseDirectory}\\BinaryFile.bin";

            // при запуске проверим, что файл существует
            if (File.Exists(filePath))
            {
                // строковая переменная, в которую будем считывать данные
                string stringValue;

                // считываем, после использования высвобождаем задействованный ресурс BinaryReader
                using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
                {
                    stringValue = reader.ReadString();
                }

                // Вывод
                Console.WriteLine("Из файла считано:");
                Console.WriteLine(stringValue);
            }
            Console.ReadLine();
        }
    }
}
