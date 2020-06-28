using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch9_Delegates
{
    class FisrtDelegate
    {
        public static void Example_Searching()
        {
            int[] bins = {-1, 0, 0, 1 };

            Console.WriteLine("The result is:{0}", GetIndexOfFirstNonEmptyBin(bins));
        }

        public static int GetIndexOfFirstNonEmptyBin(int[] bins)
        {
            return Array.FindIndex(bins, IsGreaterThanZero);
        }

        private static bool IsGreaterThanZero(int value)
        {
            return value > 0;
        }
    }
}
