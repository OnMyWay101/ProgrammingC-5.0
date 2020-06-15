using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch3_Method
{
    public class indexers
    {
        public string this[int index]
        {
            get
            {
                return index < 5 ? "foo" : "bar";
            }
        }
        /*（@todo）多维索引器代码*/
        //public int towDimention[int x, int y]
        //{
        //    get
        //    {
        //        if(x > 2 && y > 2)
        //        {
        //            return 4;
        //        }
        //        else
        //        {
        //            return 0;
        //        }
        //    }
        //}


        public static void Example1()
        {
            var numbers = new List<int> { 1, 2, 3, 4 };
            numbers[2] += numbers[1];
            Console.WriteLine(numbers[0]);
        }

        public static void Example2()
        {
            indexers ind = new indexers();
            Console.WriteLine("ind[2]:" + ind[2]);
            Console.WriteLine("ind[6]:" + ind[6]);

        }

    }
}
