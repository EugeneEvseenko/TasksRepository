using System;

namespace Task_5._3._13
{
    internal class Program
    {
        static int[] SortArrayDesc(int[] arr)
        {
            int[] outArray = new int[arr.Length];
            arr.CopyTo(outArray, 0);
            int temp;
            for (int i = 0; i < outArray.Length; i++)
            {
                for (int j = i + 1; j < outArray.Length; j++)
                {
                    if (outArray[i] < outArray[j])
                    {
                        temp = outArray[i];
                        outArray[i] = outArray[j];
                        outArray[j] = temp;
                    }
                }
            }
            return outArray;
        }
        static int[] SortArrayAsc(int[] arr)
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
        static void SortArray(in int[] array, out int[] sorteddesc, out int[] sortedasc)
        {
            sorteddesc = SortArrayDesc(array);
            sortedasc = SortArrayAsc(array);
        }
        static void Main(string[] args)
        {
            int[] array = new int[5];
            Random randNum = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = randNum.Next(1, 10);
            }
            SortArray(array, out int[] sorteddesc, out int[] sortedasc);
            Console.WriteLine("Исходный массив");
            foreach (int i in array)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine("\nМассив по убыванию");
            foreach (int i in sorteddesc)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine("\nМассив по возрастанию");
            foreach (int i in sortedasc)
            {
                Console.Write($"{i} ");
            }
            Console.ReadKey();
        }
    }
}
