using System;

namespace Counter
{
    class Program
    {
        static void Main(string[] args)
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
        }
    }
}
