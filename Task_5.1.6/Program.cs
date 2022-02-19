using System;

namespace Task_5._1._6
{
    internal class Program
    {
        static int[] GetArrayFromConsole()
        {
            var result = new int[5];

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
        static void PrintArray(string label, int[] arr)
        {
            Console.WriteLine($"============ {label.ToUpper()} ============");
            for (int i = 0;i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine("\n");
        }
        static void Main(string[] args)
        {
            int[] array = GetArrayFromConsole();
            int[] sortedArray = GetSortedArray(array);
            PrintArray("Несортированный массив", array);
            PrintArray("Сортированный массив", sortedArray);
            Console.ReadKey();
        }
    }
}
