using System;
using System.Collections.Generic;
using System.Numerics;
using System.Collections;

namespace Ch5_Collections
{
    class MyList
    {

        public static void Example_UsingList()
        {
            //var numbers = new List<int>();
            //numbers.Add(1);
            //numbers.Add(2);
            //numbers.Add(3);
            var numbers = new List<int> { 1, 11, 111};

            Console.WriteLine("Count:" + numbers.Count);
            Console.WriteLine("numbers:{0}, {1}, {2}", numbers[0], numbers[1], numbers[2]);

            numbers[1] += 1;
            Console.WriteLine("numbers:{0}, {1}, {2}", numbers[0], numbers[1], numbers[2]);

            numbers.RemoveAt(1);
            Console.WriteLine("Count:" + numbers.Count);
            Console.WriteLine("numbers:{0}, {1}", numbers[0], numbers[1]);

            Console.ReadLine();
        }

        public static void Example_Numbers()
        {
            foreach(int i in Numbers(1, 5))
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }

        static IEnumerable<int> Numbers(int start , int count)
        {
            //for(int i = 0; i < count; ++i)
            //{
            //    yield return start + i * 2;
            //}
            yield return 1;
            yield return 2;
            yield return 3;
            yield return 4;
        }

        public static IEnumerable<BigInteger> Fibonacci()
        {
            BigInteger v1 = 1;
            BigInteger v2 = 1;

            while(true)
            {
                yield return v1;
                var tmp = v2;
                v2 = v1 + v2;
                v1 = tmp;
            }
        }

        class FibonacciEnumerable: IEnumerable<BigInteger>, IEnumerator<BigInteger>
        {
            private BigInteger v1;
            private BigInteger v2;
            private bool first = true;

            public BigInteger Current
            {
                get { return v1; }
            }

            public void Dispose()
            {

            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            public bool MoveNext()
            {
                if(first)
                {
                    v1 = 1;
                    v2 = 1;
                    first = false;
                }
                else
                {
                    var tmp = v2;
                    v2 = v1 + v2;
                    v1 = tmp;
                }
                return true;
            }

            public void Reset()
            {
                first = true;
            }

            public IEnumerator<BigInteger> GetEnumerator()
            {
                return new FibonacciEnumerable();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        public static void Example_Fibonacci()
        {
            var fi = new FibonacciEnumerable();
            foreach (int i in fi)
            {
                Console.WriteLine(i);
                System.Threading.Thread.Sleep(1000);
            }
            Console.ReadLine();
        }
    }
}
