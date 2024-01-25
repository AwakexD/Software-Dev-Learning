using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        public List<Car> cars { get; set; }
        public int Capacity { get; set; }

        public int Count
        {
            get{ return cars.Count; }
        }

        public Parking(int capacity)
        {
            cars = new List<Car>();
            this.Capacity = capacity;
        }

        public string AddCar(Car car)
        {
            if (cars.Any(x => x.RegistrationNumber == car.RegistrationNumber))
            {
                return ("Car with that registration number, already exists!");
            }
            else if (cars.Count + 1 > Capacity)
            {
                return("Parking is full!");
            }
            else
            {
                cars.Add(car);
                return ($"Successfully added new car {car.Make} {car.RegistrationNumber}");
            }

        }
        public Car GetCar(string registratioNumber)
        {
            return cars.FirstOrDefault(x => x.RegistrationNumber == registratioNumber);
        }

        public string RemoveCar(string RegistrationNumber)
        {
            if (cars.Any(x => x.RegistrationNumber == RegistrationNumber))
            {
                Car carToRemove = GetCar(RegistrationNumber);

                cars.Remove(carToRemove);

                return ($"Succesfully removed {carToRemove.RegistrationNumber}");
            }
            else
            {
                return ("Car with that registration number, doesn't exist!");
            }

        }

        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            foreach (string regNumber in RegistrationNumbers)
            {
                if (cars.Any(x => x.RegistrationNumber == regNumber))
                {
                    Car carToRemove = GetCar(regNumber);
                    cars.Remove(carToRemove);
                }

            }
        }
    }
}
