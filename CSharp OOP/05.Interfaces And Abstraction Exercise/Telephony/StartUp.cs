using System;
using Telephony.Interfaces;
using System.Collections.Generic;
using Telephony.Models;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IBrowsable smartphone = new Smartphone();
            ICallable stationaryPhone = new StationaryPhone();

            string[] phoneNumbers = Console.ReadLine().Split();
            string[] websites = Console.ReadLine().Split();

            foreach (string item in phoneNumbers)
            {
                try
                {
                    if (item.Length == 7)
                    {
                        Console.WriteLine(stationaryPhone.Call(item));
                    }
                    else if(item.Length == 10)
                    {
                        Console.WriteLine(smartphone.Call(item));
                    }

                }
                catch (Exception)
                {

                    Console.WriteLine("Invalid number!");
                }
            }

            foreach (string url in websites)
            {
                try
                {
                    Console.WriteLine(smartphone.Browse(url));
                }
                catch (Exception)
                {

                    Console.WriteLine("Invalid URL!");
                }
            }
        }
    }
}
