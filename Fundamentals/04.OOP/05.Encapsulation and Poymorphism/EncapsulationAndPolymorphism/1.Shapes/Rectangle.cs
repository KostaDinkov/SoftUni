namespace _1.Shapes
{
    public class Rectangle : BasicShape
    {
        public Rectangle(double width, double heigth) : base(width, heigth)
        {
        }

        public override double CalculateArea()
        {
            return this.Width*this.Height;
        }

        public override double CalculatePerimeter()
        {
            return (2*this.Width + 2*this.Height);
        }
    }
}