using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch5_Collections
{
    class MyList
    {

        public static void Example_UsingList()
        {
            //var numbers = new List<int>();
            //numbers.Add(1);
            //numbers.Add(2);
            //numbers.Add(3);
            var numbers = new List<int> { 1, 11, 111};

            Console.WriteLine("Count:" + numbers.Count);
            Console.WriteLine("numbers:{0}, {1}, {2}", numbers[0], numbers[1], numbers[2]);

            numbers[1] += 1;
            Console.WriteLine("numbers:{0}, {1}, {2}", numbers[0], numbers[1], numbers[2]);

            numbers.RemoveAt(1);
            Console.WriteLine("Count:" + numbers.Count);
            Console.WriteLine("numbers:{0}, {1}", numbers[0], numbers[1]);

            Console.ReadLine();
        }
    }
}
