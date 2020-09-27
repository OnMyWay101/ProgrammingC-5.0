using System;
using System.Reflection;
using System.Linq;

namespace MyLib
{
    class ContainingType
    {
        class Inside
        {

        }
    }

    class Compatibility
    {
        public string Arg { get; private set; }

        public Compatibility()
        {
            Console.WriteLine("No args Constructor");
        }

        public Compatibility(string arg)
        {
            Arg = arg;
            Console.WriteLine("The arg is :" + arg);
        }

        public bool Example()
        {
            TypeInfo stringType = typeof(string).GetTypeInfo();
            TypeInfo objectType = typeof(Object).GetTypeInfo();

            Console.WriteLine(stringType.IsAssignableFrom(objectType));
            Console.WriteLine(objectType.IsAssignableFrom(stringType));
            return true;
        }

        //使用CreateInstance来创建类型的实例
        private static object CreateAndInvokeMethod(string typeName, string member, params object[] args)
        {
            Type t = Type.GetType(typeName);
            var instance = Activator.CreateInstance(t);
            return t.InvokeMember(
                member,
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.InvokeMethod,
                null,
                instance,
                args);
        }
        //使用MethodInfo来创建类型实例或方法
        private static object CreateAndInvokeMethod2(string typeName, string member, params object[] args)
        {
            Type t = Type.GetType(typeName);
            var instance = Activator.CreateInstance(t);
            MethodInfo m = t.GetTypeInfo().DeclaredMethods.Single(mi => mi.Name == member);
            return m.Invoke(instance, args);
        }

        public static void Example_CreateInvoke()
        {
            object o = CreateAndInvokeMethod2("MyLib.Compatibility", "Example", null);
            Console.WriteLine("return value of InvokeMember():" + o.ToString());
        }

        public static void Example_DynamicConstruction()
        {
            Assembly asm = typeof(Compatibility).GetTypeInfo().Assembly;
            object o = asm.CreateInstance(
                "MyLib.Compatibility",
                false,
                BindingFlags.Public | BindingFlags.Instance,
                null,
                new object[] {"Constructor argument"},
                null,
                null);
            Compatibility c = o as Compatibility;
            if(c == null)
            {
                Console.WriteLine("c == null");
            }
            else
            {
                Console.WriteLine("c != null, Arg = " + c.Arg);
            }
        }
    }
}
