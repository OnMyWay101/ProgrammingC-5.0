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
            int[] bins = {-1, 0, 1, 2 };

            Console.WriteLine("The result is:{0}", GetIndexOfFirstNonEmptyBin(bins));
        }

        public static int GetIndexOfFirstNonEmptyBin(int[] bins)
        {
            //return Array.FindIndex(bins, IsGreaterThanZero);  //Named delegate function
            //return Array.FindIndex(bins, delegate (int value) { return value > 0; });//Anonymous method
            return Array.FindIndex(bins, value => value > 1);//lambda
        }

        private static bool IsGreaterThanZero(int value)
        {
            return value > 0;
        }
    }
}
