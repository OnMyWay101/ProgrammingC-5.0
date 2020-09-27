using System;
using System.Reflection;

namespace Ch13_Reflection
{
    class ReflectionType
    {
        class Base
        {
            public void Foo()
            {

            }
        }

        class Drived : Base
        {

        }

        public static void GetMemberInfoType()
        {
            MemberInfo bf = typeof(Base).GetMethod("Foo");
            MemberInfo df = typeof(Drived).GetMethod("Foo");
            Console.WriteLine("Base Foo declareType:{0} reflectedType:{1}", bf.DeclaringType, bf.ReflectedType);
            Console.WriteLine("Drived Foo declareType:{0} reflectedType:{1}", df.DeclaringType, df.ReflectedType);
        }

        public static void Example_GetType()
        {
            var bs = new Base();
            Base dr = new Drived();
            Console.WriteLine("Base GetType:" + bs.GetType());
            Console.WriteLine("Drive GetType:" + dr.GetType());
        }
    }
}
