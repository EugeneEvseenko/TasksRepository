using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_14._2._3
{
    internal class Program
    {
        public class Student
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public List<string> Languages { get; set; }
        }
        public class Application
        {
            public string Name { get; set; }
            public int YearOfBirth { get; set; }
            public override string ToString()
            {
                return $"{Name} - {YearOfBirth} года.";
            }
        }
        static void Main(string[] args)
        {
            List<Student> students = new()
            {
                new Student {Name="Андрей", Age=23, Languages = new List<string> {"английский", "немецкий" }},
                new Student {Name="Сергей", Age=27, Languages = new List<string> {"английский", "французский" }},
                new Student {Name="Дмитрий", Age=29, Languages = new List<string> {"английский", "испанский" }},
                new Student {Name="Василий", Age=24, Languages = new List<string> {"испанский", "немецкий" }}
            };

            var youngStudents = from s in students
                                where s.Age < 27
                                let DOB = DateTime.Now.Year - s.Age
                                select new Application{ Name = s.Name, YearOfBirth = DOB };

            foreach (var student in youngStudents)
                Console.WriteLine(student.ToString());

            Console.ReadKey();
        }
    }
}
