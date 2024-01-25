using System;
using System.Collections.Generic;
using System.Text;

namespace _7._Raw_Data
{
    public class Engine
    {
        public double Speed { get; set; }
        public int Power { get; set; }

        public Engine()
        {

        }

        public Engine(double speed, int power) : this()
        {
            this.Speed = speed;
            this.Power = power;
        }
    }
}
