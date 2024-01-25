using System;
using System.Linq;
using System.Collections.Generic;

namespace CitiesContinentCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> world = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < N; i++) //Europe Bulgaria Sofia 
            {
                string[] data = Console.ReadLine().Split();
                string continent = data[0];
                string country = data[1];
                string city = data[2];

                if (!world.ContainsKey(data[0]))
                {
                    world.Add(continent, new Dictionary<string, List<string>>());
                }
                if (!world[continent].ContainsKey(country))
                {
                    world[continent].Add(country, new List<string>());
                }

                world[continent][country].Add(city);
            }

            Print(world);
        }
        static void Print(Dictionary<string, Dictionary<string, List<string>>> world)
        {
            foreach (var continent in world)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"  {country.Key} -> {string.Join(", ", world[continent.Key][country.Key])}");
                }
            }
        }
        
    }
    
}
