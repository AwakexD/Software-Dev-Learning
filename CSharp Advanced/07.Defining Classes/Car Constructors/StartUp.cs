using System;

namespace CarManufacturer
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string model = Console.ReadLine();
            string make = Console.ReadLine();
            int year = int.Parse(Console.ReadLine());
            double fuelQuantity = double.Parse(Console.ReadLine());
            double fuelConsumption = double.Parse(Console.ReadLine());

            Car car1 = new Car();
            Car car2 = new Car(make, model, year);
            Car car3 = new Car(make, model, year, fuelQuantity, fuelConsumption);
        }
    }
}
