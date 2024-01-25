namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        private const double defaultConsumption = 8;

        public override double FuelConsumption { get => base.FuelConsumption; set => base.FuelConsumption = value; }

        public RaceMotorcycle(int hp, int fuel) : base(hp, fuel) 
        {
            this.FuelConsumption = defaultConsumption;
        }
    }
}
