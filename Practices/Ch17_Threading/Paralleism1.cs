using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch17_Threading
{
    class Paralleism1
    {
        /// <summary>
        /// Unit:The Parallel class
        /// Example 17-24. Parallel convolution(P649)
        /// </summary>
        static float[] ParallelConvolution(float[] input, float[] kernel)
        {
            float[] output = new float[input.Length];
            Parallel.For(0, input.Length, i =>
            {
                float total = 0;
                for (int k = 0; k < Math.Min(kernel.Length, i + 1); ++k)
                {
                    total += input[i - k] * kernel[k];
                }
                output[i] = total;
            });
            return output;
        }
    }
}
