using System;
using System.Collections.Generic;

namespace BoxOfT
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<int> box = new Box<int>();
            box.Add(1);
            box.Add(2);
            box.Add(3);
            Console.WriteLine(box.Remove());
            box.Add(4);
            box.Add(5);
            Console.WriteLine(box.Remove());
        }
    }
    public class Box<T>
    {
        public List<T> Items = new List<T>();
        
        public void Add(T item)
        {
            Items.Add(item);
        }

        public T Remove()
        {
            T item = Items[Items.Count - 1];
            Items.RemoveAt(Items.Count - 1);
            return item;
        }

        public int Count
        {
            get
            {
                return Items.Count;
            }
        }
    }
}
