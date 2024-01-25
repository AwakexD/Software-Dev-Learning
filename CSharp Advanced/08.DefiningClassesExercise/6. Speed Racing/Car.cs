using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
        public Car(string model, double fa, double fcpk)
        {
            this.Model = model;
            this.FuelAmount = fa;
            this.FuelConsumPerKm = fcpk;
            this.TravelledDistance = 0;
        }
        
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumPerKm { get; set; }
        public double TravelledDistance { get; set; }

        public bool IsFuelEnough(double amountOfKm)
        {
            if (FuelConsumPerKm * amountOfKm <= FuelAmount)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"{this.Model} {this.FuelAmount:f2} {this.TravelledDistance}";
        }
    }
}
