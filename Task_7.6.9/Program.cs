using System;
using System.Collections.Generic;

namespace Task_7._6._9
{
    internal class Program
    {
        // ограничение по нескольким типам двигателя общим классом
        class Car<TEngine> where TEngine : Engine
        {
            public TEngine Engine;
            public List<Part> listParts = new();
            public Car(TEngine engine)
            {
                Engine = engine;
            }
            /* Аналогичное ограничение типа параметра общим классом Part т.е. будут *
             * приняты только наследники класса Part(Battery, Differential и Wheel) */
            public void ChangePart<TPart>(TPart newPart) where TPart : Part
            {
                listParts.Add(newPart);
            }
        }
        abstract class Engine { }
        class ElectricEngine : Engine { }
        class GasEngine : Engine { }

        abstract class Part {
            public string name;
        }
        class Battery : Part {
            public string BatteryType;
        }
        class Differential : Part { }
        class Wheel : Part { }
        static void Main(string[] args)
        {
            var car = new Car<GasEngine>(new GasEngine());
            var car2 = new Car<ElectricEngine>(new ElectricEngine());
            car.ChangePart(new Battery() { name = "Батарея 1", BatteryType = "Тип 1"});
            car.ChangePart(new Wheel() { name = "Переднее левое колесо" });
            foreach(Part part in car.listParts)
            {
                Console.WriteLine(part.name);
            }
            Console.ReadKey();
        }
    }
}
