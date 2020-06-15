using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitializeTest
{
    class Circular
    {
    }
    public class AfterYou
    {
        static AfterYou()
        {
            Console.WriteLine("AfterYou static constuctor  starting");
            Console.WriteLine("NoAfterYou.Value:" + NoAfterYou.Value);
            Console.WriteLine("AfterYou static constructor ending");
        }
        public static int Value = 42;
    }

    public class NoAfterYou
    {
        static NoAfterYou()
        {
            Console.WriteLine("NoAfterYou static constuctor  starting");
            Console.WriteLine("AfterYou.Value:" + AfterYou.Value);
            Console.WriteLine("NoAfterYou static constructor ending");
        }
        public static int Value = 42;
    }
}
