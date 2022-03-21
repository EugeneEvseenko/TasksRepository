using System;

namespace Task_7._5._2
{
    internal class Program
    {
        class Obj
        {
            public string Name;
            public string Description;
            public static int MaxValue = 2000;
        }
        static void Main(string[] args)
        {
            Console.WriteLine($"MaxValue = {Obj.MaxValue}");
            Obj obj1 = new Obj();
            Obj obj2 = new Obj();
            Obj.MaxValue = 200;
            Console.WriteLine($"MaxValue = {Obj.MaxValue}");
            Console.ReadKey();
        }
    }
}
