using System;
using System.Globalization;
using System.Collections.Generic;

namespace Ch10_LINQ
{
    public static class CustomProvider
    {
        public static CultureInfo[] Where(this CultureInfo[] cultures, Predicate<CultureInfo> pred)/*linqProvider方法的参数加个this什么意思？*/
        {
            return Array.FindAll(cultures, pred);
        }

        public static T[] Select<T>(this CultureInfo[] cultures, Func<CultureInfo, T> map)
        {
            var result = new T[cultures.Length];
            for(int i = 0; i < cultures.Length; i++)
            {
                result[i] = map(cultures[i]);
            }
            return result;
        }

        public static void Example_Simple1()
        {
            //Linq语法使用
            //var result = from culture in CultureInfo.GetCultures(CultureTypes.AllCultures)
            //             where culture.NumberFormat.NumberDecimalSeparator == ","
            //             select culture;
            //函数调用方法使用
            var result = CultureInfo.GetCultures(CultureTypes.AllCultures)
                        .Where(culture => culture.NumberFormat.NumberDecimalSeparator == ",")
                        .Select(culture => culture);
            Console.WriteLine("The type of result:" + result.GetType().ToString());
            Console.WriteLine("The toString of result:" + result.ToString());
            Console.WriteLine("Foreach begin:");
            foreach(var element in result)
            {
                Console.WriteLine(element.Name);
            }
        }
    }

    public static class CustomDefferedProvider
    {
        public static IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T, bool> pred)
        {
            foreach(T t in source)
            {
                if(pred(t))
                {
                    Console.WriteLine("yield return");
                    yield return t;
                }
            }
        }
        public static void Example_Use()
        {
            var nums = new int[] { 1, 2, 3, 4, 5 };
            var result = from num in nums
                         where num > 3
                         select num;
            foreach(var num in result)
            {
                Console.WriteLine(num);
            }
        }
    }

}
