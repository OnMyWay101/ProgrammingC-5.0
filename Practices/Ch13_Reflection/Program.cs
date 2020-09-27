using System;
using System.Reflection;

namespace Ch13_Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            //ShowAssemblyName();
            //ShowNestType();
            //GetTypeInfo();
            //GetAssemblyName();
            //ShowNestType();
            //ReflectionType.Example_GetType();
            //MyLib.Compatibility.Example();
            //MyLib.Compatibility.Example_CreateInvoke();
            //MyLib.Compatibility.Example_DynamicConstruction();
            MyReflectionContext.Example();
            Console.ReadLine();
        }

        static void ShowAssemblyName()
        {
            Assembly me = typeof(Program).GetTypeInfo().Assembly;
            Console.WriteLine(me.FullName);
        }

        static void ShowNestType()
        {
            Assembly me = typeof(Program).GetTypeInfo().Assembly;
            Type nt = me.GetType("MyLib.ContainingType+Inside");
            if(nt == null)
            {
                Console.WriteLine("nt is null!");
                return;
            }
            Console.WriteLine(nt);
        }

        static void GetTypeInfo()
        {
            //int i = 42;
            //Type type = i.GetType();
            Type intType = typeof(int);
            Type stringType = typeof(string);
            Type iDspType = typeof(IDisposable);
            Console.WriteLine("int:" + intType);
            Console.WriteLine("string:" + stringType);
            Console.WriteLine("IDisposable:" + iDspType);
        }

        static void GetAssemblyName()
        {
            Assembly info = typeof(int).Assembly;
            Console.WriteLine(info.FullName);
        }
    }
}
