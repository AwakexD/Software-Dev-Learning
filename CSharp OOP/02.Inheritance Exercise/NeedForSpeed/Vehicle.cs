using System;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double defaultConsumption = 1.25;
        private double fuelConsumption;

        private int HoursePower { get; set; }
        private double Fuel { get; set; }

        public double DefaultFuelConsumption = defaultConsumption;

        public virtual double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }

        public Vehicle(int hoursePower, int fuel)
        {
            this.HoursePower = hoursePower;
            this.Fuel = fuel;
        }

        public virtual void Drive(double kilometers)
        {
            Fuel -= kilometers * fuelConsumption;
        }
    }
}
