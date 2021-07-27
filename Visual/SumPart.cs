using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynominterpolation
{
    class SumPart
    {
        double xi, xk;
        public SumPart(double xi, double xk)
        {
            this.xi = xi;
            this.xk = xk;
        }

        public double calc(double x)
        {
            return (x - xk) / (xi - xk);
        }
    }
}
