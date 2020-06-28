using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch8_Exceptions
{
    class Unhandle
    {
        public static void Example_Unhandle()
        {
            AppDomain.CurrentDomain.UnhandledException += OnUnhandleException;
            throw new InvalidCastException();
        }

        private static void OnUnhandleException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("An exception went unhandled: {0}", e.ExceptionObject);
        }
    }
}
