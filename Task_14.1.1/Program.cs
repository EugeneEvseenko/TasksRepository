using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_14._1._1
{
    internal class Program
    {
        public class City
        {
            public City(string name, long population)
            {
                Name = name;
                Population = population;
            }

            public string Name { get; set; }
            public long Population { get; set; }
            public override string ToString()
            {
                return $"Город {Name}. Население: {Population}";
            }
        }
        static void Main(string[] args)
        {
            var russianCities = new List<City>();
            russianCities.Add(new City("Москва", 11900000));
            russianCities.Add(new City("Санкт-Петербург", 4991000));
            russianCities.Add(new City("Волгоград", 1099000));
            russianCities.Add(new City("Казань", 1169000));
            russianCities.Add(new City("Севастополь", 449138));

            var cities = russianCities
                .Where(x => x.Name.Length <= 10)
                .OrderBy(x => x.Name.Length);

            foreach (var city in cities) 
                Console.WriteLine(city.ToString());

            Console.ReadKey();
        }
    }
}
