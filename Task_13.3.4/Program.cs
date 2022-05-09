using System;
using System.Collections.Generic;

namespace Task_13._3._4
{
    internal class Program
    {
        public class Contact
        {
            public Contact(string name, long phoneNumber, String email)
            {
                Name = name;
                PhoneNumber = phoneNumber;
                Email = email;
            }

            public String Name { get; }
            public long PhoneNumber { get; }
            public String Email { get; }
        }
        
        public static void AddUnique(Contact contact, List<Contact> phoneBook)
        {
            bool isExist = false;
            foreach (var item in phoneBook)
            {
                if (item.Name == contact.Name)
                {
                    isExist = true; break;
                }
            }
            if (!isExist)
            {
                phoneBook.Add(contact);
                Console.WriteLine($"Контакт \"{contact.Name}\" добавлен!");
            }
            else
                Console.WriteLine($"Контакт \"{contact.Name}\" уже существует!");

            Console.WriteLine("Список контактов:");
            foreach (var item in phoneBook)
                Console.WriteLine($"{item.Name} {item.PhoneNumber} {item.Email}");
            Console.WriteLine("\n");
        }
        static void Main(string[] args)
        {
            List<Contact> contacts = new();
            AddUnique(new Contact("Иван", 77081456821, "ivan@email.com"), contacts);
            AddUnique(new Contact("Иван", 77081456821, "ivan@email.com"), contacts);
            AddUnique(new Contact("Олег", 77471478523, "oleg@email.com"), contacts);
            AddUnique(new Contact("Женя", 77071759988, "john@email.com"), contacts);
            AddUnique(new Contact("Саша", 7702321854, "sasha@email.com"), contacts);
            AddUnique(new Contact("Олег", 77471478523, "oleg@email.com"), contacts);
            Console.ReadKey();
        }
    }
}
