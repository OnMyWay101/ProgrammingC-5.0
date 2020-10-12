using System;
using System.Threading;
using System.Net;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ch17_Threading
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //ThreadTest();
            //TaskThreadPool();
            //DoWork();
            //Console.ReadLine();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        private static void ThreadTest()
        {
            var t1 = new Thread(MyThreadEntryPoint);
            var t2 = new Thread(MyThreadEntryPoint);
            var t3 = new Thread(MyThreadEntryPoint);
            t1.Start("https://mbd.baidu.com/newspage/data/landingsuper?context=%7B%22nid%22%3A%22news_8776747479799786245%22%7D&n_type=0&p_from=1");
            //t1.Start("http://www.interact-sw.co.uk/iangblog/");
            //t2.Start("http://oreilly.com/");
            //t3.Start("http://msdn.microsoft.com/en-us/vstudio/hh388566");
        }

        private static void MyThreadEntryPoint(object arg)
        {
            string url = (string)arg;
            string fileName = @"baidu.html";
            using (var w = new WebClient())
            {
                Console.WriteLine("Downloading " + url);
                string page = w.DownloadString(url);
                Console.WriteLine("Downloaded {0}, length {1}, fileName:{2}", url, page.Length, fileName);
                using (var sw = new StreamWriter(fileName, false, Encoding.GetEncoding("gb2312")))
                {
                    sw.Write(page);
                }
            }
        }

        //通过task来触发thread加入到threadPool里面运行
        private static void TaskThreadPool()
        {
            Task.Factory.StartNew(MyThreadEntryPoint, "https://www.baidu.com/");
        }

        private static void DoWork()
        {
            //Task.Factory.StartNew(() => Download("https://www.baidu.com/"));
            Task.Run(() => Download("https://www.baidu.com/"));
        }

        private static void Download(string url)
        {
            using (var w = new WebClient())
            {
                Console.WriteLine("Downloading " + url);
                string page = w.DownloadString(url);
                Console.WriteLine("Downloaded {0}, length {1}", url, page.Length);
            }
        }
    }
}
