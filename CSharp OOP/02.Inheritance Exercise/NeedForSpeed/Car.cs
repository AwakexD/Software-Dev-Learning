namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        private const double defaultConsumption = 3;

        public override double FuelConsumption { get => base.FuelConsumption; set => base.FuelConsumption = value; }

        public Car(int hp, int fuel) : base(hp, fuel)
        {
            this.FuelConsumption = defaultConsumption;
        }
    }
}
