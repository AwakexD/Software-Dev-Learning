using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    class Family
    {
        private List<Person> people;

        public Family()
        {
            people = new List<Person>();
        }

        public void AddMember(Person person)
        {
            people.Add(person);
        }
        public void GetOldestMember()
        {
            Person oldestPerson = people.Find(m => m.Age == this.people.Max(x => x.Age));

            Console.WriteLine(oldestPerson.Info);
        }
    }
}
