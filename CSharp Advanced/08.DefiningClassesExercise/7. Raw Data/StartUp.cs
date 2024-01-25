using System;
using System.Linq;
using System.Collections.Generic;

namespace _7._Raw_Data
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < N; i++)
            {
                string[] data = Console.ReadLine().Split();
                cars.Add(CreateCar(data));
            }

            string type = Console.ReadLine();
            Print(type, cars);
        }
        static Car CreateCar(string[] data)
        {
            string model = data[0];
            double engineSpeed = double.Parse(data[1]);
            int enginePower = int.Parse(data[2]);
            double cargoWeight = double.Parse(data[3]);
            string cargoType = data[4];

            double tire1Pressure = double.Parse(data[5]);
            int tire1Age = int.Parse(data[6]);
            double tire2Pressure = double.Parse(data[7]);
            int tire2Age = int.Parse(data[8]);
            double tire3Pressure = double.Parse(data[9]);
            int tire3Age = int.Parse(data[10]);
            double tire4Pressure = double.Parse(data[11]);
            int tire4Age = int.Parse(data[12]);

            Engine engine = new Engine(engineSpeed, enginePower);

            Cargo cargo = new Cargo(cargoType, cargoWeight);

            Tire[] tires =
            {
                new Tire(tire1Age, tire1Pressure),
                new Tire(tire2Age, tire2Pressure),
                new Tire(tire3Age, tire3Pressure),
                new Tire(tire4Age, tire4Pressure)
            };

            return new Car(model, engine, cargo, tires);
        }

        static void Print(string type, List<Car> cars)
        {
            List<Car> result = new List<Car>();

            if (type == "fragile")
            {
                result = cars.Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(p => p.Pressure < 1)).ToList();
            }
            else if (type == "flammable")
            {
                result = cars.Where(x => x.Cargo.Type == "flammable" && x.Engine.Power > 250).ToList();
            }

            foreach (Car car in result)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
