using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BorderControl.Interfaces;
using BorderControl.Models;

namespace BorderControl.Core
{
    public class Engine
    {
        private List<IIdentifier> repository;

        public Engine()
        {
            repository = new List<IIdentifier>();
        }
         
        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] data = command.Split(' ');
                AddIdentifiable(data);
                command = Console.ReadLine();
            }

            string fakeIdEnd = Console.ReadLine();
            string[] fakeIds = this.repository.Where(i => i.Id.EndsWith(fakeIdEnd)).Select(x => x.Id).ToArray();

            PrintFakeId(fakeIds);
        }

        private void PrintFakeId(string[] fakeIds)
        {
            Console.WriteLine(string.Join(Environment.NewLine, fakeIds));
        }

        private void AddIdentifiable(string[] data)
        {
            IIdentifier identifiable;
            if (data.Length == 3)
            {
                identifiable = new Citizen(data[0], int.Parse(data[1]), data[2]);
            }
            else
            {
                identifiable = new Robot(data[0], data[1]);
            }

            this.repository.Add(identifiable);
        }
    }
}
