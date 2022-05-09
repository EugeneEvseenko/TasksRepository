using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_14._2._5
{
    internal class Program
    {
        public class Contact
        {
            public string Name { get; set; }
            public long Phone { get; set; }
        }
        static void Main(string[] args)
        {
            var contacts = new List<Contact>()
            {
               new Contact() { Name = "Андрей", Phone = 7999945005 },
               new Contact() { Name = "Сергей", Phone = 799990455 },
               new Contact() { Name = "Иван", Phone = 79999675 },
               new Contact() { Name = "Игорь", Phone = 8884994 },
               new Contact() { Name = "Анна", Phone = 665565656 },
               new Contact() { Name = "Василий", Phone = 3434 },
               new Contact() { Name = "Василий2", Phone = 3434 }
            };

            while (true)
            {
                var maxPage = contacts.Count / 2 + (contacts.Count % 2 == 0 ? 0 : 1);
                Console.WriteLine($"Введи страницу (1 - {maxPage})");
                if (int.TryParse(Console.ReadLine(), out int page))
                {
                    if (maxPage >= page)
                    {
                        var itemsInPage = contacts.Skip((page - 1) * 2).Take(2);
                        foreach (var item in itemsInPage)
                            Console.WriteLine($"[{contacts.IndexOf(item) + 1}] {item.Name} - {item.Phone}");
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
