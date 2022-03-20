using System;

namespace Task_7._1._4
{
    internal class Program
    {
        class Employee
        {
            public string Name;
            public int Age;
            public int Salary;
        }
        class ProjectManager : Employee
        {
            public string ProjectName;
        }
        class Developer : Employee
        {
            public string ProgrammingLanguage;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
