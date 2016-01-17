namespace Abstraction
{
    using System;

    internal class Rectangle : Figure
    {
        private double height;
        private double width;

        public Rectangle(double width, double height)

        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get { return this.width; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Width cannot be less than, or equal to zero.");
                }
                this.width = value;
            } 
        }
        public double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be less than, or equal to zero.");
                }
                this.height = value;
            } 
        }

        public override double CalcPerimeter()
        {
            var perimeter = 2*(this.Width + this.Height);
            return perimeter;
        }

        public override double CalcSurface()
        {
            var surface = this.Width*this.Height;
            return surface;
        }
    }
}