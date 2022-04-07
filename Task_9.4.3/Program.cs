using System;

namespace Task_9._4._3
{
    class Parent { }

    class Child : Parent { }
    internal class Program
    {
        public delegate Parent HandlerMethod();
        delegate void ChildInfo(Child child);

        public static Parent ParentHandler() => null;
        public static Child ChildHandler() => null;
        public static void GetParentInfo(Parent p)
        {
            Console.WriteLine(p.GetType());
        }
        static void Main(string[] args)
        {
            ChildInfo childInfo = GetParentInfo; // контрвариантность

            childInfo.Invoke(new Child());

            Console.Read();
        }
    }
}
