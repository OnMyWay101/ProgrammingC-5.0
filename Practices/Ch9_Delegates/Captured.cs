using System;
using System.Linq.Expressions;

namespace Ch9_Delegates
{
    class Captured
    {
        private static void Calculate(int[] nums)
        {
            int zeroCount = 0;
            int[] nonZeroNums = Array.FindAll(nums,
             v =>
            {
                if(v == 0)
                {
                    zeroCount++;
                    return false;
                }
                else
                {
                    return true;
                }
            });
            Console.WriteLine("Number of zero entries: {0}, first non-zero entry: {1}",
                zeroCount,
                nonZeroNums[0]);
        }
        public static void Example_Calculate()
        {
            int[] nums = {1, 0, 3, -1 ,0 };
            Calculate(nums);
        }
        public static void Example_Caught()
        {
            int offset = 10;
            var greaterThanN = new Predicate<int>[10];
            for(int i = 0; i < greaterThanN.Length; i++)
            {
                int current = i + offset;
                greaterThanN[i] = value => value > current;
            }
            Console.WriteLine(greaterThanN[5](20));
            Console.WriteLine(greaterThanN[5](16));
        }
        private static void Test_LambdaExpression()
        {
            //1.Lambda Expression
            //Expression<Func<int, bool>> greaterThanZero = value => value > 0;
            //compiler for Lambda Expression
            ParameterExpression valuePraram = Expression.Parameter(typeof(int), "int");
            ConstantExpression constantZero = Expression.Constant(0);
            BinaryExpression comparison = Expression.GreaterThan(valuePraram, constantZero);
            Expression<Func<int, bool>> greaterThanZero = Expression.Lambda<Func<int, bool>>(comparison, valuePraram);
        }
    }
}
