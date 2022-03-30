using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FinalTask
{
    [Serializable]
    public class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Student(string name, string group, DateTime dateofbirth)
        {
            Name = name;
            Group = group;
            DateOfBirth = dateofbirth;
        }
    }
    class Program
    {
        public static string PathToDesktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\Students\";
        static void Main(string[] args)
        {
            Console.WriteLine();
            FileInfo dataFile = new($"{AppDomain.CurrentDomain.BaseDirectory}\\Students.dat");
            if (dataFile.Exists)
            {
                try
                {
                    DirectoryInfo directoryInfo = new(PathToDesktop);
                    if (!directoryInfo.Exists) directoryInfo.Create();
                }catch (Exception ex)
                {
                    Console.WriteLine("Ошибка при создании папки Students на рабочем столе.");
                    Console.WriteLine(ex.ToString());
                    goto end;
                }
                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    using var fs = new FileStream(dataFile.FullName, FileMode.Open);
                    Student[] students = (Student[])formatter.Deserialize(fs);
                    foreach (Student student in students)
                    {
                        SendToGroup(student);
                        Console.WriteLine($"Имя: {student.Name} | Группа: {student.Group} | День рождения: {student.DateOfBirth.ToShortDateString()}\n");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Что-то пошло не так при чтении файла");
                    Console.WriteLine(ex.ToString());
                }
            }
            else Console.WriteLine($"Не смог найти файл {dataFile.Name}.");
            end: Console.ReadKey();
        }
        public static void SendToGroup(Student stud)
        {
            var studentGroupFile = new FileInfo($"{PathToDesktop}{stud.Group}.txt");
            try
            {
                if (!studentGroupFile.Exists)
                {
                    using StreamWriter sw = studentGroupFile.CreateText();
                    sw.WriteLine(stud.Name + ", " + stud.DateOfBirth.ToShortDateString());
                }
                else
                {
                    using StreamWriter sw = studentGroupFile.AppendText();
                    sw.WriteLine(stud.Name + ", " + stud.DateOfBirth.ToShortDateString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при добавлении студента в группу.");
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
