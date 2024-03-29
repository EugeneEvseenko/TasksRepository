﻿using System;

namespace Task_5._5._3
{
    internal class Program
    {
        static void Echo(string saidworld, int deep)
        {
            Console.BackgroundColor = (ConsoleColor)deep;
            var modif = saidworld;
            if(modif.Length > 2) modif = modif.Remove(0, 2);
            Console.WriteLine($"...{modif}");

            if (deep > 1)
            {
                Echo(modif, deep - 1);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Напишите что-то");
            var str = Console.ReadLine();

            Console.WriteLine("Укажите глубину эха");
            var deep = int.Parse(Console.ReadLine());

            Echo(str, deep);

            Console.ReadKey();
        }
    }
}
