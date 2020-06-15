/*该工程说明：
 *概要：WangCJ(20200607)
 *信息：Chapter3的Members章节的代码示例内容
 */
using System;
using System.Drawing;

namespace Ch3_Method
{
    class Program
    {
        static void Main(string[] args)
        {
            AnonymousExample();
            Console.ReadLine();
        }

        #region Worker测试用例
        static void WorkerExample()
        {
            Worker w1 = new Worker(20, "Mover", "Tom");
            Console.WriteLine(w1.ToString());
            Console.WriteLine("After Change:");
            ChangeWorker(w1);
            Console.WriteLine(w1.ToString());
        }

        static void ChangeWorker(Worker w)
        {
            w.Age = 30;
            w.Job = "Programmer";
            w.Name = "WangCJ";
        }
        #endregion
        #region 输出参数测试用例
        static void OutExample()
        {
            int x = 10, y = 3, z = 0, ret = 0;
            ret = OutTest(x, y, ref z);
            Console.WriteLine("ret:{0}; z:{1}", ret, z);
        }

        static int OutTest(int x, int y, ref int mode)
        {
            mode = x % y;
            return x / y;
        }
        #endregion
        #region 重载测试用例
        static void OverloadExampleTest()
        {
            OverloadExample.Blame("pliece", "using the power");
            OverloadExample.Blame("pliece");
            OverloadExample.Blame();
        }

        #endregion
        #region Extension测试用例
        static void ExtensionTest()
        {
            "hello".MyShow();
            int a = 100;
            a.MyExtension();
        }
        #endregion
        #region Properties测试用例
        static void PropertiesExample()
        {
            var item = new Item();
            Console.WriteLine(item.Location.Y);
            //item.Location.X = 123;
        }
        #endregion
        #region 匿名类型
        static void AnonymousExample()
        {
            var x = new { Title = "Lord", Surname = "Voldemort" };
            Console.WriteLine("Welcome, " + x.Title + " " + x.Surname);
            Console.WriteLine("type:"+ x.GetType().ToString()+ " ;ToString:" + x.ToString());
        }
        #endregion
    }

    /*说明：该类用来测试"Method"小节的引用参数*/
    public class Worker
    {
        public Worker(int age, string job, string name)
        {
            this.Age = age;
            this.Job = job;
            this.Name = name;
        }
        public int Age
        {
            get;
            set;
        }
        public string Job
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public override string ToString()
        {
            return Name + " age is " + Age + " , job is " + Job;
        }
    }

    /*说明：该类用来测试"Method"小节的重载函数*/
    public class OverloadExample
    {
        public static void Blame(string perpetrator, string problem)
        {
            Console.WriteLine("I blame {0} for {1}.", perpetrator, problem);
        }

        public static void Blame(string perpetrator)
        {
            Blame(perpetrator, "the downfall of society");
        }

        public static void Blame()
        {
            Blame("the youth of today", "the downfall of society");
        }


    }

    /*说明：该类用来测试"Method"小节的Extension函数*/
    public static class StringExtensions
    {
        public static void MyShow(this string s)
        {
            System.Console.WriteLine("My String Extension:" + s);
        }
    }
    public static class IntExtensions
    {
        public static void MyExtension(this int input)
        {
            System.Console.WriteLine("My Int Extension:" + input.ToString());
        }
    }

    /*说明：该类用来测试"Properties"小节的函数*/
    public class Item
    {
        public Point Location { get; set; }
    }


}
