using System;
using System.IO;

namespace Task_13._1._6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText($"{AppDomain.CurrentDomain.BaseDirectory}\\cdev_Text.txt");
            char[] delimiters = new char[] { ' ', '\r', '\n' };
            var words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine(words.Length);
            Console.ReadKey();
        }
    }
}
