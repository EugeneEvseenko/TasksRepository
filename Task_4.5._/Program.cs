using System;

namespace Task_4._5._
{
    internal class Program
    {
        static void Main(string[] args)
        {
            (string Name, string LastName, string Login, int LoginLength, bool HasPet, string[] favcolors, double Age) User;
            for (int u = 0; u < 3; u++)
            {
                Console.WriteLine("Введите имя");
                User.Name = Console.ReadLine();
                Console.WriteLine("Введите фамилию");
                User.LastName = Console.ReadLine();
                Console.WriteLine("Введите логин");
                User.Login = Console.ReadLine();

                User.LoginLength = User.Login.Length;
                Console.WriteLine("Есть ли у вас животные ? Да или Нет");
                User.HasPet = Console.ReadLine().ToLower() == "да";
                Console.WriteLine("Введите возраст пользователя");
                User.Age = Convert.ToInt32(Console.ReadLine());
                User.favcolors = new string[3];
                Console.WriteLine("Введите три любимых цвета пользователя");
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine($"Введите цвет №{i + 1}");
                    User.favcolors[i] = Console.ReadLine();
                }
                Console.WriteLine(User.ToString());
                Console.ReadKey();
            }
        }
    }
}
