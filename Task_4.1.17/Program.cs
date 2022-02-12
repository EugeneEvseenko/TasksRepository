using System;

namespace Task_4._1._17
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Напишите свой любимый цвет на английском с маленькой буквы");
			switch (Console.ReadLine())
			{
				case "red":
					Console.BackgroundColor = ConsoleColor.Red;
					Console.ForegroundColor = ConsoleColor.Black;
					Console.WriteLine("Your color is red!");
					break;
				case "green":
					Console.BackgroundColor = ConsoleColor.Green;
					Console.ForegroundColor = ConsoleColor.Black;
					Console.WriteLine("Your color is green!");
					break;
				case "cyan":
					Console.BackgroundColor = ConsoleColor.Cyan;
					Console.ForegroundColor = ConsoleColor.Black;
					Console.WriteLine("Your color is cyan!");
					break;
				default:
					Console.BackgroundColor = ConsoleColor.Yellow;
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Your color is yellow!");
					break;
			}
			Console.ReadKey();
		}
	}
}
