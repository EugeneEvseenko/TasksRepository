using System;

namespace Task_7._6._6
{
    internal class Program
    {
        class Record<T1, T2>
        {
            public T1 Id;
            public T2 Value;
            public DateTime date;
            public override string ToString()
            {
                return $"Id: {Id} Value: {Value} Date: {date}";
            }
        }
        static void Main(string[] args)
        {
            Record<int, int> record = new() { Id = 1, Value = 2, date = DateTime.Now };
            Record<string, double> record2 = new() { Id = "kek", Value = 2.5, date = DateTime.Now };
            Console.WriteLine(record.ToString());
            Console.WriteLine(record2.ToString());
            Console.ReadKey();
        }
    }
}
