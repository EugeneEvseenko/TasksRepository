using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Final_Task_13._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // читаем файл
            var text = File.ReadAllText($"{AppDomain.CurrentDomain.BaseDirectory}\\Text1.txt");

            // отсеиваем символы
            var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());

            //разбиваем строку на части
            var splittedText = noPunctuationText.Split()
                .Where(w => w.Length > 3).ToList(); // и берем строки длиной больше трех символов

            Dictionary<string, long> dict = new();

            // перебираем получившийся список
            foreach (var punctuation in splittedText)
            {
                if (dict.ContainsKey(punctuation)) // увеличиваем значение если ключ уже существует
                    dict[punctuation]++;
                else
                    dict[punctuation] = 1; // создаем пару и присваеваем единицу если не существует
            }

            // сортируем по значению и берем 10 элементов из общего списка
            foreach (var word in dict.OrderByDescending(key => key.Value).Take(10))
            {
                Console.WriteLine($"Слово \"{word.Key}\" [{word.Value}]");
            }
            Console.ReadKey();
        }
    }
}
