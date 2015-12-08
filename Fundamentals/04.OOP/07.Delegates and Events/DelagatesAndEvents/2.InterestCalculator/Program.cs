//---------------------------------------------------
// SoftUni
// Course:      OOP
// Lecture:     Delegates And Events
// Problem:     2.Interest Calculator
// Description: Create a delegate CalculateInterest (or use Func<…>) with parameters sum of 
//              money, interest and years that calculates the interest according to the method it points to. 
//                  The result should be rounded to 4 places after the decimal point.
//              •	Create a method GetSimpleInterest(sum, interest, years). The interest 
//                  should be calculated by the formula A = sum* (1 + interest* years).
//              •	Create a method GetCompoundInterest(sum, interest, years).  The interest 
//                  should be calculated by the formula A = sum* (1 + interest / n)year* n, 
//                  where n is the number of times per year the interest is compounded.Assume n is always 12.
//              Create a class InterestCalculator that takes in its constructor money, 
//                  interest, years and interest calculation delegate. 
//              
// Date:        Friday 12.2015 19:44 
//--------------------------------------------------- 
// NOTE: using double for currency to avoid unnecessary complication at this time

namespace _2.InterestCalculator
{
    using System;

    public delegate double CalculateInterest(double paramA, double paramB, int paramC);

    internal class Program
    {
        private const int CompoundsPerYear = 12;

        private static void Main()
        {
            CalculateInterest simple = GetSimpleInterest;
            CalculateInterest compound = GetCompoundInterest;

            var calculator = new InterestCalculator(500, 5.6, 10, compound);
            Console.WriteLine(calculator.Calculate());
            var secondCalculator = new InterestCalculator(2500, 7.2, 15, simple);
            Console.WriteLine(secondCalculator.Calculate());
        }

        private static double GetSimpleInterest(double sum, double interest, int years)
        {
            return Math.Round(sum*(1 + interest*years), 2);
        }

        private static double GetCompoundInterest(double sum, double interest, int years)
        {
            return Math.Round(sum*Math.Pow((1 + interest/CompoundsPerYear), years*CompoundsPerYear), 4);
        }
    }

    internal class InterestCalculator
    {
        private readonly CalculateInterest calcIterest;
        private readonly double interest;
        private readonly double sum;
        private readonly int years;

        public InterestCalculator(double sum, double interest, int years, CalculateInterest calcInterest)
        {
            this.interest = interest/100;
            this.sum = sum;
            this.years = years;
            this.calcIterest = calcInterest;
        }

        public double Calculate()
        {
            return this.calcIterest(this.sum, this.interest, this.years);
        }
    }
}