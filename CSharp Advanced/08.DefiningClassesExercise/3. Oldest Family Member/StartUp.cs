using System;

namespace DefiningClasses
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            Family family = new Family();

            int N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                string[] data = Console.ReadLine().Split();
                family.AddMember(new Person(data[0], int.Parse(data[1])));
            }

            family.GetOldestMember();
        }
    }
}
