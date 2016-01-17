using System;

namespace Methods
{
    internal class Methods
    {
        /// <summary>
        /// Calculates the area of a triangle in the case of 3 given sides
        /// </summary>
        /// <param name="sideA">The first side</param>
        /// <param name="sideB">The second side</param>
        /// <param name="sideC">The third side</param>
        /// <returns>The area of a triangle</returns>
        private static double CalculateTriangleArea(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                throw new ArgumentException("Val cannot be less or equal to zero");
            }

            if (sideA + sideB <= sideC ||
                sideB + sideC <= sideA ||
                sideC + sideA <= sideB)
            {
                throw new ArgumentException("The provided sides cannot form a triangle");
            }

            double halfPerimeter = (sideA + sideB + sideC)/2;
            double area =
                Math.Sqrt(halfPerimeter*(halfPerimeter - sideA)*(halfPerimeter - sideB)*(halfPerimeter - sideC));
            return area;
        }

        /// <summary>
        /// Convert a digit between 0 and 9 to its string representation
        /// </summary>
        /// <param name="digit">A digit between 0 and 9</param>
        /// <exception cref="ArgumentException">Thrown when the input is a number not in the range 0 - 9 inclusive</exception>
        /// <returns>String representation of the digit</returns>
        private static string DigitToString(int digit)
        {
            if (digit > 9 || digit < 0)
            {
                throw new ArgumentException("Number must be between 0 and 9");
            }

            switch (digit)
            {
                case 0:
                    return "zero";
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
            }

            return "Invalid number!";
        }

        /// <summary>
        /// Finds the maximum number in a collection of integers
        /// </summary>
        /// <param name="elements">Collection of integers.</param>
        /// <returns>The largest integer</returns>
        private static int FindMaxInt(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentNullException("The input array cannot be empty or nulll");
            }

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > elements[0])
                {
                    elements[0] = elements[i];
                }
            }
            return elements[0];
        }

        /// <summary>
        /// Tries to print a given object as a number using a given format specifier.
        /// </summary>
        /// <param name="number">Object to be represented as a number</param>
        /// <param name="format">Format specifier, use "f" for decimal representation, "%" for percentage representation, or "r" for right indentation</param>
        private static void PrintAsNumber(object number, string format)
        {
            if (!IsNumber(number))
            {
                throw new ArgumentException("The object cannot be represented as a number", number.ToString());
            }

            switch (format)
            {
                case ("f"):
                    Console.WriteLine("{0:f2}", number);
                    break;
                case ("%"):
                    Console.WriteLine("{0:p0}", number);
                    break;
                case ("r"):
                    Console.WriteLine("{0,8}", number);
                    break;
                default:
                    throw new ArgumentException("Unknown format specifier", format);
            }
        }

        /// <summary>
        /// Calculates the distance between two points in a Cartesian coordinate system.
        /// </summary>
        /// <param name="x1">The first point x coordinate.</param>
        /// <param name="y1">The first point y coordinate.</param>
        /// <param name="x2">The second point x coordinate.</param>
        /// <param name="y2">The second point y coordinate.</param>
        /// <returns></returns>
        private static double CalculateDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1)*(x2 - x1) + (y2 - y1)*(y2 - y1));
            return distance;
        }

        /// <summary>
        /// Checks if a line between two points in a Cartesian coordinate system is horizontal or vertical.
        /// </summary>
        /// <param name="x1">The first point x coordinate.</param>
        /// <param name="y1">The first point y coordinate.</param>
        /// <param name="x2">The second point x coordinate.</param>
        /// <param name="y2">The second point y coordinate.</param>
        /// <param name="isHorizontal">A boolean to store the result for the horizontal check.</param>
        /// <param name="isVertical">A boolean to store the result for the vertical check.</param>
        private static void IsHorisontalOrVertical(double x1, double y1, double x2, double y2,
            out bool isHorizontal, out bool isVertical)
        {
            isHorizontal = (y1 == y2);
            isVertical = (x1 == x2);
        }

        /// <summary>
        /// Checks if a given object is of a numerical data type.
        /// </summary>
        /// <param name="value">The object to be evaluated</param>
        /// <returns>True if value is numeric data type, False otherwise.</returns>
        private static bool IsNumber(object value)
        {
            return value is sbyte
                   || value is byte
                   || value is short
                   || value is ushort
                   || value is int
                   || value is uint
                   || value is long
                   || value is ulong
                   || value is float
                   || value is double
                   || value is decimal;
        }


        private static void Main()
        {
            Console.WriteLine(CalculateTriangleArea(3, 4, 5));

            Console.WriteLine(DigitToString(5));

            Console.WriteLine(FindMaxInt(5, -1, 3, 2, 14, 2, 3));

            PrintAsNumber(1.3, "f");
            PrintAsNumber(0.75, "%");
            PrintAsNumber(2.30, "r");
            

            bool horizontal, vertical;
            Console.WriteLine(CalculateDistance(3, -1, 3, 2.5));
            IsHorisontalOrVertical(3, -1, 3, 2.5, out horizontal, out vertical);
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student() {FirstName = "Peter", LastName = "Ivanov"};
            peter.OtherInfo = "From Sofia, born at 17.03.1992";

            Student stella = new Student() {FirstName = "Stella", LastName = "Markova"};
            stella.OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993";

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}