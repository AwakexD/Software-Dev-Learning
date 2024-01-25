using System;
using System.Linq;
using System.Collections.Generic;

namespace SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = AddCars();

            Drive(cars);

            printer(cars);
        }
        static Action<List<Car>> printer = list => list.ForEach(x => Console.WriteLine(x));

        static List<Car> AddCars()
        {
            int numberOfCars = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] data = Console.ReadLine().Split(' ');
                string model = data[0];
                double fuelAmount = double.Parse(data[1]);
                double fuelConsumption = double.Parse(data[2]);

                cars.Add(new Car(model, fuelAmount, fuelConsumption));
            }

            return cars;
        }
        static void Drive(List<Car> cars)
        {
            string comamnd = Console.ReadLine();

            while (comamnd != "End")
            {
                string[] data = comamnd.Split();

                string model = data[1];
                double amountOfKm = double.Parse(data[2]);

                Car currentCar = cars.Find(x => x.Model == model);

                if (currentCar.IsFuelEnough(amountOfKm))
                {
                    currentCar.FuelAmount -= amountOfKm * currentCar.FuelConsumPerKm;

                    currentCar.TravelledDistance += amountOfKm;
                }
                else
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }

                comamnd = Console.ReadLine();
            }
        }
    }
}
