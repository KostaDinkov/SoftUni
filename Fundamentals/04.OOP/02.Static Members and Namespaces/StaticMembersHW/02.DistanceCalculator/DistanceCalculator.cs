using static System.Math;

namespace _02.DistanceCalculator
{
    static class DistanceCalculator
    {
        public static double CalculateDistance(Point3D pointA, Point3D pointB)
        {
            return Sqrt(
                Pow((pointA.X - pointB.X), 2) +
                Pow((pointA.Y - pointB.Y), 2) +
                Pow((pointA.Z - pointB.Z), 2));
        }
    }
}
