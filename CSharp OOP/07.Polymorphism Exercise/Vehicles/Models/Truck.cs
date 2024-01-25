using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumptionPerKm) : base(fuelQuantity, fuelConsumptionPerKm)
        {

        }

        public override double FuelConsumptionPerKm => base.FuelConsumptionPerKm + 1.6;

        public override void Refule(double amount)
        {
            base.Refule(amount * 0.95);
        }
    }
}
