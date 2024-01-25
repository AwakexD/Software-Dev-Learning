using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class Car
    { 
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;

        public string Make { get { return make; } set { make = value; } }
        public string Model { get { return model; } set { model = value; } }
        public int Year { get { return year; } set { year = value; } }
        public double  FuleQuantity { get { return fuelQuantity; } set { fuelQuantity = value; } }
        public double FuleConsumption { get { return fuelConsumption; } set { fuelConsumption = value; } }

        public void Drive(double distance)
        {
            if (fuelQuantity - distance * fuelConsumption > 0)
            {
                fuelQuantity -= distance * fuelConsumption; 
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            return $"Make:{this.Make}\nModel:{this.model}\nYear:{this.year}\nFuel:{this.fuelQuantity:f2}";
        }
    }
}
