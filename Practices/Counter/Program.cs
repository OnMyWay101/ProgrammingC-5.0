using System;

namespace Counter
{
    class Program
    {
        static void Main(string[] args)
        {
            //CompareTest2();
            StructTest();
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

        static void StructTest()
        {
            StructCounter s1 = new StructCounter();
            s1++;
            Console.WriteLine("s1:" + s1.SCount);

            StructCounter s2 = s1;
            s1++;
            Console.WriteLine("s1:" + s1.SCount);
            Console.WriteLine("s2:" + s2.SCount);

            Console.WriteLine(s1 == s2);
            Console.WriteLine(s1 != s2);
            Console.WriteLine(s1.Equals(s2));
            Console.WriteLine(s1.GetHashCode());

            Console.ReadLine();
            return;
        }

        public struct StructCounter
        {
            private readonly int _sCount;
            private static int _totalSCount;

            private StructCounter(int count)
            {
                _sCount = count;
            }

            public StructCounter GetNextValue()
            {
                _totalSCount += 1;
                return new StructCounter(_sCount + 1);
            }

            public static StructCounter operator ++(StructCounter input)
            {
                return input.GetNextValue();
            }

            public static bool operator ==(StructCounter leftInput, StructCounter rightInput)
            {
                return leftInput.SCount == rightInput.SCount;
            }

            public static bool operator !=(StructCounter leftInput, StructCounter rightInput)
            {
                return leftInput.SCount != rightInput.SCount;
            }

            public override bool Equals(object obj)
            {
                if(obj is StructCounter)
                {
                    StructCounter c = (StructCounter)obj;
                    return this == c;
                }
                else
                {
                    return false;
                }
            }

            public override int GetHashCode()
            {
                return _sCount;
            }

            public int SCount
            {
                get
                {
                    return _sCount;
                }
            }

            public static int TotalSCount
            {
                get
                {
                    return _totalSCount;
                }
            }

        }

    }
}
