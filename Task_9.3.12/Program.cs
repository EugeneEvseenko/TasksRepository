using System;

namespace Task_9._3._12
{
    internal class Program
    {
        delegate void ShowMessageDelegate(string _message);
        static void Main(string[] args)
        {
            ShowMessageDelegate sd = (string _message) =>
            {
                Console.WriteLine(_message);
            };
            sd.Invoke("Hello world!");
            Console.Read();
        }
    }
}
