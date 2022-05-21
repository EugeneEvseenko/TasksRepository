using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_15._4._1
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Employee
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var departments = new List<Department>()
            {
               new Department() {Id = 1, Name = "Программирование"},
               new Department() {Id = 2, Name = "Продажи"}
            };
            var employees = new List<Employee>()
            {
               new Employee() { DepartmentId = 1, Name = "Инна", Id = 1},
               new Employee() { DepartmentId = 1, Name = "Андрей", Id = 2},
               new Employee() { DepartmentId = 2, Name = "Виктор", Id = 3},
               new Employee() { DepartmentId = 3, Name = "Альберт ", Id = 4},
            };

            var joinedItems = departments.Join(employees,
                department => department.Id,
                employee => employee.DepartmentId,
                (dep, em) =>
                new
                {
                    DepartmentName = dep.Name,
                    EmployeeName = em.Name
                });
            foreach (var item in joinedItems)
                Console.WriteLine($"{item.EmployeeName} [{item.DepartmentName}]");

            Console.ReadKey();
        }
    }
}
