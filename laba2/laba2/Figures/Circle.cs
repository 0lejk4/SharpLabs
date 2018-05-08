using System;

namespace laba2.Figures
{
    public class Circle : Figure
    {
        public Circle(double r)
        {
            this.r = r;
            if (r > 322)
            {
                throw new TooBigException(this.ToString());
            }
        }

        public Circle()
        {
        }

        private double r { get; set; }

        public override double square => Math.PI * r * r;


        public override double perimeter => 2 * Math.PI * r;


        public override Figure DeepCopy()
        {
            return new Circle(r);
        }

        public override (double x, double y) gravityCenter => (r, r);

        public static Circle operator +(Circle x, Circle y)
        {
            return new Circle {r = x.r + y.r};
        }

        public static Circle operator -(Circle x, Circle y)
        {
            return new Circle {r = x.r - y.r};
        }

        public static Circle operator *(Circle x, double y)
        {
            return new Circle {r = x.r * y};
        }

        public static Circle operator /(Circle x, double y)
        {
            if (y == 0.0) throw new DivideByZeroException();

            return new Circle {r = x.r / y};
        }

        public override bool Equals(object x)
        {
            var obj = (Circle) x;
            return r == obj.r;
        }

        public static bool operator ==(Circle x, Circle y)
        {
            return Equals(x, y);
        }

        public static bool operator !=(Circle x, Circle y)
        {
            return !Equals(x, y);
        }

        public override int GetHashCode()
        {
            return r.GetHashCode();
        }

        public override string ToString()
        {
            return $"Circle: ({r})";
        }
    }
}