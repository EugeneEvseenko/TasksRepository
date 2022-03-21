using System;

namespace Task_7._2._12
{
    internal class Program
    {
        /*      Операторы доступные к перегрузке        */
        /* 
             +x, -x, !x, ~x,                Унарные операторы (операция над 1 элементом)
             ++, --, true, false
         
             x + y, x - y, x * y, x / y,    Бинарные операторы (операция над 2 элементами), 
             x % y, x & y, x | y, x ^ y,    которые перегружаются независимо друг от друга
             x << y, x >> y

             x == y и x != y,               Бинарные операторы, которые перегружаются попарно 
             x < y и x > y,                 (т.е. при перегрузке одного элемента из пары обязан 
             x <= y и x >= y                быть перегружен и другой оператор)
         */

        class Obj
        {
            public int Value;
            /*
             *  Переопределение операции сложения между двумя 
             *  однотипными объектами типа Obj. Нельзя изменять
             *  входящие объекты. (можно, но может привести к
             *  путанице)
             */
            public static Obj operator +(Obj a, Obj b)
            {
                return new Obj
                {
                    Value = a.Value + b.Value
                };
            }
            // Аналогичная операция, но уже вычитания.
            public static Obj operator -(Obj a, Obj b)
            {
                return new Obj
                {
                    Value = a.Value - b.Value
                };
            }
        }
        static void Main(string[] args)
        {
            Obj obj1 = new Obj { Value = 1 };
            Obj obj2 = new Obj { Value = 5 };
            Console.WriteLine((obj1 + obj2).Value);
            Console.WriteLine((obj2 - obj1).Value);
            Console.ReadKey();
        }
    }
}
