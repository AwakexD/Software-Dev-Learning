using System;
using Vehicles.Contracts;
using Vehicles.Models;

namespace Vehicles.Core
{
    public class Engine : IEngine
    {
        private Vehicle car;
        private Vehicle truck;

        public Engine()
        {
            
        }

        public void Run()
        {
            InitializeVehicles();
            ExecuteCommands(car, truck);
            Console.WriteLine(RemainingFuel);
        }

        private void InitializeVehicles()
        {
            string[] carData = Console.ReadLine().Split();
            string[] truckData = Console.ReadLine().Split();

            car = new Car(double.Parse(carData[1]), double.Parse(carData[2]));
            truck = new Truck(double.Parse(truckData[1]), double.Parse(truckData[2]));
        }

        private string RemainingFuel => $"Car: {car.FuelQuantity:f2}\nTruck: {truck.FuelQuantity:f2}";


        private void ExecuteCommands(Vehicle car, Vehicle truck)
        {
            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                string[] line = Console.ReadLine().Split();

                string action = line[0];
                string vehicle = line[1];
                double amount = double.Parse(line[2]);

                if (action == "Drive")
                {
                    if (vehicle == "Car")
                    {
                        car.Drive(amount);
                    }
                    else 
                    {
                        truck.Drive(amount);
                    }
                }
                else
                {
                    if (vehicle == "Car")
                    {
                        car.Refule(amount);
                    }
                    else
                    {
                        truck.Refule(amount);
                    }
                }

            }
        }
    }
}
