//---------------------------------------------------
// SoftUni
// Course:      OOP
// Lecture:     Encapsulation And Polymorphysm
// Problem:     1.Shapes
// Description: •	Define an interface IShape with two abstract methods: 
//                  CalculateArea() and CalculatePerimeter().
//              •	Define an abstract class BasicShape implementing IShape and holding 
//                  width and height.Leave the methods CalculateArea() and CalculatePerimeter() abstract.
//              •	Define two new BasicShape subclasses: Rhombus and Rectangle that implement the abstract 
//                  methods CalculateArea() and CalculatePerimeter().
//              •	Define a class Circle implementing IShape with a suitable constructor.
//              •	Create an array of different shapes (Circle, Rectangle, Rhombus) and test the 
//                  behavior of the CalculateSurface() and CalculatePerimeter() methods.
// Date:        Saturday 11.2015 20:51 
//---------------------------------------------------

using System;

namespace _1.Shapes
{
    internal class Program
    {
        private static void Main()
        {
            var shapes = new IShape[]
            {
                new Circle(5),
                new Rectangle(10, 32),
                new Rhombus(12, 5)
            };
            foreach (var shape in shapes)
            {
                Console.WriteLine($"Shape of type {shape.GetType()}\n" +
                                  $"\tArea:{shape.CalculateArea()}\n" +
                                  $"\tPerimeter:{shape.CalculatePerimeter()}");
            }
        }
    }
}