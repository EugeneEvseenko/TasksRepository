using System;
using System.Collections.Generic;

namespace Task_13._5._4
{
    internal class Program
    {
        public static Stack<string> words = new();
        static void Main(string[] args)
        {
            Console.WriteLine("Введите слово и нажмите Enter, чтобы добавить его в стек.");
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("Введите команду. (pop, peek)");
                var comand = Console.ReadLine().Trim().ToLower();

                switch (comand)
                {
                    case "pop":
                        if (words.TryPop(out string popped))
                            Console.Write($" - {popped}\n");
                        else
                            Console.WriteLine("Стек пуст.");
                        break;
                    case "peek":
                        if (words.TryPeek(out string peeked))
                            Console.WriteLine($" - {peeked}\n");
                        else
                            Console.WriteLine("Стек пуст.");
                        break;
                    default:
                        words.Push(comand); break;
                }
                if (words.Count == 0) continue;
                Console.WriteLine("В стеке:");

                foreach (var word in words)
                {
                    Console.WriteLine(" " + word);
                }
            }
        }
    }
}
