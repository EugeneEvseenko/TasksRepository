using System;

namespace Task_10._3._3
{
    internal class Program
    {
        public interface IBook
        {
            void Read();
        }

        public interface IDevice
        {
            void TurnOn();
            void TurnOff();
        }
        public class ElectronicBook : IBook, IDevice
        {
            void IBook.Read()
            {
                Console.WriteLine("Метод Read");
            }

            void IDevice.TurnOff()
            {
                Console.WriteLine("Метод TurnOff");
            }

            void IDevice.TurnOn()
            {
                Console.WriteLine("Метод TurnOn");
            }
        }
        static void Main(string[] args)
        {
            IBook book = new ElectronicBook();
            book.Read(); // доступ только к методу для чтения

            ElectronicBook electronicBook = new(); // нет доступа ни к одному методу
            ((IDevice)electronicBook).TurnOff(); // доступ появляется только при явном обращении
            ((IDevice)electronicBook).TurnOn(); // и тут
            ((IBook)electronicBook).Read(); // и тут
            Console.ReadKey();
        }
    }
}
