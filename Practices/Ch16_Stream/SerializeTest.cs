using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Ch16_Stream
{
    [Serializable]
    class Person
    {
        private readonly List<Person> _friends = new List<Person>();
        public string Name { get; set; }

        public IList<Person> Friends { get { return _friends; } }
        public override string ToString()
        {
            return string.Format("{0}(friends:{1})",
                Name, string.Join(", ", Friends.Select(f => f.Name)));
        }

        public static void main()
        {
            var bart = new Person { Name = "Bart" };
            var millhouse = new Person { Name = "Millhouse" };
            var ralph = new Person { Name = "Ralph" };
            var wigglePuppy = new Person { Name = "WigglePuppy" };

            bart.Friends.Add(millhouse);
            bart.Friends.Add(ralph);
            millhouse.Friends.Add(bart);
            ralph.Friends.Add(bart);
            ralph.Friends.Add(wigglePuppy);

            Console.WriteLine("Original:{0}", bart);
            Console.WriteLine("Original:{0}", millhouse);
            Console.WriteLine("Original:{0}", ralph);

            var stream = new MemoryStream();
            var serializer = new BinaryFormatter();
            serializer.Serialize(stream, bart);

            Person bartCopy;
            stream.Seek(0, SeekOrigin.Begin);
            bartCopy = (Person)serializer.Deserialize(stream);

            Console.WriteLine("Is Bart copy the same object?{0}", object.ReferenceEquals(bart, bartCopy));
            Console.WriteLine("Copy:{0}", bartCopy);

            var ralphCopy = bartCopy.Friends.Single(f => f.Name == "Ralph");
            Console.WriteLine("Is Ralph copy the same object?{0}", object.ReferenceEquals(ralph, ralphCopy));
            Console.WriteLine("Copy:{0}", ralphCopy);
        }
    }
}
