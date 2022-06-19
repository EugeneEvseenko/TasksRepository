using System;

namespace Task_7._6._2
{
    internal class Program
    {
        class Car<T>
        {
            public T Engine;
            public Car(T engine)
            {
                Engine = engine;
            }
        }
        class ElectricEngine { }
        class GasEngine { }
        static void Main(string[] args)
        {
            var car = new Car<ElectricEngine>(new ElectricEngine());
            //car.Engine = new GasEngine(); // ошибка
            Console.WriteLine("Hello World!");
        }
    }
}
