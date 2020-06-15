using System;
using System.Collections.Generic;

namespace Ch4_ZeroLike
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.ReadLine();
        }

        #region 打印类型的ZeroLike_Value

        static void TestDefault()
        {
            Console.WriteLine("TypeTest:Int");
            PrintDefault<int>();
            Console.WriteLine("TypeTest:bool");
            PrintDefault<bool>();
            Console.WriteLine("TypeTest:string");
            PrintDefault<string>();
            Console.WriteLine("TypeTest:object");
            PrintDefault<object>();
        }

        static void PrintDefault<T>()
        {
            Console.WriteLine(default(T));
        }

        #endregion


    }
}
