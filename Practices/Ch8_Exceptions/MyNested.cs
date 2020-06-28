using System;
using System.IO;

namespace Ch8_Exceptions
{
    class MyNested
    {
        public static void PrintFirstLineLength(string fileName)
        {
            try
            {
                using (var r = new StreamReader(fileName))
                {
                    try
                    {
                        Console.WriteLine(r.ReadLine().Length);
                    }
                    catch(IOException x)
                    {
                        Console.WriteLine("Error While reading file: {0}", x.Message);
                    }
                }
            }
            catch(FileNotFoundException x)
            {
                Console.WriteLine("Couldn't find the file '{0}'", x.FileName);
            }
            catch(DirectoryNotFoundException x)
            {
                Console.WriteLine("Couldn't find the directory '{0}'", x.Message);
            }
        }


        public static void Example_Nested()
        {
            try
            {
                PrintFirstLineLength(@"C:\Users\WANGCJ\Desktop\File.txt");
            }
            catch(NullReferenceException)
            {
                Console.WriteLine("NullReferenceException");
            }
        }
    }
}
