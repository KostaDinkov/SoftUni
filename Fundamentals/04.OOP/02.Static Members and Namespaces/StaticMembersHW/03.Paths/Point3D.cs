namespace _03.Paths
{
    internal class Point3D
    {
        public Point3D()
        {
        }

        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString()
        {
            return $"{X}, {Y}, {Z}";
        }

        public static Point3D StartingPoint { get; } = new Point3D(0, 0, 0);
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }
}