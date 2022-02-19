using System;

namespace Task_5._1._6
{
    internal class Program
    {
        static int[] GetArrayFromConsole(int size = 5)
        {
            var result = new int[size];

            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine("Введите элемент массива номер {0}", i + 1);
                result[i] = int.Parse(Console.ReadLine());
            }

            return result;
        }
        static int[] GetSortedArray(int[] arr)
        {
            int[] outArray = new int[arr.Length];
            arr.CopyTo(outArray, 0);
            int temp;
            for (int i = 0; i < outArray.Length; i++)
            {
                for (int j = i + 1; j < outArray.Length; j++)
                {
                    if (outArray[i] > outArray[j])
                    {
                        temp = outArray[i];
                        outArray[i] = outArray[j];
                        outArray[j] = temp;
                    }
                }
            }
            return outArray;
        }
        static void ShowArray(int[] arr, string label, bool sort = false)
        {
            if(sort) arr = GetSortedArray(arr);
            Console.WriteLine($"============ {label.ToUpper()} ============");
            foreach (int item in arr)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine("\n");
        }
        static void Main(string[] args)
        {
            int[] array = GetArrayFromConsole(10);
            ShowArray(array, "Несортированный массив");
            ShowArray(array, "Сортированный массив", true);
            Console.ReadKey();
        }
    }
}
