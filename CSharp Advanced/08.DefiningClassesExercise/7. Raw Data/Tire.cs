﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _7._Raw_Data
{
    public class Tire
    {
        public int Age { get; set; }
        public double Pressure { get; set; }

        public Tire()
        {

        }

        public Tire(int age, double pressure) : this()
        {
            this.Age = age;
            this.Pressure = pressure;
        }
    }
}
