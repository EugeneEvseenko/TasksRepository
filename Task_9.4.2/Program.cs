using System;

namespace Task_9._4._2
{
    internal class Program
    {
        public class Car { }
        public class Lexus : Car { }
        public delegate Car HandlerMethod();

        public static Car CarHandler() => null;

        public static Lexus LexusHandler() => null;
        static void Main(string[] args)
        {
            HandlerMethod handlerLexus = LexusHandler; // ковариантость

            Console.Read();
        }
    }
}
