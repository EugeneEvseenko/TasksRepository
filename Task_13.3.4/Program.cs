using System;
using System.Collections.Generic;

namespace Task_13._3._4
{
    internal class Program
    {
        public class Contact
        {
            public Contact(long phoneNumber, String email)
            {
                PhoneNumber = phoneNumber;
                Email = email;
            }

            public long PhoneNumber { get; }
            public String Email { get; }
        }
        
        public static void AddUnique(string name, Contact contact, Dictionary<string, Contact> phoneBook)
        {
            if (!phoneBook.ContainsKey(name))
            {
                phoneBook.Add(name, contact);
                Console.WriteLine($"Контакт \"{name}\" добавлен!");
            }
            else
                Console.WriteLine($"Контакт \"{name}\" уже существует!");

            Console.WriteLine("Список контактов:");
            foreach (var item in phoneBook)
                Console.WriteLine($"{item.Key} {item.Value.PhoneNumber} {item.Value.Email}");
            Console.WriteLine("\n");
        }
        static void Main(string[] args)
        {
            Dictionary<string, Contact> contacts = new();
            AddUnique("Иван", new Contact(77081456821, "ivan@email.com"), contacts);
            AddUnique("Иван", new Contact(77081456821, "ivan@email.com"), contacts);
            AddUnique("Олег", new Contact(77471478523, "oleg@email.com"), contacts);
            AddUnique("Женя", new Contact(77071759988, "john@email.com"), contacts);
            AddUnique("Саша", new Contact(7702321854, "sasha@email.com"), contacts);
            AddUnique("Олег", new Contact(77471478523, "oleg@email.com"), contacts);
            Console.ReadKey();
        }
    }
}
