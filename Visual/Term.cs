using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Polynominterpolation
{
    class Term
    {
        TermPart[] parts;
        public Term(double[,] table, int degree)
        {
            if (table.GetLength(0) != 2 || table.GetLength(1) != degree + 1)
            {
                Console.WriteLine("Inalid table");
                return;
            }
            parts = new TermPart[degree + 1];
            generate(table, degree);
        }

        public double calc(double x)
        {
            double ret = 0;
            foreach(TermPart tp in parts)
            {
                ret += tp.calc(x);
            }
            return ret;
        }

        private void generate(double[,] table, int degree)
        {
            for(int i = 0; i <= degree; i++)
            {
                parts[i] = new TermPart(table, degree, i);
            }
        }
        
    }
}
