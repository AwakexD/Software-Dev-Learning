using System;
using System.Collections.Generic;
using System.Text;
using FoodShortage.Interfaces;

namespace FoodShortage.Models
{
    public class Citizen : IResident
    {
        public int Food { get; private set; }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string ID { get; private set; }

        public string Birthdate { get; private set; }

        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            ID = id;
            Birthdate = birthdate;
            Food = 0;
        }

        public void BuyFood()
        {
            Food += 10;
        }
    }
}
