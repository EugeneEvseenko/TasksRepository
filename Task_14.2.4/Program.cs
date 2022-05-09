using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_14._2._4
{
    internal class Program
    {
        public class Student
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public List<string> Languages { get; set; }
        }
        public class Course
        {
            public string Name { get; set; }
            public DateTime StartDate { get; set; }
        }
        static void Main(string[] args)
        {
            var students = new List<Student>
            {
               new Student {Name="Андрей", Age=23, Languages = new List<string> {"английский", "немецкий" }},
               new Student {Name="Сергей", Age=27, Languages = new List<string> {"английский", "французский" }},
               new Student {Name="Дмитрий", Age=29, Languages = new List<string> {"английский", "испанский" }}
            };

            var courses = new List<Course>
            {
               new Course {Name="Язык программирования C#", StartDate = new DateTime(2020, 12, 20)},
               new Course {Name="Язык SQL и реляционные базы данных", StartDate = new DateTime(2020, 12, 15)},
            };

            var studentsWithCoarses = from stud in students
                                      from coarse in courses
                                      select new { Name = stud.Name, CoarseName = coarse.Name };

            foreach (var stud in studentsWithCoarses)
                Console.WriteLine($"Студент {stud.Name} добавлен курс {stud.CoarseName}");

            Console.WriteLine();

            var sharpCourse = from stud in students
                              where stud.Age < 29
                              where stud.Languages.Contains("английский")
                              from course in courses
                              where course.Name.Contains("C#")
                              select new
                              {
                                  Name = stud.Name,
                                  Birth = DateTime.Now.Year - stud.Age,
                                  Course = course.Name
                              };

            foreach (var stud in sharpCourse)
                Console.WriteLine($"Студент {stud.Name} {stud.Birth} года записан на курс {stud.Course}");

            Console.ReadKey();
        }
    }
}
