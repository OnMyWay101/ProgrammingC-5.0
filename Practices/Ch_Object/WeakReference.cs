using System;
using System.Collections.Generic;

namespace Ch7_Object
{
    public class WeakCaehe<TKey, TValue>
        where TValue : class
    {
        private Dictionary<TKey, WeakReference<TValue>> _cache =
            new Dictionary<TKey, WeakReference<TValue>>();

        public void Add(TKey key, TValue value)
        {
            _cache.Add(key, new WeakReference<TValue>(value));
        }

        public bool TryGetValue(TKey key, out TValue cachedItem)
        {
            WeakReference<TValue> entry;
            if(_cache.TryGetValue(key, out entry))
            {
                bool isAlive = entry.TryGetTarget(out cachedItem);
                if(!isAlive)
                {
                    _cache.Remove(key);
                }
                return isAlive;
            }
            else
            {
                cachedItem = null;
                return false;
            }
        }

        public static void Exmaple_WeakReference()
        {
            var cache = new WeakCaehe<string, byte[]>();

            var data = new byte[100];
            cache.Add("d", data);

            byte[] fromCache;
            Console.WriteLine("Retrieval:" + cache.TryGetValue("d", out fromCache));
            Console.WriteLine("Same ref?" + object.ReferenceEquals(data, fromCache));
            fromCache = null;

            GC.Collect();
            Console.WriteLine("Retrieval:" + cache.TryGetValue("d", out fromCache));
            Console.WriteLine("Same ref?" + object.ReferenceEquals(data, fromCache));
            fromCache = null;

            data = null;
            GC.Collect();
            Console.WriteLine("Retrieval:" + cache.TryGetValue("d", out fromCache));
            Console.WriteLine("NULL? " + (fromCache == null));
        }
    }
}
