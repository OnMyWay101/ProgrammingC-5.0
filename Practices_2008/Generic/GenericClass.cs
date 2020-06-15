using System;
using System.Collections.Generic;

namespace Ch4_ZeroLike
{
    class GenericClass<T>
    {
        public GenericClass(T item, string name)
        {
            Item = item;
            Name = name;
        }
        public T Item { get; set; }
        public string Name { get; set; }

        public static void GenericClassTest()
        {
            GenericClass<int> intGC1 = new GenericClass<int>(1, "int1");
            GenericClass<int> intGC2 = new GenericClass<int>(2, "int2");
            var stringGC = new GenericClass<string>("good boy", "WangCJ");

            var listGC = new List<GenericClass<int>> { intGC1, intGC2 };
            var gcGC = new GenericClass<GenericClass<string>>(stringGC, "NestedGenericClass");
        }
    }
}
