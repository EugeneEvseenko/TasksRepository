using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Task_10._2
{
    public interface ICalculator
    {
        int MakeOperation(Operations operation, int a, int b);
        int Addition(int a, int b);
        int Substract(int a, int b);
        int Multiply(int a, int b);
        int Divide(int a, int b);
    }
}
