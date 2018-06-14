namespace _03.CirclesIntersection
{
    using System;
    using System.Linq;

    internal class CircleIntersection
    {
        private static void Main()
        {
            var first = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            var second = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            var firstCircle = new Circle {Center = new Point {X = first[0], Y = first[1]}, Radius = first[2]};
            var secondCircle = new Circle {Center = new Point {X = second[0], Y = second[1]}, Radius = second[2]};

            Console.WriteLine(firstCircle.Intersetcs(secondCircle) ? "Yes" : "No");
        }
    }

    internal class Circle
    {
        public Point Center { get; set;}
        public int Radius { get; set;}

        public bool Intersetcs(Circle other)
        {
            double sideA = Math.Abs(this.Center.X - other.Center.X);
            double sideB = Math.Abs(this.Center.Y - other.Center.Y);
            var dist = Math.Sqrt(Math.Pow(sideA, 2) + Math.Pow(sideB, 2));
            return dist <= this.Radius + other.Radius;
        }
    }

    internal class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}