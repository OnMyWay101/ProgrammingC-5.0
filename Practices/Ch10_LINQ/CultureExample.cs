using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;

namespace Ch10_LINQ
{
    class CultureExample
    {
        public static void Example_SimpleQuery()
        {
            //Linq访问
            IEnumerable<CultureInfo> commaCulture =
                from culture in CultureInfo.GetCultures(CultureTypes.AllCultures)
                where culture.NumberFormat.NumberDecimalSeparator == ","
                select culture;
            foreach (CultureInfo culture in commaCulture)
            {
                Console.WriteLine(culture.Name);
            }
            //ChainMethod访问
            IEnumerable<string> commaCulture2 = CultureInfo.GetCultures(CultureTypes.AllCultures)
                .Where(culture => culture.NumberFormat.NumberDecimalSeparator == ",")
                .Select(culture => culture.Name);
            foreach (string s in commaCulture2)
            {
                Console.WriteLine(s);
            }
            //常规访问
            //CultureInfo[] allCultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            //foreach(CultureInfo culture in allCultures)
            //{
            //    if(culture.NumberFormat.NumberDecimalSeparator == ",")
            //    {
            //        Console.WriteLine(culture.Name);
            //    }
            //}
        }

        public static void Example_MultiVariable()
        {
            //Linq访问
            IEnumerable<CultureInfo> commaCulture =
                from culture in CultureInfo.GetCultures(CultureTypes.AllCultures)
                let numFormat = culture.NumberFormat
                where numFormat.NumberDecimalSeparator == ","
                select culture;
            foreach (CultureInfo culture in commaCulture)
            {
                Console.WriteLine(culture.Name);
            }
            //
            IEnumerable<string> commaCulture2 = CultureInfo.GetCultures(CultureTypes.AllCultures)
                .Select(culture => new { culture, numberFormat = culture.NumberFormat })
                .Where(vars => vars.numberFormat.NumberDecimalSeparator == ",")
                .Select(vars => vars.culture.Name);
            foreach(string s in commaCulture2)
            {
                Console.WriteLine(s);
            }
        }

    }
}
