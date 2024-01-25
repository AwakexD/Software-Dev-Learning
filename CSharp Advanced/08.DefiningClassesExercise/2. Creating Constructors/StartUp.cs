using System;

namespace DefiningClasses
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            Person person1 = new Person("gosho" , 20);
            Console.WriteLine(person1.Info);

        }
    }
}
