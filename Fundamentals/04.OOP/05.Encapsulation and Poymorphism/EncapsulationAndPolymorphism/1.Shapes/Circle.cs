using System;

namespace _1.Shapes
{
    public class Circle : IShape
    {
        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius { get; set; }

        public double CalculateArea()
        {
            return this.Radius*this.Radius*Math.PI;
        }

        public double CalculatePerimeter()
        {
            return 2*Math.PI*this.Radius;
        }
    }
}