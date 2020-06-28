using System;
using System.IO;
using System.Collections.Generic;

namespace Ch7_ObjectLifeTime
{
    class MyIDisposable
    {
        static string _helloText = @"C:\Users\weil\Desktop\helloworld.txt";

        public static void Example_Using()
        {
            using (StreamReader sr = File.OpenText(_helloText))
            {
                Console.WriteLine(sr.ReadToEnd());
            }

        }
        public static void Example_InsteadUsing()
        {
            StreamReader sr = File.OpenText(_helloText);
            try
            {
                Console.WriteLine(sr.ReadToEnd());
            }
            finally
            {
                if(sr != null)
                {
                    ((IDisposable)sr).Dispose();
                }
            }
        }

        public static void Example_MutiUsing()
        {
            using (Stream source = File.OpenRead(_helloText))
            using (Stream copy = File.Create(@"C:\Users\weil\Desktop\copy.txt"))
            {
                //source.CopyTo(copy);
            }
        }

        public static void Example_Foreach()
        {
            foreach (string file in Directory.GetFiles(@"C:\Users\weil\Desktop\其他文件"))
            {
                Console.WriteLine(file);
            }
        }

        public static void Example_InsteadForeach()
        {
            IEnumerable<string> iEString = (IEnumerable<string>)(Directory.GetFiles(@"C:\Users\weil\Desktop\其他文件"));
            IEnumerator<string> e = iEString.GetEnumerator();

            try
            {
                while (e.MoveNext())
                {
                    string file = e.Current;
                    Console.WriteLine(file);
                }
            }
            finally
            {
                if (e != null)
                {
                    ((IDisposable)e).Dispose();
                }
            }
        }

    }
}
