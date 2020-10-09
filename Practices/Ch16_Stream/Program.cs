using System;
using System.IO;
using System.Text;

namespace Ch16_Stream
{
    class Program
    {
        static void Main(string[] args)
        {
            dcPerson.Example1();
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
            using (var sw = new StreamWriter("Text.txt", false, Encoding.GetEncoding(1252)))
            {
                sw.Write("#100");
            }
        }
        static void Example_FileInfo()
        {
            var info = new FileInfo(@"Text.txt");
            Console.WriteLine("{0} ({1} bytes) last modified on {2}",
                info.FullName, info.Length, info.LastWriteTime);
        }
    }
}
