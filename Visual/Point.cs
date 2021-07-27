using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visual
{
    public class PointD
    {
        public double X { get; set; }
        public double Y { get; set; }

        public PointD(double x, double y)
        {
            X = x;
            Y = y;
        }

        public static PointD operator +(PointD a) => a;
        public static PointD operator +(PointD a, PointD b)
        {
            if (a == null && b == null)
            {
                return null;
            }
            else if (a == null && b != null)
            {
                return b;
            }
            else if (a != null && b == null)
            {
                return a;
            }
            else
            {
                return new PointD(a.X + b.X, a.Y + b.Y);
            }
        }
        public static PointD operator -(PointD a)
        {
            if (a == null)
            {
                return null;
            }

            return new PointD(-a.X, -a.Y);
        }
        public static PointD operator -(PointD a, PointD b) => a + (-b);
        public static PointD operator *(PointD a, double b)
        {
            if (b == 0)
            {
                return null;
            }

            if (a == null)
            {
                return null;
            }

            return new PointD(a.X * b, a.Y * b);
        }

        public static PointD operator *(double b, PointD a) => a * b;
        public static PointD operator /(PointD a, double b) => new PointD(a.X / b, a.Y / b);
    }
}
