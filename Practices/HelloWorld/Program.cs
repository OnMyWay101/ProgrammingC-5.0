using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            HelloWorld hw = new HelloWorld("WangChangJie");
            hw.SayHello();

            Console.ReadLine(); //目的只是等待输入，方便看输出打印；
        }
    }

    public class HelloWorld
    {
        public string Name { get; private set; }

        public HelloWorld(string name)
        {
            Name = name;
        }

        public void SayHello()
        {
            Console.WriteLine("{0} says hello world!", Name);
        }
    }
}
