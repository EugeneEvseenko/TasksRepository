using System;

namespace Task_7._2._14
{
    internal class Program
    {
        class IndexingClass
        {
            private int[] array;

            public IndexingClass(int[] array)
            {
                this.array = array;
            }
            public int? /* int? для того чтобы была возможность вернуть null */ this[int index]
            {
                get
                {
                    // return this.array[index]; /* обычный возврат по индексу без проверок
                    if (index >= 0 && index < array.Length)
                    {
                        return array[index];
                    }
                    else
                    {
                        return null; // вернет null если индекс вне диапазонов
                    }
                }
                set
                {
                    if (index >= 0 && index < array.Length)
                    {
                        array[index] = value.Value;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            IndexingClass indexingClass = new IndexingClass(new int[] { 1, 2, 3, 4, 5, 8 });
            var num1 = indexingClass[0]; // 1
            var num2 = indexingClass[-1]; // null
            indexingClass[0] = 5; // 1 -> 5
            indexingClass[8] = 6; // такого индекса нет, ничего не изменится, так как есть проверка
        }
    }
}
