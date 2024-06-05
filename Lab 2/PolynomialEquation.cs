using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    public class PolynomialEquation : IEquation
    {
        private readonly double[] coefficients;
        private readonly IRootFindingStrategy strategy;

        public PolynomialEquation(double[] coefficients, IRootFindingStrategy strategy)
        {
            this.coefficients = coefficients;
            this.strategy = strategy;
        }

        public int Dimension => coefficients.Length;

        public double[] Coefficients => (double[])coefficients.Clone();

        public Complex[] FindRoots()
        {
            return strategy.FindRoots(coefficients);
        }
    }
}
