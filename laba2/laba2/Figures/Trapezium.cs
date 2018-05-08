using System;
using System.Globalization;

namespace laba2.Figures
{
    public class Trapezium : Figure
    {
        public Trapezium(double a, double b, double h)
        {
            this.a = a;
            this.b = b;
            this.h = h;
            if (b > 322 || a > 322 || h > 322)
            {
                throw new TooBigException(this.ToString());
            }
        }

        public Trapezium()
        {
        }

        private double a { get; set; }

        private double b { get; set; }

        private double h { get; set; }

        public override double square => (a + b) * h / 2;


        public override double perimeter => Math.Sqrt(((b - a) / 2) * ((b - a) / 2) + h * h);


        public override (double x, double y) gravityCenter => (a / 2, h / 3 * ((2 * b + a) / (a + b)));

        public override Figure DeepCopy()
        {
            return new Trapezium(a, b, h);
        }


        public static Trapezium operator +(Trapezium x, Trapezium y)
        {
            return new Trapezium
            {
                a = x.a + y.a,
                b = x.b + y.b,
                h = x.h + y.h
            };
        }

        public static Trapezium operator -(Trapezium x, Trapezium y)
        {
            return new Trapezium
            {
                a = x.a - y.a,
                b = x.b - y.b,
                h = x.h - y.h
            };
        }

        public static Trapezium operator *(Trapezium x, double y)
        {
            return new Trapezium
            {
                a = x.a * y,
                b = x.b * y,
                h = x.h * y
            };
        }

        public static Trapezium operator /(Trapezium x, double y)
        {
            if (y == 0.0) throw new DivideByZeroException();

            return new Trapezium
            {
                a = x.a / y,
                b = x.b / y,
                h = x.h / y
            };
        }

        public override bool Equals(object x)
        {
            var obj = (Trapezium) x;
            return h == obj.h && a == obj.a && b == obj.b;
        }

        public static bool operator ==(Trapezium x, Trapezium y)
        {
            return Equals(x, y);
        }

        public static bool operator !=(Trapezium x, Trapezium y)
        {
            return !Equals(x, y);
        }

        public override int GetHashCode()
        {
            return a.GetHashCode() + 17 * h.GetHashCode() * b.GetHashCode();
        }

        public override string ToString()
        {
            return $"Trapezium: ({h},{a})";
        }
    }
}