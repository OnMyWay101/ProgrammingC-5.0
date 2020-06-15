using System;

namespace Counter
{
    public class Counter
    {
        private readonly int _count;
        private static int _totalCount;

        public Counter()
        {
            _count = 0;
        }

        private Counter(int count)
        {
            _count = count;
        }

        public Counter GetNextValue()
        {
            _totalCount += 1;
            return new Counter(_count + 1);
        }

        public static Counter operator ++(Counter input)
        {
            return input.GetNextValue();
        }

        public int Count
        {
            get
            {
                return _count;
            }
        }

        public static int TotalCount
        {
            get
            {
                return _totalCount;
            }
        }

    }
}
