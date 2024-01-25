using System;
using System.Collections.Generic;
using System.Text;

namespace _7._Raw_Data
{
    public class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tire[] Tires { get; set; }

        public Car()
        {
            this.Engine = new Engine();
            this.Cargo = new Cargo();
            this.Tires = new Tire[4];
        }

        public Car(string model, Engine engine, Cargo cargo, Tire[] tires) : this()
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tires = tires;
        }
    }
}
