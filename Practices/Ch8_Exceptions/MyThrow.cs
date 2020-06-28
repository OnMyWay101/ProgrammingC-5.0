using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch8_Exceptions
{
    class MyThrow
    {
        public static int MayThrow(string text)
        {
            if(text == null)
            {
                throw new ArgumentNullException("Text");
            }
            return text.Count(ch => ch == ',');
        }

        public static void Exmaple_Throw()
        {
            try
            {
                Console.WriteLine("The resualt:{0}", MayThrow(",123,123"));
            }
            catch(ArgumentNullException x)
            {
                Console.WriteLine("Catch Exception:{0}", x.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
