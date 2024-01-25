using System;
using System.Collections.Generic;
using System.Text;
using FoodShortage.Interfaces;

namespace FoodShortage.Models
{
    public class Rable : IResident
    {
        public int Food { get; private set; }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Group { get; private set; }

        public Rable(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
            Food = 0;
        }

        public void BuyFood()
        {
            Food += 5;
        }
    }
}
