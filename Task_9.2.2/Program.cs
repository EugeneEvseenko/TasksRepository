using System;

namespace Task_9._2._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                throw new ArgumentNullException();
            }
            /* 
             *      Указание для обработки ошибок ArgumentOutOfRangeException
             * 
             * ArgumentException является родителем для ArgumentOutOfRangeException и
             * ArgumentNullException, поэтому указав его, можно отловить оба этих 
             * исключения. Для выборки ошибок можно использовать составные выражения.
             */
            catch (Exception ex) when (ex is ArgumentException)
            {
                Console.WriteLine($"Ошибка {ex}");
            }
            // можно и так, при запуске не сработает, потому что верхнеее
            // указание перехватит его
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Ошибка 2 {ex}");
            }
            /* 
             * Блок finally выполнится в любом случае, в случае успешного выполнения 
             * блока try, либо в случае срабатывании блока catch
             */
            finally
            {
                Console.WriteLine("Работа завершена.");
                Console.ReadKey();
            }
        }
    }
}
