using System;

namespace Polynominterpolation
{
    class TermPart
    {
        SumPart[] parts;
        double prefix;

        public TermPart(double[,] table, int degree,int i)
        {

            

            parts = new SumPart[degree];
            generate(table, degree, i);
        }

        public double calc(double x)
        {
            double ret = 1;
            foreach(SumPart s in parts)
            {
                ret *= s.calc(x);
            }
            return prefix * ret;
        }

        private void generate(double[,] table,int degree, int i)
        {
            this.prefix = table[1, i];
            int sumPartCount = 0;
            for(int k = 0; k < table.GetLength(1); k++)
            {
                if(k != i)
                {
                    SumPart sp = new SumPart(table[0, i], table[0, k]);
                    parts[sumPartCount] = sp;
                    sumPartCount++;
                }
            }
        }

    }
}
