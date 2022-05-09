using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Task_13._5._8
{
    internal class Program
    {
        public static ConcurrentQueue<string> words = new ConcurrentQueue<string>();
        static void Main(string[] args)
        {
            Console.WriteLine("Введите слово и нажмите Enter, чтобы добавить его в очередь.");
            Console.WriteLine();

            //  запустим обработку очереди в отдельном потоке
            StartQueueProcessing();

            while (true)
            {
                var input = Console.ReadLine().Trim().ToLower();

                if(input == "peek")
                {
                    if(words.TryPeek(out var peeked))
                        Console.WriteLine($"Последний в очереди: {peeked}");
                    
                } else
                    words.Enqueue(input);
            }
        }
        static void StartQueueProcessing()
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                while (true)
                {
                    Thread.Sleep(5000);
                    if (words.TryDequeue(out var element))
                        Console.WriteLine("======>  " + element + " прошел очередь");
                }

            }).Start();
        }
    }
}
