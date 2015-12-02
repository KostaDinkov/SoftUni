namespace _1.Shapes
{
    public class Rhombus : BasicShape
    {
        public Rhombus(double width, double heigth) : base(width, heigth)
        {
        }

        public override double CalculateArea()
        {
            return this.Width*this.Height;
        }

        public override double CalculatePerimeter()
        {
            return this.Width*4;
        }
    }
}