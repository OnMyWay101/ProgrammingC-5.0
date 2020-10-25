using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;

namespace Ch17_Threading//chapter name
{
    class Synchronization1//section name
    {
        //Unit:Monitors and the lock keyword
        public class MonitorsAndTheLockKeyWord
        {
            /// <summary>
            /// lock keyword(Example 17-10;Page:615)
            /// </summary>
            public class SaleLog
            {
                private readonly object _sync = new object();
                private decimal _total;
                private readonly List<string> _saleDetails = new List<string>();

                public decimal Total
                {
                    get
                    {
                        lock (_sync)
                        {
                            return _total;
                        }
                    }
                }
                public void AddSale(string item, decimal price)
                {
                    string details = string.Format("{0} sold at {1}", item, price);
                    lock (_sync)
                    {
                        _total += price;
                        _saleDetails.Add(details);
                    }
                }

                public string[] GetDetails(out decimal total)
                {
                    lock (_sync)
                    {
                        total = _total;
                        return _saleDetails.ToArray();
                    }
                }

                //Example 17-11(Page:619)
                public string[] GetDetails_Expand(out decimal total)
                {
                    bool lockWasTaken = false;
                    var temp = _sync;
                    try
                    {
                        Monitor.Enter(temp, ref lockWasTaken);
                        {
                            total = _total;
                            return _saleDetails.ToArray();
                        }
                    }
                    finally
                    {
                        if (lockWasTaken)
                        {
                            Monitor.Exit(temp);
                        }
                    }
                }
            }

            /// <summary>
            /// Monitor wait and pulse(Example 17-12;Page:620)
            /// </summary>
            /// <typeparam name="T"></typeparam>
            public class MessageQueue<T>
            {
                private readonly object _sync = new object();
                private readonly Queue<T> _queue = new Queue<T>();

                public void Post(T message)
                {
                    lock (_sync)
                    {
                        bool wasEmpty = _queue.Count == 0;
                        _queue.Enqueue(message);
                        if (wasEmpty)
                        {
                            Monitor.Pulse(_sync);//pulse
                        }
                    }
                }
                public T Get()
                {
                    lock (_sync)
                    {
                        while (_queue.Count == 0)
                        {
                            Monitor.Wait(_sync);//wait
                        }
                        return _queue.Dequeue();
                    }
                }

                //todo:写一个使用post和get的例子，确定：
                //1)：是否get调用了lock过后，使用post的lock能获得？     能，因为里面有Monitor.Wait应该有释放的效果，然后等待通知；
                //2):是应为Monitor.Wait能释放lock吗？   是的，注释了Monitor.Wait则Post的lock就不能获取；
                public static void UseMQ(T postNum)
                {
                    var mq = new MessageQueue<T>();
                    Task.Run(() =>
                    {
                        Console.WriteLine("Getting...");
                        Console.WriteLine("get value:" + mq.Get());
                    });
                    Thread.Sleep(2000);
                    Task.Run(() =>
                    {
                        Console.WriteLine("Posting...");
                        mq.Post(postNum);
                        Console.WriteLine("Post value:" + postNum);
                    });
                }
            }
        }


        /// <summary>
        /// Uint:SpinLock
        /// SpinLock(Example 17-13;Page:622)
        /// </summary>
        public class DecimalTotal
        {
            private decimal _total;
            private SpinLock _lock;
            public decimal Total
            {
                get
                {
                    bool acquiredLock = false;
                    try
                    {
                        _lock.Enter(ref acquiredLock);
                        return _total;
                    }
                    finally
                    {
                        if (acquiredLock)
                        {
                            _lock.Exit();
                        }
                    }
                }
            }
            public void Add(decimal value)
            {
                bool acquiredLock = false;
                try
                {
                    _lock.Enter(ref acquiredLock);
                    _total += value;
                }
                finally
                {
                    if (acquiredLock)
                    {
                        _lock.Exit();
                    }
                }
            }
        }

        /// <summary>
        /// Uint:Event Objects
        /// Evnet(Example 17-14;Page:625)
        /// </summary>
        public class Example17_14
        {
            static void LogFailure(string message, string mailServer)
            {
                var email = new SmtpClient(mailServer);
                using (var emailSent = new ManualResetEvent(false))
                {
                    bool tooLate = false; // Prevent call to Set after a timeout
                    email.SendCompleted += (s, e) => { if (!tooLate) { emailSent.Set(); } };
                    email.SendAsync("logger@example.com", "sysadmin@example.com",
                        "Failure Report", "An error occurred: " + message, null);
                    //LogPersistently(message);
                    if (!emailSent.WaitOne(TimeSpan.FromMinutes(1)))
                    {
                        //LogPersistently("Timeout sending email for error: " + message);
                    }
                    tooLate = true;
                }
            }
        }

        /// <summary>
        /// Uint:InterLocked
        /// CompareExchange(Example 17-15;Page:630)
        /// </summary>
        public class Example17_15
        {
            static int InterLockedIncrement(ref int target)
            {
                int current, newValue;
                do
                {
                    current = target;
                    newValue = current + 1;
                } while (Interlocked.CompareExchange(ref target, newValue, current) != current);
                return newValue;
            }
        }

        /// <summary>
        /// Uint:Lazy Initializztion
        /// Using LazyInitializer(Example17_16;Page:633)
        /// </summary>
        public class Cache<T>
        {
            private static Dictionary<string, T> _d;
            public static IDictionary<string, T> Dictionary
            {
                get
                {
                    return LazyInitializer.EnsureInitialized(ref _d);
                }
            }
        }
    }
}
