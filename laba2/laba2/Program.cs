using System;
using System.Collections.Generic;
using laba2.Figures;

namespace laba2
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("TestOperationsCircle");
            TestOperationsCircle();
            Console.WriteLine("TestOperationsRectangle");
            TestOperationsRectangle();
            Console.WriteLine("TestOperationsTrapezium");
            TestOperationsTrapezium();
            Console.WriteLine("TestException");
            TestException();
            Console.WriteLine("TestPicture");
            TestPicture();
        }

        public static void ChangeListener(ChangeType change)
        {
            switch (change)
            {
                case ChangeType.Add:
                    Console.WriteLine("Element added");
                    break;
                case ChangeType.Delete:
                    Console.WriteLine("Element deleted");
                    break;
                case ChangeType.Set:
                    Console.WriteLine("Element setted");
                    break;
                case ChangeType.Insert:
                    Console.WriteLine("Element inserted");
                    break;
            }
        }

        public static void TestException()
        {
            try
            {
                var c = new Circle(323);
            }
            catch (TooBigException e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public static void TestOperationsCircle()
        {
            var c1 = new Circle(2);
            var c2 = new Circle(3);
            Console.WriteLine($" c1 + c2 = {c1 * 2}");
            Console.WriteLine($" c1 / c2 = {c1 / 2}");
            Console.WriteLine($" c1 == c2 = {c1 == c2}");
            Console.WriteLine($" c1.Hashcode = {c1.GetHashCode()}");
            Console.WriteLine($" c2.Hashcode = {c2.GetHashCode()}");
            Console.WriteLine($" c1.square = {c1.square}");
            Console.WriteLine($" c1.perimeter = {c1.perimeter}");
            Console.WriteLine($" c1.gravityCenter = {c1.gravityCenter}");
            Console.WriteLine($" c2.square = {c2.square}");
            Console.WriteLine($" c2.perimeter = {c2.perimeter}");
            Console.WriteLine($" c2.gravityCenter = {c2.gravityCenter}");
        }

        public static void TestOperationsRectangle()
        {
            var r1 = new Rectangle(2);
            var r2 = new Rectangle(3);
            Console.WriteLine($" r1 + r2 = {r1 * 2}");
            Console.WriteLine($" r1 / r2 = {r1 / 2}");
            Console.WriteLine($" r1 == r2 = {r1 == r2}");
            Console.WriteLine($" r1.Hashcode = {r1.GetHashCode()}");
            Console.WriteLine($" r2.Hashcode = {r2.GetHashCode()}");
            Console.WriteLine($" r1.square = {r1.square}");
            Console.WriteLine($" r1.perimeter = {r1.perimeter}");
            Console.WriteLine($" r1.gravityCenter = {r1.gravityCenter}");
            Console.WriteLine($" r2.square = {r2.square}");
            Console.WriteLine($" r2.perimeter = {r2.perimeter}");
            Console.WriteLine($" r2.gravityCenter = {r2.gravityCenter}");
        }

        public static void TestOperationsTrapezium()
        {
            var t1 = new Trapezium(2, 2 , 3);
            var t2 = new Trapezium(3, 2 ,2);
            Console.WriteLine($" t1 + t2 = {t1 * 2}");
            Console.WriteLine($" t1 / t2 = {t1 / 2}");
            Console.WriteLine($" t1 == t2 = {t1 == t2}");
            Console.WriteLine($" t1.Hashcode = {t1.GetHashCode()}");
            Console.WriteLine($" t2.Hashcode = {t2.GetHashCode()}");
            Console.WriteLine($" t1.square = {t1.square}");
            Console.WriteLine($" t1.perimeter = {t1.perimeter}");
            Console.WriteLine($" t1.gravityCenter = {t1.gravityCenter}");
            Console.WriteLine($" t2.square = {t2.square}");
            Console.WriteLine($" t2.perimeter = {t2.perimeter}");
            Console.WriteLine($" t2.gravityCenter = {t2.gravityCenter}");
        }

        public static void TestPicture()
        {
            var picture = new Picture<Figure>();
            picture.Changed += ChangeListener;
            picture.Add(new Rectangle(4));
            picture.Add(new Trapezium(1, 4, 4));
            picture.Insert(1, new Trapezium(3, 1, 4));
            picture.Add(new Rectangle(6) + new Rectangle(4));
            picture.Add(new Circle(37));
            picture.Delete(1);
            Console.WriteLine(picture);


            try
            {
                picture.Get(48);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("IndexOutOfRangeException");
            }

            try
            {
                var x = (Rectangle) picture.Get(0) / 0;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("DivideByZeroException");
            }

            Console.WriteLine((Rectangle) picture.Get(0) == new Rectangle(1) * 0);
            Console.ReadKey();
        }
    }
}