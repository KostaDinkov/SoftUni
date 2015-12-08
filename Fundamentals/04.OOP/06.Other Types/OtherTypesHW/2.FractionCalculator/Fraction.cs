namespace _2.FractionCalculator
{
    using System.Globalization;

    public struct Fraction
    {
        public Fraction(long numerator, long denominator)
        {
            if (numerator == long.MinValue)
                numerator++; // prevent serious issues later..

            if (denominator == long.MinValue)
                denominator++; // prevent serious issues later..

            this.Numerator = numerator;
            this.Denominator = denominator;
        }

        public override string ToString()
        {
            return ((double) this.Numerator/this.Denominator).ToString(CultureInfo.CurrentCulture);
        }

        #region Operator_Overriding

        public static Fraction operator -(Fraction left)
        {
            return Negate(left);
        }

        public static Fraction operator +(Fraction left, Fraction right)
        {
            return Add(left, right);
        }

        public static Fraction operator -(Fraction left, Fraction right)
        {
            return Add(left, -right);
        }

        #endregion

        #region Math_Helpers

        private static Fraction Negate(Fraction frac)
        {
            return new Fraction(-frac.Numerator, frac.Denominator);
        }

        private static Fraction Add(Fraction left, Fraction right)
        {
            var gcd = GCD(left.Denominator, right.Denominator);
            var leftDenominator = left.Denominator/gcd;
            var rightDenominator = right.Denominator/gcd;

            var numerator = left.Numerator*rightDenominator + right.Numerator*leftDenominator;
            var denominator = leftDenominator*rightDenominator*gcd;

            return new Fraction(numerator, denominator);
        }

        private static long GCD(long left, long right)
        {
            // take absolute values
            if (left < 0)
                left = -left;

            if (right < 0)
                right = -right;

            // if we're dealing with any zero or one, the GCD is 1
            if (left < 2 || right < 2)
                return 1;

            do
            {
                if (left < right)
                {
                    var temp = left; // swap the two operands
                    left = right;
                    right = temp;
                }

                left %= right;
            } while (left != 0);

            return right;
        }
        #endregion

        #region Properties

        public long Numerator { get; set; }

        public long Denominator { get; set; }

        #endregion
    } //end class Fraction
}