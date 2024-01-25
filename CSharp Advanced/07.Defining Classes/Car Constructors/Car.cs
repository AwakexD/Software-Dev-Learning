using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class Car
    {

        public Car()
        {
            Make = "VW";
            Model = "Gold";
            Year = 2025;
            FuelQuantity = 200;
            FuelConsumption = 10;
        }

        public Car(string make, string model, int year) : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public Car(string make, string model, int year, double fuelQ, double fuelC) : this(make, model, year)
        {
            this.FuelQuantity = fuelQ;
            this.FuelConsumption = fuelC;
        }

        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double  FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }


        public string WhoAmI()
        {
            return $"Make:{this.Make}\nModel:{this.Model}\nYear:{this.Year}\nFuel:{this.FuelQuantity:f2}";
        }
    }
}
