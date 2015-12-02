namespace _1.Shapes
{
    public abstract class BasicShape : IShape
    {
        public BasicShape(double width, double heigth)
        {
            this.Width = width;
            this.Height = heigth;
        }

        public double Width { get; set; }
        public double Height { get; set; }
        public abstract double CalculateArea();
        public abstract double CalculatePerimeter();
    }
}