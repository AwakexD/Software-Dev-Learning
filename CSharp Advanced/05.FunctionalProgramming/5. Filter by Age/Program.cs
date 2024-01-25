using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Filter_by_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            List<Person> peoples = new List<Person>();

            for (int i = 0; i < N; i++)
            {
                string[] data = Console.ReadLine().Split(", ");
                peoples.Add(new Person(data[0], int.Parse(data[1])));
            }

            string condition = Console.ReadLine();
            int ageCondition = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<Person, int, bool> filter = Filter(condition);
            Action<Person> printer = Printer(format);

            peoples = peoples.Where(x => filter(x, ageCondition)).ToList();
            peoples.ForEach(printer);
        }

        private static Action<Person> Printer(string format)
        {
            if (format == "name")
            {
                return (person) => Console.WriteLine(person.Name);
            }
            else if (format == "age")
            {
                return (person) => Console.WriteLine(person.Age);
            }
            else
            {
                return (person) => Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }

        private static Func<Person, int, bool> Filter(string condition)
        {
            if (condition == "older")
            {
                return (person, age) => person.Age >= age;
            }
            else if (condition == "younger")
            {
                return (person, age) => person.Age < age;   
            }

            return null;
        }
    }
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
