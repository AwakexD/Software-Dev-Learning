using System;
using System.Collections.Generic;

namespace Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split(" -> "); // Blue -> dress,jeans,hat
                string[] clothes = line[1].Split(',');

                string color = line[0];

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                if(wardrobe.ContainsKey(color))
                {
                    foreach (string item in clothes)
                    {
                        if (!wardrobe[color].ContainsKey(item))
                        {
                            wardrobe[color].Add(item, 0);
                        }

                        wardrobe[color][item]++;
                    }
                }
            }

            string clothToFind = Console.ReadLine();
            FindAndPrint(wardrobe, clothToFind);
        }
        static void FindAndPrint(Dictionary<string, Dictionary<string, int>> wardrobe, string input)
        {
            string color = input.Split()[0];
            string cloth = input.Split()[1];

            foreach (var clr in wardrobe)
            {
                Console.WriteLine($"{clr.Key} clothes: ");
                foreach (var item in wardrobe[clr.Key])
                {
                    if (clr.Key == color && item.Key == cloth)
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }
                }
            }
        }
    }
}
