using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    public interface IEquation
    {
        int Dimension { get; }
        double[] Coefficients { get; }
        Complex[] FindRoots();
    }
}
