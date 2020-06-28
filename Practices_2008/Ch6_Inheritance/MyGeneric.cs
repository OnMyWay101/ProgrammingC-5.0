using System;
using System.Collections.Generic;


namespace Ch6_Inheritance
{
    class MyGeneric
    {
        public class Base
        {

        }

        public class Derived : Base
        {

        }

        public class MoreDerived : Derived
        {

        }

        public static void AllYourBase(IEnumerable<Base> bases)
        {

        }

        public static void Example_AllYourBase()
        {
            IEnumerable<Derived> derives = new Derived[]{ new Derived(), new Derived()};
            //AllYourBase(derives);
        }

        public static void AddBase(ICollection<Base> bases)
        {
            bases.Add(new Base());
        }

        public static void Example_AddBase()
        {
            ICollection<Derived> derivedList = new List<Derived>;
            //AddBase(new Base());
        }

        public class Shape
        {
            public Rect BoundingBox { get; set; }
        }

        public class RoundRectangle : Shape
        {
            public double ConnerRadius { get; set; }
        }

        public class BoxAreaComparer : IComparer<Shape>
        {
            public int Compare(Shape x, Shape y)
            {
                double xArea = x.BoundingBox.Width * x.BoundingBox.Height;
                double yArea = y.BoundingBox.Width * y.BoundingBox.Height;
                return Math.Sign(xArea - yArea);
            }
        }

        public class ConnerShapenessComparer : IComparer<RoundRectangle>
        {
            public int Compare(RoundRectangle x, RoundRectangle y)
            {
                return Math.Sign(y.ConnerRadius - x.ConnerRadius);
            }
        }
    }
}
