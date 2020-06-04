using System;

namespace Counter
{
    class Program
    {
        static void Main(string[] args)
        {
            CompareTest2();
        }

        static void StaticTest()
        {
            Counter c1 = new Counter();
            Counter c2 = c1;
            c1++;
            Console.WriteLine("c1:" + c1.Count);
            c1++;
            Console.WriteLine("c1:" + c1.Count);
            c1 = c1.GetNextValue();
            Console.WriteLine("c1:" + c1.Count);
            c2++;
            Console.WriteLine("c2:" + c2.Count);
            c1++;
            Console.WriteLine("c1:" + c1.Count);
            Console.ReadLine();
            return;
        }

        static void CompareTest()
        {
            Counter c1 = new Counter();
            c1++;
            Counter c2 = c1;
            c1++;
            Counter c3 = new Counter();
            c3++;

            Console.WriteLine(c1.Count);
            Console.WriteLine(c2.Count);
            Console.WriteLine(c3.Count);
            Console.WriteLine(c1 == c2);
            Console.WriteLine(c1 == c3);
            Console.WriteLine(c2 == c3);
            Console.WriteLine(object.ReferenceEquals(c1, c2));
            Console.WriteLine(object.ReferenceEquals(c1, c3));
            Console.WriteLine(object.ReferenceEquals(c2, c3));

            Console.ReadLine();
            return;
        }

        static void CompareTest2()
        {
            int c1 = new int();
            c1++;
            int c2 = c1;

            int c3 = new int();
            c3++;

            Console.WriteLine(c1);
            Console.WriteLine(c2);
            Console.WriteLine(c3);
            Console.WriteLine(c1 == c2);
            Console.WriteLine(c1 == c3);
            Console.WriteLine(c2 == c3);
            Console.WriteLine(object.ReferenceEquals(c1, c2));
            Console.WriteLine(object.ReferenceEquals(c1, c3));
            Console.WriteLine(object.ReferenceEquals(c2, c3));
            Console.WriteLine(object.ReferenceEquals(c1, c1));

            Console.ReadLine();
            return;
        }

    }
}
