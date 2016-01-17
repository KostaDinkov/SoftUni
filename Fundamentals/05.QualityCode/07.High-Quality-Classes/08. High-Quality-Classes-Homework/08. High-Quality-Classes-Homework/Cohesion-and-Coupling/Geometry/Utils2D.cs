namespace CohesionAndCoupling.Geometry
{
    using System;

    internal class Utils2D
    {
        public static double CalcDistance2D(double x1, double y1, double x2, double y2)
        {
            var distance = Math.Sqrt((x2 - x1)*(x2 - x1) + (y2 - y1)*(y2 - y1));
            return distance;
        }
    }
}