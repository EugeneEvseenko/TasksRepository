using System;

namespace Task_7._3._3
{
    public abstract class ComputerPart
    {
        public abstract void Work();
    }
    public class Processor : ComputerPart
    {
        public override void Work()
        {
            Console.WriteLine("Включаем процессор");
        }
    }
    public class MotherBoard : ComputerPart
    {
        public override void Work()
        {
            Console.WriteLine("Включаем материнку");
        }
    }
    public class GraphicCard : ComputerPart
    {
        public override void Work()
        {
            Console.WriteLine("Включаем видеокарту");
        }
    }
}
