using System;
using System.Collections.Generic;

namespace CompositionTests
{
    /// <summary>
    /// Gini Class
    /// Used for calculating the Gini Coefficient value on data
    /// </summary>
    public class Gini
    {
        public static double Calculate(List<Double> data)
        {
            if (data.Count == 0)
            {
                throw new ArgumentException("Data cannot be empty");
            }

            double sum1 = 0;
            double sum2 = 0;
            double previousValue = data[0];

            for (var i = 0; i < data.Count; i++)
            {
                double value = data[i];

                if (value < 0)
                {
                    throw new Exception("Data set contains negative numbers.");
                }

                if (i > 0 && value < previousValue)
                {
                    throw new Exception("Data set is not ordered ascendingly.");
                }

                sum1 += ((2 * (i + 1)) - data.Count - 1) * value;
                sum2 += value;
                previousValue = value;
            }

            if (sum2 == 0)
            {
                return 0; // If data set contains only zeroes, the equation further below won't work.
            }

            return sum1 / (Math.Pow(data.Count, 2) * (sum2 / data.Count));
        }
    }
}
