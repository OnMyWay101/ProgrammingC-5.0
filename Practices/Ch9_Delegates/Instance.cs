using System;

namespace Ch9_Delegates
{
    public class Instance
    {
        public class ThresholdCompare
        {
            public int Threshold { get; set; }

            public bool IsGreaterThan(int value)
            {
                return value > Threshold;
            }

            public Predicate<int> GetIsGreaterThanPredicate()
            {
                return IsGreaterThan;
            }

            public static void  Example_Instance()
            {
                var zeroThreshold = new ThresholdCompare { Threshold = 0};
                var tenThreshold = new ThresholdCompare { Threshold = 10};
                var hundredThreshold = new ThresholdCompare { Threshold = 100 };

                Predicate<int> greaterThanZero = zeroThreshold.IsGreaterThan;
                Predicate<int> greaterThanTen = tenThreshold.IsGreaterThan;
                Predicate<int> greaterThanHundred = hundredThreshold.IsGreaterThan;

                Console.WriteLine("-1 is greater than zero?    " + greaterThanZero(-1));
                Console.WriteLine("11 is greater than ten?    " + greaterThanTen(11));
                Console.WriteLine("1000 is greater than hundred?    " + greaterThanHundred(1000));
            }

            public static Predicate<int> CombiningDelegate()
            {
                var zeroThreshold = new ThresholdCompare { Threshold = 0 };
                var tenThreshold = new ThresholdCompare { Threshold = 10 };
                var hundredThreshold = new ThresholdCompare { Threshold = 100 };

                Predicate<int> megaPredicate = zeroThreshold.IsGreaterThan;
                megaPredicate += tenThreshold.IsGreaterThan;
                megaPredicate += hundredThreshold.IsGreaterThan;

                return megaPredicate;
            }

            public static void Example_Combining()
            {
                int trueCount = 0;
                int falseCount = 0;

                foreach(Predicate<int> p in CombiningDelegate().GetInvocationList())
                {
                    bool result = p(42);
                    Console.WriteLine("The result is:" + result);
                    Console.WriteLine("p.target:" + p.Target.ToString());
                    Console.WriteLine("p.target type:" + p.Target.GetType().ToString());
                    Console.WriteLine("p.Method:" + p.Method.ToString());
                    Console.WriteLine("p.Method type:" + p.Method.GetType().ToString());

                    if (result)
                    {
                        trueCount += 1;
                    }
                    else
                    {
                        falseCount += 1;
                    }
                }
                if(trueCount > falseCount)
                {
                    Console.WriteLine("The majority return true");
                }
                else if (falseCount > trueCount)
                {
                    Console.WriteLine("The majority return false");
                }
                else
                {
                    Console.WriteLine("It is a tie");
                }
            }

        }
    }
}
