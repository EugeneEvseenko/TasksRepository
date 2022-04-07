using System;
using System.Collections.Generic;

namespace Final_Task_9._2
{
    internal class Program
    {
        public static SortingList sortingList = new();
        static void Main(string[] args)
        {
            sortingList.InputCompleted += VoidInputComplete;
            sortingList.SelectSortTypeCompleted += FuncSelectSortTypeComplete;
            sortingList.SortCompleted += FuncSortComplete;
            sortingList.StartInputNames();

            Console.ReadKey();
        }
        public static void VoidInputComplete()
        {
            Console.WriteLine("Ввод окончен!");
            sortingList.StartSelectSortType();
        }
        public static void FuncSelectSortTypeComplete(SortingTypes sortingType)
        {
            Console.WriteLine("Выбор сортировки окончен!");
            Console.WriteLine($"Выбрана сортировка {(sortingType == SortingTypes.Ascending ? "по возрастанию" : "по убыванию")}.");
            sortingList.StartSorting(sortingType);
        }
        public static void FuncSortComplete(List<string> sortedList)
        {
            Console.WriteLine("Сортировка окончена!");
            foreach (string name in sortedList)
            {
                Console.WriteLine(name);
            }
        }
    }
}
