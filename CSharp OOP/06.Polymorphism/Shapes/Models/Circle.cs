using System;
using System.Collections.Generic;
using System.Text;
using Shapes.Contracts;

namespace Shapes.Models
{
    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public override double CalculateArea()
        {
            const double Pi = Math.PI;
            return Pi * Math.Pow(radius, 2);
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * radius;
        }

        public override string Draw()
        {
            return base.Draw() + GetType().Name;
        }
    }
}
