using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch5_Collections
{
    public class MyDictionary
    {

        public static void Exampel_SimpleUse()
        {
            var textToNumber = new Dictionary<string, int>
            {
                {"One", 1 },
                {"Two", 2 },
                {"Three", 3 }
            };
            Console.WriteLine(textToNumber["One"]);
            Console.WriteLine(textToNumber["Two"]);
            Console.WriteLine(textToNumber["Three"]);

            var textToNumber2 = new Dictionary<string, int>(StringComparer.InvariantCultureIgnoreCase)
            {
                {"One", 1 },
                {"Two", 2 },
                {"Three", 3 }
            };
            Console.WriteLine(textToNumber2["one"]);
            Console.WriteLine(textToNumber2["tWo"]);
            Console.WriteLine(textToNumber2["three"]);

            foreach(var entry in textToNumber2)
            {
                Console.WriteLine(entry.Key.ToString() + " " + entry.Value.ToString());
            }
            Console.ReadLine();

        }
    }
}
