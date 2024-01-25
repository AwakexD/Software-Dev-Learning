using System;

namespace GenericBoxOfString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                string str = Console.ReadLine();
                Box<string> box = new Box<string>(str);

                Console.WriteLine(box.ToString());
            }

        }
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
