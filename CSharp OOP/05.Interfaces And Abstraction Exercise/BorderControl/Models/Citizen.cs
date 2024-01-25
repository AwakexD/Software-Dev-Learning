using System;
using System.Collections.Generic;
using System.Text;
using BorderControl.Interfaces;

namespace BorderControl.Models
{
    public class Citizen : IIdentifier , IHuman
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Citizen(string name, int age, string Id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = Id;
        }
    }
}
