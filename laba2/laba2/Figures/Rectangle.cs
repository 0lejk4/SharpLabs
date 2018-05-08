using System;

namespace laba2.Figures
{
    public class Rectangle : Figure
    {
        public Rectangle(double b)
        {
            this.b = b;
            if (b > 322)
            {
                throw new TooBigException(this.ToString());
            }
        }

        public Rectangle()
        {
        }

        private double b { get; set; }

        public override double square => b * b;


        public override double perimeter => (b + b) * 2;


        public override (double x, double y) gravityCenter => (b / 2, b / 2 * Math.Sqrt(2));

        public override Figure DeepCopy()
        {
            return new Rectangle(b);
        }

        public static Rectangle operator +(Rectangle x, Rectangle y)
        {
            return new Rectangle
            {
                b = x.b + y.b
            };
        }

        public static Rectangle operator -(Rectangle x, Rectangle y)
        {
            return new Rectangle
            {
                b = x.b - y.b
            };
        }

        public static Rectangle operator *(Rectangle x, double y)
        {
            return new Rectangle
            {
                b = x.b * y
            };
        }

        public static Rectangle operator /(Rectangle x, double y)
        {
            if (y == 0.0) throw new DivideByZeroException();

            return new Rectangle
            {
                b = x.b / y
            };
        }

        public override bool Equals(object x)
        {
            var obj = (Rectangle) x;
            return obj != null && b == obj.b;
        }

        public static bool operator ==(Rectangle x, Rectangle y)
        {
            return Equals(x, y);
        }

        public static bool operator !=(Rectangle x, Rectangle y)
        {
            return !Equals(x, y);
        }

        public override int GetHashCode()
        {
            return b.GetHashCode() + 17;
        }

        public override string ToString()
        {
            return $"Rectangle: ({b})";
        }
    }
}