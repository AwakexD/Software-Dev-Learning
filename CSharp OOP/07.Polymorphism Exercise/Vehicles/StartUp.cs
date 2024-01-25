using System;
using Vehicles.Core;

namespace Vehicles
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
