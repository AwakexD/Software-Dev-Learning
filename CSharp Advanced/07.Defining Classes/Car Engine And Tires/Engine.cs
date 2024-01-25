using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class Engine
    {
        private int horsepower;
        private double cubicCapacity;

        public int HorsePower { get { return horsepower; } set { horsepower = value;} }
        public double CubicCapacity { get { return cubicCapacity; } set { cubicCapacity = value; } }

        public Engine(int hp, double cc)
        {
            this.HorsePower = hp;
            this.CubicCapacity = cc;
        }
    }
}
