using System;

namespace CarManufacturer
{
    class StartUp
    {
        public static void Main(string[] args)
        {
            Car car = new Car();

            car.Make = "VW";
            car.Model = "MK3";
            car.Year = 1992;
            car.FuleQuantity = 200;
            car.FuleConsumption = 200;
            car.Drive(2000);

            Console.WriteLine(car.WhoAmI());
        }
    }
}
