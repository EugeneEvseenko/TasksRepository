using System;

namespace Task_5._3._6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 1, 2, 3 };
            int kek = 8; // переменная которую не должна изменить функция
            BigDataOperation(arr, kek);
            Console.WriteLine(arr[0]);
            Console.ReadKey();
        }
        /* оператор in позволяет передавать параметры 
         * в ссылочном виде, при этом запрещает изменять их */
        static void BigDataOperation(in int[] arr, in int num)
        {
            /* изменить можно так как меняется параметр 
             * не целиком, а изнутри */
            arr[0] = 4;
            arr = new int[num]; // такое изменение уже не прокатит

            /* попытка изменения параметра который нельзя
             * менять внутри функции приводит к ошибке */
            num = 5; 
        }
    }
}
