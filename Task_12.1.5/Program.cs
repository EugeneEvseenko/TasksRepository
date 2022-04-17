using System;
using System.Collections.Generic;
using System.Threading;

namespace Task_12._1._5
{
    internal class Program
    {
		static void ShowAds()
		{
			Console.WriteLine("Посетите наш новый сайт с бесплатными играми free.games.for.a.fool.com");
			Thread.Sleep(1000);

			Console.WriteLine("Купите подписку на МыКомбо и слушайте музыку везде и всегда.");
			Thread.Sleep(2000);

			Console.WriteLine("Оформите премиум-подписку на наш сервис, чтобы не видеть рекламу.");
			Thread.Sleep(3000);
		}

		static List<User> users = new()
		{
			new User { Name = "Чумаков Даниил Александрович", Login = "daniil", IsPremium = true },
			new User { Name = "Кузнецов Алексей Васильевич", Login = "alex", IsPremium = false },
			new User { Name = "Иванов Мирон Александрович", Login = "miron", IsPremium = true },
			new User { Name = "Ершова Алина Дмитриевна", Login = "alina", IsPremium = true },
			new User { Name = "Астахов Максим Даниилович", Login = "maxim", IsPremium = false }
		};

		static void Main(string[] args)
        {
            Console.WriteLine("Введите логин:");
			string login = Console.ReadLine().ToLower().Trim();
			if (users.Exists(u => u.Login == login))
			{
				User user = users.Find(u => u.Login == login);
				Console.WriteLine($"Добро пожаловать {user.Name}!");
				if (!user.IsPremium) ShowAds();
			}
			else
				Console.WriteLine("Пользователь не найден!");
			Console.ReadKey();
        }
    }
}
