using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ch7_ObjectLifeTime
{
    class Program
    {
        static void Main(string[] args)
        {
            //MyIDisposable.Example_InsteadForeach();
            MyBoxing.Example_Dispose();
            Console.ReadLine();
        }
    }
}
