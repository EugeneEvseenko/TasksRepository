using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Task_10._2
{
    public class Calculator : ICalculator
    {
        ILogger Logger { get; }
        public Calculator(ILogger logger)
        {
            Logger = logger;
        }
        public int MakeOperation(Operations operation, int a, int b)
        {
            var result = operation switch
            {
                Operations.Substract => Substract(a, b),
                Operations.Multiply => Multiply(a, b),
                Operations.Divide => Divide(a, b),
                _ => Addition(a, b),
            };
            Logger.Event($"{a} {operation.GetEnumDescription()} {b} = {result}");
            return result;
        }
        public int Addition(int a, int b) => a + b;
        public int Substract(int a, int b) => a - b;
        public int Multiply(int a, int b) => a * b;
        public int Divide(int a, int b) => a / b;
    }
}
