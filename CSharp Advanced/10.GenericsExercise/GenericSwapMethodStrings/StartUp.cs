using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Box<string>> list = AddBoxes();
            list = Swap<string>(list);
            Print(list);

        }
        public static List<Box<string>> AddBoxes()
        {
            int N = int.Parse(Console.ReadLine());
            List<Box<string>> list = new List<Box<string>>();

            for (int i = 0; i < N; i++)
            {
                list.Add(new Box<string>(Console.ReadLine()));
            }

            return list;
        }
        public static List<Box<string>> Swap<T>(List<Box<string>> list)
        {
            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var temp = list[indexes[0]];
            list[indexes[0]] = list[indexes[1]];
            list[indexes[1]] = temp;

            return list;
        }

        public static void Print(List<Box<string>> list) => list.ForEach(x => Console.WriteLine(x.ToString()));

    }
    public class Box<T>
    {
        private T value;

        public Box(T item)
        {
            this.value = item;
        }

        public override string ToString()
        {
            return $"{value.GetType()}: {value}";
        }
    }
}
