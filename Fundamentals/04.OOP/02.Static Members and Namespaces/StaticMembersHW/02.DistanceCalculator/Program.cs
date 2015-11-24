/*
** SoftUni
** Course:		OOP
** Lecture:		Static Members and Namespaces
** Problem:		2.Distance Calculator
** Description:	Write a static class DistanceCalculator with a static 
**              method to calculate the distance between two points in the 3D space. 
**              Search in Internet how to calculate distance in the 3D Euclidian space.
** 	
** Date:		Thursday 11.2015 20:02 
*/
using System;
using static _02.DistanceCalculator.DistanceCalculator;

namespace _02.DistanceCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Point3D pointA = new Point3D(5, 3, 3.4);
            Point3D pointB = new Point3D(1, 2.4, 4.4);
            double distanceAB = CalculateDistance(pointA, pointB);
            Console.WriteLine($"Distance between A and B is : {distanceAB}");
        }
    }
}
