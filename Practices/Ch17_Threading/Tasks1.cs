using System.Net;
using System.Threading.Tasks;
using System;
using System.Net.Mail;

namespace Ch17_Threading
{
    class Tasks1
    {
        /// <summary>
        /// Uint:The Task And Task<T> Class
        /// Task-based web download(Example17_17;P636)
        /// </summary>
        public class Example17_17
        {
            public static void WebGetTask()
            {
                var w = new WebClient();
                //string url = "http://www.interact-sw.co.uk/iangblog/";
                string url = "http://www.baidu.com";
                Console.WriteLine("start async task");
                Task<string> webGetTask = w.DownloadStringTaskAsync(url);
                Console.WriteLine("after async task");
                //Example17-18
                webGetTask.ContinueWith(t =>
                {
                    string webContent = t.Result;
                    Console.WriteLine("Web page length: " + webContent.Length);
                });
                Console.WriteLine("after ContinueWith");
            }
        }
    }

    /// <summary>
    /// Unit:Custom Threadless Tasks
    /// Example 17-22(P644):Using TaskCompletionSource<T>
    /// </summary>
    public static class SmtpAsyncExtensions
    {
        public static Task SendTaskAsync(this SmtpClient mailClient, string from,
        string recipients, string subject, string body)
        {
            var tcs = new TaskCompletionSource<object>();
            SendCompletedEventHandler completionHandler = null;
            completionHandler = (s, e) =>
            {
                mailClient.SendCompleted -= completionHandler;
                if (e.Cancelled)
                {
                    tcs.SetCanceled();
                }
                else if (e.Error != null)
                {
                    tcs.SetException(e.Error);
                }
                else
                {
                    tcs.SetResult(null);
                }
            };
            mailClient.SendCompleted += completionHandler;
            mailClient.SendAsync(from, recipients, subject, body, null);
            return tcs.Task;
        }
    }
}
 