using System;
using System.Collections.Generic;
using System.Text;

namespace _7._Raw_Data
{
    public class Cargo
    {
        public string Type { get; set; }
        public double Weight { get; set; }

        public Cargo()
        {

        }

        public Cargo(string type, double weight) : this()
        {
            this.Type = type;
            this.Weight = weight;
        }
    }
}
