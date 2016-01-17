namespace CohesionAndCoupling.Geometry
{
    using System;

    internal class Cuboid
    {
        public Cuboid(double width, double height, double depth)
        {
            if (width <= 0 ||
                height <= 0 ||
                depth <= 0)
            {
                throw new ArgumentException("Values for width, height and depth must be greater than zero.");
            }
            this.Height = height;
            this.Width = width;
            this.Depth = width;
        }

        public double Width { get; set; }
        public double Height { get; set; }
        public double Depth { get; set; }

        public double CalcVolume()
        {
            var volume = this.Width*this.Height*this.Depth;
            return volume;
        }

        public double CalcDiagonalXYZ()
        {
            var distance = Utils3D.CalcDistance3D(0, 0, 0, this.Width, this.Height, this.Depth);
            return distance;
        }

        public double CalcDiagonalXY()
        {
            var distance = Utils2D.CalcDistance2D(0, 0, this.Width, this.Height);
            return distance;
        }

        public double CalcDiagonalXZ()
        {
            var distance = Utils2D.CalcDistance2D(0, 0, this.Width, this.Depth);
            return distance;
        }

        public double CalcDiagonalYZ()
        {
            var distance = Utils2D.CalcDistance2D(0, 0, this.Height, this.Depth);
            return distance;
        }
    }
}