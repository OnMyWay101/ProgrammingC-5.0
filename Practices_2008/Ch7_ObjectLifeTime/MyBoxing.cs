using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ch7_ObjectLifeTime
{
    class MyBoxing
    {
        public static void Show(object o)
        {
            Console.WriteLine(o.ToString());
            Console.WriteLine("The type is:"  + o.GetType());
            //Console.WriteLine((string)o); //Error
            Console.WriteLine((int)o);
        }
        public static void Example_Boxing()
        {
            int num = 42;
            Show(num);
        }

        public struct DisposableValue : IDisposable
        {
            private bool _disposedYet;

            public void Dispose()
            {
                if (!_disposedYet)
                {
                    Console.WriteLine("Disposing the first time!");
                    _disposedYet = true;
                }
                else
                {
                    Console.WriteLine("Have disposed!");                    
                }
            }
        }

        public static void CallDispose(IDisposable d)
        {
            d.Dispose();
        }

        public static void Example_Dispose()
        {
            var d = new DisposableValue();
            Console.WriteLine("Passing value variable:");
            CallDispose(d);
            CallDispose(d);
            CallDispose(d);

            IDisposable i = d;
            Console.WriteLine("Passing interface variable:");
            CallDispose(i);
            CallDispose(i);
            CallDispose(i);

            Console.WriteLine("Call Dispose on value variable:");
            d.Dispose();
            d.Dispose();
            d.Dispose();

        }
    }
}
