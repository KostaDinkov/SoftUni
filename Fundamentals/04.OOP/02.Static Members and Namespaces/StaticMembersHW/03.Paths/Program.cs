/*
** SoftUni
** Course:		OOP
** Lecture:		Static Members and Namespaces
** Problem:		3.Paths
** Description:	Create a class Path3D to hold a sequence of points in 3D space. 
**              Create a static class Storage with static methods to save and load paths from a text file. 
**              Use a file format of your choice. Ensure you close correctly all files with the "using" statement.
** 	
** Date:		Thursday 11.2015 20:50 
*/
using System;

namespace _03.Paths
{
    internal class Program
    {
        private static void Main()
        {
            var pointA = new Point3D(5, 3, 3.4);
            var pointB = new Point3D(1, 2.4, 4.4);
            var path = new Path3D();
            path.Points.Add(pointA);
            path.Points.Add(pointB);

            //save the path to a file. 
            //Note that for debugging convenience the file path is set to the project root
            Storage.SavePath(path, "../../myPath.path");

            //load a path from file
            var loadedPath = Storage.LoadPath("../../myPath.path");

            //print the loaded path
            var counter = 1;
            foreach (var point in loadedPath.Points)
            {
                Console.WriteLine($"Point #{counter}: {point.X}, {point.Y}, {point.Z}");
                counter++;
            }
        }
    }
}