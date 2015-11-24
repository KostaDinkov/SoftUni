/*
** SoftUni
** Course:      OOP
** Lecture:     Static Members and Namespaces
** Problem:     1.Point 3D
** Description: Create a class Point3D to hold a 3D-coordinate {X, Y, Z} in the Euclidian 
**              3D space. Create appropriate constructors. Override ToString() to enable printing a 3D point.
**              Add a private static read-only field in the Point3D class to hold the start of the coordinate 
**              system – the point StartingPoint {0, 0, 0}. Add a static property to return the starting point.
** 	
** Date:        Thursday 11.2015 15:48 
*/

using System;

namespace _01.Point3D
{
    internal class Program
    {
        private static void Main()
        {
            Point3D pointA = new Point3D(5, 3, 3.4);
            Point3D pointB = new Point3D(1, 2.4, 4.4);

            Console.WriteLine(pointA.ToString());
            Console.WriteLine(pointB.ToString());

            Console.WriteLine("Starting point:" + Point3D.StartingPoint.ToString());
        }
    }
}