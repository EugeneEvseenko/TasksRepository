using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Task_10._1
{
    public class Calculator : ICalculator
    {
        public int MakeOperation(Operations operation, int a, int b)
        {
            switch (operation)
            {
                default: return Addition(a, b);
                case Operations.Substract: return Substract(a, b);
                case Operations.Multiply: return Multiply(a, b);
                case Operations.Divide: return Divide(a, b);
            }
        }
        public int Addition(int a, int b) => a + b;
        public int Substract(int a, int b) => a - b;
        public int Multiply(int a, int b) => a * b;
        public int Divide(int a, int b) => a / b;
    }
}
