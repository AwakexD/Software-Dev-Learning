using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumptionPerKm)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        }

        public double FuelQuantity { get; set; }
        
        public virtual double FuelConsumptionPerKm{ get; set; }

        public void Drive(double distance)
        {
            if (this.FuelQuantity - (distance * FuelConsumptionPerKm) >= 0)
            {
                this.FuelQuantity -= (distance * FuelConsumptionPerKm);
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }

        public virtual void Refule(double amount) => FuelQuantity += amount;
       
    }
}
