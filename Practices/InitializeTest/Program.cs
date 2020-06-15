using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitializeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // TestInitializeTest1();
            Console.WriteLine("Main:AfterYou.Value=" + AfterYou.Value);
            Console.ReadLine();
        }

        static void TestInitializeTest1()
        {
            Console.WriteLine("TestInitializeTest1");
            InitializeTest.foo();
            Console.WriteLine("construct1:");
            InitializeTest temp = new InitializeTest();

            Console.WriteLine("construct2:");
            temp = new InitializeTest();
            Console.ReadLine();
        }

    }


    public class InitializeTest
    {
        public InitializeTest()
        {
            Console.WriteLine("Constructor");
        }

        static InitializeTest()
        {
            Console.WriteLine("Static Constructor!");
        }

        public int _noStatic1 = GetValue("noStatic1");
        public int _noStatic2 = GetValue("noStatic2");
        public static int _static1 = GetValue("static1");
        public static int _static2 = GetValue("static2");

        public static int GetValue(string info)
        {
            Console.WriteLine(info);
            return 1;
        }

        public static void foo()
        {
            Console.WriteLine("static method!");
        }
    }
}
