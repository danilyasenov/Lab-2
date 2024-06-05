using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    public static class Equations
    {
        public static double[] RemoveLeadingZeros(double[] coefficients)
        {
            int nonZeroIndex = Array.FindIndex(coefficients, x => x != 0);
            if (nonZeroIndex == -1)
            {
                return new double[] { 0 };
            }
            return coefficients.Skip(nonZeroIndex).ToArray();
        }

        public static IRootFindingStrategy SelectStrategy(double[] coefficients)
        {
            int degree = coefficients.Length - 1;

            switch (degree)
            {
                case 1:
                    return RootFindingStrategies.LinearStrategy;
                case 2:
                    return RootFindingStrategies.QuadraticStrategy;
                // Add more cases for higher degree equations if needed
                default:
                    throw new UnknownEquationTypeException();
            }
        }

        public static PolynomialEquation CreateEquation(double[] coefficients)
        {
            double[] cleanCoefficients = RemoveLeadingZeros(coefficients);
            IRootFindingStrategy strategy = SelectStrategy(cleanCoefficients);
            return new PolynomialEquation(cleanCoefficients, strategy);
        }
    }
}
