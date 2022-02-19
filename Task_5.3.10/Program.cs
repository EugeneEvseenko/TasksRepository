using System;

namespace Task_5._3._10
{
    internal class Program
    {
        /* модификатор out позволяет передавать параметры не объявляя их,
         * переменные так же передаются в ссылочном виде если были объявлены,
         * главное отличие от ref, это то что при использовании out
         * параметр обязан быть изменён.*/
        static void GetName(out string name, out string oldname)
        {
            oldname = "Евгения"; // всегда будет равна этому значению
            Console.WriteLine("Введите имя");
            name = Console.ReadLine(); // будет равна тому что введут
        }

        static void Main(string[] args)
        {
            /* нет объявления переменных, после 
             * выполнения функции они будут доступны */

            GetName(out string name, out var oldname);

            Console.WriteLine(name);
            Console.WriteLine(oldname);
            Console.ReadKey();
        }
    }
}
