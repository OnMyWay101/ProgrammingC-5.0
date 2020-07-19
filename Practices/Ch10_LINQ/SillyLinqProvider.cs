using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch10_LINQ
{
    class SillyLinqProvider
    {
        public SillyLinqProvider Where(Func<string, int> pred)
        {
            Console.WriteLine("Where invoke");
            return this;
        }

        public string Select<T>(Func<DateTime, T> map)
        {
            Console.WriteLine("Select invoke,with type argument" + typeof(T));
            return "this operator makes no sense";
        }
        public static void Example_simple()
        {
            //var q = from testOne in new SillyLinqProvider()
            //        where int.Parse(testOne)
            //        select testOne.Hour;
            var q = new SillyLinqProvider().Where(x => int.Parse(x)).Select(x => x.Hour);
            Console.WriteLine("GetType:" + q.GetType().ToString());
            Console.WriteLine("ToString:" + q.ToString());
        }
    }
}
