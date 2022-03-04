using System;

namespace Task_6._2._2
{
    internal class Program
    {
        class Pen
        {
            public string color;
            public int cost;
            public Pen()
            {
                color = "Черный";
                cost = 100;
            }
            public Pen(string penColor, int penCost)
            {
                color = penColor;
                cost = penCost;
            }
        }
        static void Main(string[] args)
        {
            Pen p1 = new();
            Console.WriteLine($"Color = {p1.color} Cost = {p1.cost}");
            Pen p2 = new("Желтый", 20);
            Console.WriteLine($"Color = {p2.color} Cost = {p2.cost}");
            Console.ReadKey();
        }
    }
}
