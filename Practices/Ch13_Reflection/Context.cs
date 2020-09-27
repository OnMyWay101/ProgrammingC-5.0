using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Reflection.Context;

namespace Ch13_Reflection
{
    class Context
    {
    }
    class NotVeryIntresting
    {

    }

    class MyReflectionContext : CustomReflectionContext
    {
        protected override IEnumerable<PropertyInfo> AddProperties(Type type)
        {
            if(type == typeof(NotVeryIntresting))
            {
                var fakeProp = CreateProperty(
                    MapType(typeof(string).GetTypeInfo()).AsType(),
                    "FakeProperty",
                    o => "FakeValue",
                    (o, v) => Console.WriteLine("Setting value : " + v)
                    );
                return new[] { fakeProp};
            }
            else
            {
                return base.AddProperties(type);
            }
        }
        
        public static void Example()
        {
            var ctx = new MyReflectionContext();
            TypeInfo mappedType = ctx.MapType(typeof(NotVeryIntresting).GetTypeInfo());
            foreach(PropertyInfo prop in mappedType.DeclaredProperties)
            {
                Console.WriteLine("{0}:{1}", prop.Name, prop.PropertyType.Name);
            }
            
        }
    }
}
