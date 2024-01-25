using FoodShortage.Interfaces;
using FoodShortage.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage.Core
{
    public class Engine
    {
        private List<IResident> repository;

        public  Engine()
        {
            repository = new List<IResident>();
        }

        public void Run()
        {
            AddResidental();
            BuyFood();
            FoodSum();
        }

        private void FoodSum() => Console.WriteLine(this.repository.Sum(x => x.Food));

        private void BuyFood()
        {
            string name = Console.ReadLine();

            while (name != "End")
            {
                IResident resident = repository.FirstOrDefault(x => x.Name == name);

                if (resident is null)
                {
                    name = Console.ReadLine();
                    continue;
                }

                resident.BuyFood();
                name = Console.ReadLine();
            }
        }

        private void AddResidental()
        {
            int N = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < N; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ');
                RableOrCitizen(tokens);
            }
        }

        private void RableOrCitizen(string[] tokens)
        {
            IResident resident = tokens.Length switch
            {
                4 => new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2], tokens[3]),
                _ => new Rable(tokens[0], int.Parse(tokens[1]), tokens[2])
            };

            this.repository.Add(resident);
        }
    }
}
