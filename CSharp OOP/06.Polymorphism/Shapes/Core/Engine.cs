using System;
using System.Collections.Generic;
using Shapes.Models;
using Shapes.Contracts;

namespace Shapes.Core
{
    public class Engine : IEngine
    {
        public Engine()
        {

        }

        public void Run()
        {
            Shape shape = new Rectangle(3, 5);

            Console.WriteLine(shape.CalculatePerimeter());
            Console.WriteLine(shape.CalculateArea());
            Console.WriteLine(shape.Draw());
        }
    }
}
