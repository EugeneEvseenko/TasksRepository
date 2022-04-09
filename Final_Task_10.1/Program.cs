using System;
using System.ComponentModel;

namespace Final_Task_10._1
{
    
    internal class Program
    {
        public static void PrintExeption(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (ex is DivideByZeroException)
                Console.WriteLine("Произошла попытка деления на ноль.");
            else
                Console.WriteLine(ex.Message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void Main(string[] args)
        {
            ICalculator calculator = new Calculator();
            int first, second;
            Operations operation;
        enterfirst: Console.WriteLine("Введите первое число");
            try
            {
                first = int.Parse(Console.ReadLine());
            }catch(Exception ex)
            {
                PrintExeption(ex); goto enterfirst;
            }
            
        entersecond: Console.WriteLine("Введите второе число");
            try
            {
                second = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                PrintExeption(ex); goto entersecond;
            }

        enteroperation: 
            Console.WriteLine("Выберите операцию над числами\n" +
            "1 - Сложение\n" +
            "2 - Вычитание\n" +
            "3 - Умножение\n" +
            "4 - Деление\n");
            try
            {
                if (!int.TryParse(Console.ReadLine(), out int operationInt))
                    throw new InvalidOperationException("Введенное значение не является числом.");
                if (operationInt < 1 || operationInt > 4)
                    throw new InvalidOperationException("Принимаются числа только в диапазоне от 1 до 4.");
                operation = (Operations)operationInt;
            }
            catch (InvalidOperationException ex)
            {
                PrintExeption(ex); goto enteroperation;
            }
            try
            {
                Console.WriteLine(
                    $"{first} {operation.GetEnumDescription()} {second} = {calculator.MakeOperation(operation, first, second)}"
                );
            }
            catch (Exception ex)
            {
                PrintExeption(ex); goto enterfirst;
            }
            Console.WriteLine("Операция закончена. Повторим?");
            if (Console.ReadLine().Trim().ToLower() == "да")
                goto enterfirst;
        }
    }
}
