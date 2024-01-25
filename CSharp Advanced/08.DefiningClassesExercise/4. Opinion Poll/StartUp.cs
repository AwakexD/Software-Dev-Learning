using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = ReadList();

            Action<IEnumerable<Person>> printer = (list) =>
            { 
                foreach (Person item in list.Where(x => x.Age > 30).OrderBy(x => x.Name))
                {
                    Console.WriteLine(item.Info);
                }
            };

            printer(people);
        }
        static List<Person> ReadList()
        {
            List<Person> people = new List<Person>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();
                people.Add(new Person(data[0], int.Parse(data[1])));

            }

            return people;
        }
    }
}
