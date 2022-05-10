using System;
using System.Collections.Generic;
using System.Linq;

namespace Final_Task_14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var phoneBook = new List<Contact>
            {
                new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"),
                new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"),
                new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"),
                new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"),
                new Contact("Сергей", "Брин", 799900000013, "serg@example.com"),
                new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com")
            }.OrderBy(x => x.Name).ToList();

            /*  
            *  определяем четное количество контактов или нет
            *  если да, делим просто на два, если нет, добавляем 
            *  единицу к общему числу страниц.
            */
            var maxPage = phoneBook.Count / 2 + (phoneBook.Count % 2 == 0 ? 0 : 1);

            while (true)
            {
                entercommand:
                Console.WriteLine($"\nВведи страницу (1 - {maxPage})\n" +
                                  $"Введи 'sort' чтобы сменить тип сортировки.\n");

                string command = Console.ReadLine().Trim().ToLower();
                if (command == "sort")
                {
                    inputsortby: 
                    Console.WriteLine("Выбери тип сортировки.\n" +
                                      "1 - По имени\n" +
                                      "2 - По фамилии");
                    string sortEnterText = Console.ReadLine().Trim();

                    if (sortEnterText == "1")
                    {
                        phoneBook = phoneBook.OrderBy(x => x.Name).ToList();
                        Console.WriteLine("Выбрана сортировка по имени.");
                        goto entercommand;
                    }
                    else if (sortEnterText == "2")
                    {
                        phoneBook = phoneBook.OrderBy(x => x.LastName).ToList();
                        Console.WriteLine("Выбрана сортировка по фамилии.");
                        goto entercommand;
                    }
                    else
                    {
                        Console.WriteLine("Вводить можно только 1 или 2.\n" +
                                            "Попробуем ещё раз.\n");
                        goto inputsortby;
                    }
                }

                // пытаемся преобразовать строку в число
                if (int.TryParse(command, out int page))
                {
                    // проверяем не выходим ли за границы допустимых страниц
                    if (page >= 1 && page <= maxPage)
                    {
                        // пропускаем небходимое количество элементов и берем 2.
                        var itemsInPage = phoneBook.Skip((page - 1) * 2).Take(2);

                        foreach (var item in itemsInPage)
                            Console.WriteLine($"[{phoneBook.IndexOf(item) + 1}] " +
                                $"{item.Name} {item.LastName} - {item.PhoneNumber} - {item.Email}");
                    }
                    else
                        Console.WriteLine($"У меня нет такого количества контактов для вывода.\n" +
                                          $"Страниц всего {maxPage}");
                }
                else
                    Console.WriteLine("Вводить нужно число.");
            }
        }
    }
}
