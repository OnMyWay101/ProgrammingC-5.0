using System;
using System.IO;

namespace Ch16_Stream
{
    class Program
    {
        static void Main(string[] args)
        {
            Example_StreamWriter();
            Console.ReadLine();
        }

        static void Example_StreamWriter()
        {
            using (var fw = new StreamWriter(@"G:\test20200922\test1.txt", true))
            {
                Console.WriteLine(@"you have open G:\test20200922\test1.txt");
                fw.WriteLine("writeline method call!");
                fw.Write("write method call! \r\n");
                fw.WriteLine("a new line!");
                Console.WriteLine("just write;");
                string input = Console.ReadLine();
                fw.WriteLine(input);
            }
        }

        static void Example_CodePage()
        {
            using ()
            {

            }
        }
    }
}
