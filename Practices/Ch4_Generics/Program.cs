using System;
using System.Collections.Generic;

namespace Ch4_Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            MethodExample();

            Console.ReadLine();
        }

        #region 泛型函数示例

        public static T GetLast<T>(T[] items)
        {
            return items[items.Length - 1];
        }

        //public static T MakeFake<T>()
        //    where T : class
        //{
        //    return new Mock<T>().Object;
        //}

        public static void MethodExample()
        {
            int[] values = { 1, 2, 3 };
           // int lastInt = GetLast<int>(values);
            int lastInt = GetLast(values);
            Console.WriteLine("last int is :{0}", lastInt);
        }

        #endregion
    }
}
