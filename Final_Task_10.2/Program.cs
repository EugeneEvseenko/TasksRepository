using System;

namespace Final_Task_10._2
{
    internal class Program
    {
        static ILogger _logger;
        static void Main(string[] args)
        {
            _logger = new Logger();
            ICalculator calculator = new Calculator(_logger);
            int first, second;
            Operations operation;
        enterfirst: _logger.Event("Введите первое число");
            try
            {
                first = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                goto enterfirst;
            }

        entersecond: _logger.Event("Введите второе число");
            try
            {
                second = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message); goto entersecond;
            }

        enteroperation:
            _logger.Event("Выберите операцию над числами\n" +
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
                _logger.Error(ex.Message); goto enteroperation;
            }
            try
            {
                calculator.MakeOperation(operation, first, second, out int result);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message); goto enterfirst;
            }
            _logger.Event("Операция закончена. Повторим?");
            if (Console.ReadLine().Trim().ToLower() == "да")
                goto enterfirst;
        }
    }
}
