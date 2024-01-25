namespace NeedForSpeed
{
    public class SportCar : Car
    {
        private const double defaultConsumption = 10;

        public SportCar(int hp, int fuel ) : base(hp, fuel)
        {
            base.FuelConsumption = defaultConsumption;
        }
    }
}
