using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Task_9._2
{
    public class SortingList
    {
        public event InputComplete InputCompleted;
        public event SelectSortTypeComplete SelectSortTypeCompleted;
        public event SortComplete SortCompleted;
        
        private List<string> NamesList { get; set; } = new();

        public void StartInputNames()
        {
            while (NamesList.Count != 5)
            {
                try
                {
                    Console.WriteLine($"Введите имя №{NamesList.Count + 1}");
                    string name = Console.ReadLine();
                    if(name.Trim().Length == 0) 
                        throw new InvalidNameException("Имя не может состоять только из пробелов или быть пустым.");
                    NamesList.Add(name);
                }catch (Exception ex) when (ex is InvalidNameException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor= ConsoleColor.White;
                }
            }
            OnInputCompleted();
        }
        public void StartSelectSortType()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine(
                        "Выберите тип сортировки:\n" +
                        "1 - По возрастанию (А - Я)\n" +
                        "2 - По убыванию (Я - А)");

                    if (!int.TryParse(Console.ReadLine(), out int sortInt))
                        throw new InvalidSortTypeException("Введенное значение не является числом.");

                    if (sortInt != 1 && sortInt != 2)
                        throw new InvalidSortTypeException("Принимаются числа только в диапазоне от 1 до 2.");
                    OnSelectSortingType((SortingTypes)sortInt);
                    break;
                }
                catch(InvalidSortTypeException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
        public void StartSorting(SortingTypes sortingType)
        {
            NamesList.Sort();
            if (sortingType == SortingTypes.Descending) NamesList.Reverse();
            OnSortCompleted();
        }
        protected virtual void OnInputCompleted()
        {
            InputCompleted?.Invoke();
        }
        protected virtual void OnSelectSortingType(SortingTypes sortingType)
        {
            SelectSortTypeCompleted?.Invoke(sortingType);
        }
        protected virtual void OnSortCompleted()
        {
            SortCompleted?.Invoke(NamesList);
        }
    }
}
