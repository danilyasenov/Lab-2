using System;
using Lab_2;

public static class RootFindingStrategies
{
    public static readonly IRootFindingStrategy LinearStrategy = new LinearRootFindingStrategy();
    public static readonly IRootFindingStrategy QuadraticStrategy = new QuadraticRootFindingStrategy();

    private class LinearRootFindingStrategy : IRootFindingStrategy
    {
        public Complex[] FindRoots(double[] coefficients)
        {
            if (coefficients.Length < 2)
            {
                throw new ArgumentException("Linear equation must have at least 2 coefficients.");
            }

            double a = coefficients[0];
            double b = coefficients[1];

            if (a == 0)
            {
                if (b == 0)
                {
                    throw new InfiniteRootsException();
                }
                throw new NoComplexRootsException();
            }

            return new[] { new Complex(-b / a, 0) };
        }
    }

    private class QuadraticRootFindingStrategy : IRootFindingStrategy
    {
        public Complex[] FindRoots(double[] coefficients)
        {
            if (coefficients.Length < 3)
            {
                throw new ArgumentException("Quadratic equation must have at least 3 coefficients.");
            }

            double a = coefficients[0];
            double b = coefficients[1];
            double c = coefficients[2];

            if (a == 0)
            {
                return LinearStrategy.FindRoots(new[] { b, c });
            }

            double discriminant = b * b - 4 * a * c;
            Complex sqrtDiscriminant = Complex.Sqrt(discriminant);

            Complex root1 = (-b + sqrtDiscriminant) / (2 * a);
            Complex root2 = (-b - sqrtDiscriminant) / (2 * a);

            return new[] { root1, root2 };
        }
    }
}
