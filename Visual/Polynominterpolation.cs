using System;

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
            foreach (TermPart tp in parts)
            {
                ret += tp.calc(x);
            }
            return ret;
        }

        private void generate(double[,] table, int degree)
        {
            for (int i = 0; i <= degree; i++)
            {
                parts[i] = new TermPart(table, degree, i);
            }
        }
    }

    class TermPart
    {
        SumPart[] parts;
        double prefix;

        public TermPart(double[,] table, int degree, int i)
        {
            parts = new SumPart[degree];
            generate(table, degree, i);
        }

        public double calc(double x)
        {
            double ret = 1;
            foreach (SumPart s in parts)
            {
                ret *= s.calc(x);
            }
            return prefix * ret;
        }

        private void generate(double[,] table, int degree, int i)
        {
            this.prefix = table[1, i];
            int sumPartCount = 0;
            for (int k = 0; k < table.GetLength(1); k++)
            {
                if (k != i)
                {
                    SumPart sp = new SumPart(table[0, i], table[0, k]);
                    parts[sumPartCount] = sp;
                    sumPartCount++;
                }
            }
        }
    }

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