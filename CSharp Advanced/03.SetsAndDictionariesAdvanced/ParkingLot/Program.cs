using System;
using System.Linq;
using System.Collections.Generic;

namespace ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            HashSet<string> parking = new HashSet<string>();

            while(command != "END")
            {
                string[] data = command.Split(", ");

                if (data[0] == "IN")
                {
                    parking.Add(data[1]);
                }
                else
                {
                    parking.Remove(data[1]);
                }

                command = Console.ReadLine();   
            }

            Console.WriteLine(String.Join('\n', parking));
        }
    }
}
