using System;

namespace Task_7._2._12
{
    internal class Program
    {
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
