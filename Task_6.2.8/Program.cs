using System;

namespace Task_6._2._8
{
    internal class Program
    {
        class Rectangle
        {
            public int a;
            public int b;
            public Rectangle()
            {
                a = 6;
                b = 4;
            }
            public Rectangle(int num)
            {
                a = num;
                b = num;
            }
            public Rectangle(int a, int b)
            {
                this.a = a;
                this.b = b;
            }
            public int Square()
            {
                return a * b;
            }
        }
        static void Main(string[] args)
        {
            Rectangle rect1 = new Rectangle();
            Rectangle rect2 = new Rectangle(5);
            Rectangle rect3 = new Rectangle(2, 13);
            Console.WriteLine($"[rect1] a = {rect1.a} b = {rect1.b} Square = {rect1.Square()}");
            Console.WriteLine($"[rect2] a = {rect2.a} b = {rect2.b} Square = {rect2.Square()}");
            Console.WriteLine($"[rect3] a = {rect3.a} b = {rect3.b} Square = {rect3.Square()}");
            Console.ReadKey();
        }
    }
}
