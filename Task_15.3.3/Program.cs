using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_15._3._3
{
    public class Contact
    {
        public string Name { get; set; }
        public long Phone { get; set; }
        public string Email { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var phoneBook = new List<Contact>
            {
                new Contact { Name = "Игорь", Phone = 79990000001, Email = "igor@example.com" },
                new Contact { Name = "Сергей", Phone = 79990000010, Email = "serge@example.com" },
                new Contact { Name = "Анатолий", Phone = 79990000011, Email = "anatoly@example.com" },
                new Contact { Name = "Валерий", Phone = 79990000012, Email = "valera@example.com" },
                new Contact { Name = "Сергей", Phone = 799900000013, Email = "serg@gmail.com" },
                new Contact { Name = "Иннокентий", Phone = 799900000013, Email = "innokentii@example.com" }
            };

            var groupFakes = phoneBook.GroupBy(x => x.Email.Split("@").Last());
            foreach (var group in groupFakes)
            {
                if (group.Key.Contains("example"))
                {
                    Console.WriteLine("Фейковые адреса: ");
                    foreach (var contact in group)
                        Console.WriteLine(contact.Name + " " + contact.Email);
                }
                else
                {
                    Console.WriteLine("Реальные адреса: ");
                    foreach (var contact in group)
                        Console.WriteLine(contact.Name + " " + contact.Email);
                }

                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
