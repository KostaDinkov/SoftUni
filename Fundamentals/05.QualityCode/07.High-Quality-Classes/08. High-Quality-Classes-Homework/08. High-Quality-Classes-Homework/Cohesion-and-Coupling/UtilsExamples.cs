﻿namespace CohesionAndCoupling
{
    using System;
    using Geometry;

    internal class UtilsExamples
    {
        private static void Main()
        {
            Console.WriteLine(FileUtils.GetFileExtension("example"));
            Console.WriteLine(FileUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}",
                Utils2D.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}",
                Utils3D.CalcDistance3D(5, 2, -1, 3, -6, 4));

            var cuboid = new Cuboid(3, 4, 5);

            Console.WriteLine("Volume = {0:f2}", cuboid.CalcVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", cuboid.CalcDiagonalXYZ());
            Console.WriteLine("Diagonal XY = {0:f2}", cuboid.CalcDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", cuboid.CalcDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", cuboid.CalcDiagonalYZ());
        }
    }
}