using Animals.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Animals.Core
{
    public class Engine
    {
        public Engine()
        {

        }

        public void Run()
        {
            Animal cat = new Cat("Peter", "Whiskas");
            Animal dog = new Dog("George", "Meat");

            Console.WriteLine(cat.ExplainSelf());
            Console.WriteLine(dog.ExplainSelf());

        }
    }
}
