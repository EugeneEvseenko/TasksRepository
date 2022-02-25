using System;

namespace Project_5._6
{
    internal class Program
    {
        public static (string fname, string lname, int age, string[] pets, string[] favcolors) CreateUser()
        {
            var user = (fname: "", lname: "", age: 0, pets: new string[] { }, favcolors: new string[] { });
            Console.WriteLine("Введите ваше имя");
            user.fname = Console.ReadLine();
            Console.WriteLine("Введите вашу фамилию");
            user.lname = Console.ReadLine();
            while (true)
            {
                Console.WriteLine("Введите ваш возраст");
                int age = int.Parse(Console.ReadLine());
                if (CheckNumber(age))
                {
                    user.age = age;
                    break;
                }
                else
                    Console.WriteLine("Ошибка ввода. Повторите ввод.");
            }
            Console.WriteLine("У вас есть питомцы? (да/нет)");
            if(Console.ReadLine().ToLower() == "да")
            {
                while (true)
                {
                    Console.WriteLine("Сколько питомцев у вас?");
                    int petsCount = int.Parse(Console.ReadLine());
                    if (CheckNumber(petsCount))
                    {
                        user.pets = EnterPets(petsCount);
                        break;
                    }
                    else
                        Console.WriteLine("Ошибка ввода. Повторите ввод.");
                }
            }
            while (true)
            {
                Console.WriteLine("Введите количество любимых цветов");
                int colorsCount = int.Parse(Console.ReadLine());
                if (CheckNumber(colorsCount))
                {
                    user.favcolors = EnterColors(colorsCount);
                    break;
                }
                else
                    Console.WriteLine("Ошибка ввода. Повторите ввод.");
            }
            return user;
        }
        public static bool CheckNumber(int number)
        {
            return number > 0;
        }
        public static string[] EnterPets(int countPets)
        {
            string[] pets = new string[countPets];
            for(int i = 0; i < countPets; i++)
            {
                Console.WriteLine($"Введите кличку питомца №{i + 1}: ");
                pets[i] = Console.ReadLine();
            }
            return pets;
        }
        public static string[] EnterColors(int colorsCount)
        {
            string[] colors = new string[colorsCount];
            for (int i = 0; i < colorsCount; i++)
            {
                Console.WriteLine($"Введите любимый цвет №{i + 1}: ");
                colors[i] = Console.ReadLine();
            }
            return colors;
        }
        public static void PrintUser((string fname, string lname, int age, string[] pets, string[] favcolors) user)
        {
            Console.WriteLine($"Имя: {user.fname}");
            Console.WriteLine($"Фамилия: {user.lname}");
            Console.WriteLine($"Возраст: {user.age}");
            if (user.pets.Length > 0)
            {
                Console.WriteLine($"Количество питомцев: {user.pets.Length}");
                foreach (string pet in user.pets)
                {
                    Console.WriteLine($"У {user.fname} есть питомец \"{pet}\".");
                }
            }
            else
                Console.WriteLine($"У {user.fname} нет питомцев.");
            foreach(string color in user.favcolors)
            {
                Console.WriteLine($"{user.fname} нравится {color} цвет.");
            }
        }
        static void Main(string[] args)
        {
            var user = CreateUser();
            PrintUser(user);
            Console.ReadKey();
        }
    }
}
