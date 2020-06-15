using System;
using System.Reflection;
using System.Numerics;
using System.Diagnostics;

namespace Ch5_Collections
{
    public class MyArray
    {
/// <summary>
/// 
/// </summary>
        public static void Example_AccessElement()
        {
            int[] numbers = new int[10];
            string[] strings = new string[numbers.Length];

            numbers[0] = 42;
            numbers[1] = numbers.Length;
            numbers[2] = numbers[0] + numbers[1];
            numbers[numbers.Length - 1] = 99;
        }
/// <summary>
/// 
/// </summary>
        public static void Example_GetCopyright()
        {
            string MyString = "Hello World!";
            Console.WriteLine(GetCopyrightForType(MyString));
            Console.ReadLine();
        }

        private static string GetCopyrightForType(object o)
        {
            Assembly asm = o.GetType().Assembly;
            var copyrightAttribute = (AssemblyCopyrightAttribute)
                asm.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), true)[0];
            return copyrightAttribute.Copyright;
        }

/// <summary>
/// 
/// </summary>
        public static void Example_ReadOnlyElement()
        {
            var comp1 = new Complex(20, 20);
            var values = new Complex[10];
            //values[0].Real = 10;
            //values[0].Imaginary = 1;
            values[0] = new Complex(10, 1);
        }

        //Initialization
        public static void Example_Initialization()
        {
            Console.WriteLine("Test1:{0}, {1}, {2}, {3}, {4}", 0, 1, 2, 3, 4);
            Console.WriteLine("Test2:{0}, {1}, {2}, {3}, {4}", new object[]{ 0, 1, 2, 3, 4});
            Console.ReadLine();
        }

        //Serching 
        public static void Example_Searching()
        {
            var bins = new int[] { 0, 0, 0, 1, 0 };
            Console.WriteLine("The NoEmpty element Index is:" + GetIndexOfFirstNonEmptyBin(bins));
            Console.ReadLine();
        }

        private static int GetIndexOfFirstNonEmptyBin(int[] bins)
        {
            //return Array.FindIndex(bins, IsGreaterThanZero);
            //Lambda表达式
            return Array.FindIndex(bins, value => value > 0);
        }
        private static bool IsGreaterThanZero(int value)
        {
            return value > 0;
        }

        public static void Example_BinarySearch()
        {
            var sw = new Stopwatch();
            int[] big = new int[100000000];
            Console.WriteLine("Initializing");
            sw.Start();
            var r = new Random();
            for(int i = 0; i < big.Length; i++)
            {
                big[i] = r.Next(big.Length);
            }
            sw.Stop();
            Console.WriteLine(sw.Elapsed.ToString("s\\.f"));
            Console.WriteLine();

            Console.WriteLine("Gernerally Searching");
            for(int i = 0; i < 6; i++)
            {
                int searchFor = r.Next(big.Length);
                sw.Reset();
                sw.Start();
                int index = Array.IndexOf(big, searchFor);
                sw.Stop();
                Console.WriteLine("SearchTime:{0}; Index:{1}; CostTime;{2:s\\.ffff}", i, index, sw.Elapsed);
            }
            Console.WriteLine();

            Console.WriteLine("Sorting");
            sw.Reset();
            sw.Start();
            Array.Sort(big);
            sw.Stop();
            Console.WriteLine(sw.Elapsed.ToString("s\\.f"));
            Console.WriteLine();

            Console.WriteLine("Binary Searching");
            for (int i = 0; i < 6; i++)
            {
                int searchFor = r.Next() % big.Length;
                sw.Reset();
                sw.Start();
                int index = Array.BinarySearch(big, searchFor);
                sw.Stop();
                Console.WriteLine("SearchTime:{0}; Index:{1}; CostTime;{2:s\\.fffffff}", i, index, sw.Elapsed);
            }
            Console.ReadLine();
        }

    }


}
