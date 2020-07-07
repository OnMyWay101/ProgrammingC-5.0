using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch9_Delegates
{
    class CustomEvent
    {
        private static readonly Dictionary<Tuple<CustomEvent, object>, EventHandler>
            _eventHandlers = new Dictionary<Tuple<CustomEvent, object>, EventHandler>();
        private static readonly object EventOneId = new object();
        private static readonly object EventTwoId = new object();

        public event EventHandler EventOne
        {
            add
            {
                AddEvent(EventOneId, value);
            }
            remove
            {
                RemoveEvent(EventOneId, value);
            }
        }
        public event EventHandler EventTwo
        {
            add
            {
                AddEvent(EventTwoId, value);
            }
            remove
            {
                RemoveEvent(EventTwoId, value);
            }
        }
        public void RaiseBoth()
        {
            RaiseEvent(EventOneId, EventArgs.Empty);
            RaiseEvent(EventTwoId, EventArgs.Empty);
        }

        private Tuple<CustomEvent, object> MakeKey(object eventId)
        {
            return Tuple.Create(this, eventId);
        }
        private void AddEvent(object eventId, EventHandler handler)
        {
            var key = MakeKey(eventId);
            EventHandler entry;
            _eventHandlers.TryGetValue(key, out entry);
            entry += handler;
            _eventHandlers[key] = entry;
        }
        private void RemoveEvent(object eventId, EventHandler handler)
        {
            var key = MakeKey(eventId);
            EventHandler entry = _eventHandlers[key];
            entry -= handler;
            if(entry == null)
            {
                _eventHandlers.Remove(key);
            }
            else
            {
                _eventHandlers[key] = entry;
            }
        }
        private void RaiseEvent(object eventId, EventArgs e)
        {
            var key = MakeKey(eventId);
            EventHandler handler;
            if(_eventHandlers.TryGetValue(key, out handler))
            {
                handler(this, e);
            }
        }

        public static void Example_Use()
        {
            CustomEvent cstEvent1 = new CustomEvent();
            CustomEvent cstEvent2 = new CustomEvent();

            cstEvent1.EventOne += (sender, e) =>
                {
                    Console.WriteLine("hello1");
                    Console.WriteLine("sender:" + sender.ToString());
                    Console.WriteLine("e:" + e.ToString());
                };

            cstEvent2.EventTwo += (sender, e) =>
            {
                Console.WriteLine("hello2");
                Console.WriteLine("sender:" + sender.ToString());
                Console.WriteLine("e:" + e.ToString());
            };
            Console.WriteLine("first call:");
            cstEvent1.RaiseBoth();
            cstEvent2.EventTwo -= (sender, e) =>
            {
                Console.WriteLine("hello2");
                Console.WriteLine("sender:" + sender.ToString());
                Console.WriteLine("e:" + e.ToString());
            };
            Console.WriteLine("second call:");
            cstEvent1.RaiseBoth();
        }
    }
}
