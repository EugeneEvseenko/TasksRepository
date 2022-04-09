using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Task_10._1
{
    public enum Operations : byte
    {
        [Description("+")]
        Addition = 1,
        [Description("-")]
        Substract,
        [Description("*")]
        Multiply,
        [Description("/")]
        Divide
    }
}
