using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace Ch16_Stream
{
    [DataContract]
    public class dcPerson
    {
        private readonly List<dcPerson> _friends = new List<dcPerson>();

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public IList<dcPerson> Friends { get { return _friends; } }

        public override string ToString()
        {
            return string.Format("{0}(friends:{1})",
                Name, string.Join(", ", Friends.Select(f => f.Name)));
        }
        public static void Example1()
        {
            var bart = new dcPerson { Name = "Bart" };
            var millhouse = new dcPerson { Name = "Millhouse" };
            var ralph = new dcPerson { Name = "Ralph" };
            var wigglePuppy = new dcPerson { Name = "WigglePuppy" };

            bart.Friends.Add(millhouse);
            bart.Friends.Add(ralph);
            ralph.Friends.Add(wigglePuppy);

            MemoryStream ms = new MemoryStream();
            var serializer = new DataContractJsonSerializer(typeof(dcPerson));
            serializer.WriteObject(ms, bart);

            ms.Seek(0, SeekOrigin.Begin);
            string content = new StreamReader(ms).ReadToEnd();

            Console.WriteLine(content);
        }
    }

}
