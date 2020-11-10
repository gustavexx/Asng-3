/**
 * Lsit of rules applied for best practicing coding
 * 
 * - Do organize namespaces with a clearly defined structure.
 * - Do use Pascal Casing for class names and method names.
 * - Do use camel Casing for local variables and method arguments.
 */
using System;
using System.Collections.Generic;

namespace Comp10066.Lab3
{
    /**
     * Library of statistical functions using Generics for different statistical
     * calculations.
     * 
     * see http://www.calculator.net/standard-deviation-calculator.html
     * for sample standard deviation calculations
     *
     * @author Joey Programmer
     * @modified by Gustavo Marcano, November 10, 2020
     */

    public class A3
    {
        /// <summary>
        /// Method Average is in charge of calculating the average of a list of numbers that are double
        /// </summary>
        /// <param name="list">Represents the list of double</param>
        /// <param name="includeNegativeValues">Flag parameter that along with the list parameter
        /// will condition if a negative element will be added to the calculation or not</param>
        /// <returns>Method Average returns the average of set of numbers in the list</returns>
        public static double Average(List<double> list, bool includeNegativeValues)
        {
            double sum = Sum(list, includeNegativeValues);
            int counter = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (includeNegativeValues || list[i] >= 0)
                {
                    counter++;
                }
            }
            if (counter == 0)
            {
                throw new ArgumentException("no values are > 0");
            }
            return sum / counter;
        }

        /// <summary>
        /// Method Sum is in charge of calculating the sum of a list's elements that are double
        /// </summary>
        /// <param name="list">Represents the list of double</param>
        /// <param name="includeNegativeValues">Flag parameter that along with the list parameter
        /// will condition if a negative element will be added to the calculation or not</param>
        /// <returns>Method Sum returns the sum of the numbers in the list</returns>
        public static double Sum(List<double> list, bool includeNegativeValues)
        {
            if (list.Count < 0)
            {
                throw new ArgumentException("list cannot be empty");
            }

            double sum = 0.0;
            foreach (double val in list)
            {
                if (includeNegativeValues || val >= 0)
                {
                    sum += val;
                }
            }
            return sum;
        }

        /// <summary>
        /// Method Median is in charge of calculating median of a list's elements that are double
        /// </summary>
        /// <param name="data">Represents the list of double</param>
        /// <returns>Method Median returns the median of the set of numbers in the list</returns>
        public static double Median(List<double> data)
        {
            if (data.Count == 0)
            {
                throw new ArgumentException("Size of array must be greater than 0");
            }

            data.Sort();

            double median = data[data.Count / 2];
            if (data.Count % 2 == 0)
                median = (data[data.Count / 2] + data[data.Count / 2 - 1]) / 2;

            return median;
        }

        /// <summary>
        /// Method StandardDeviation is in charge of calculating the standard deviation of a 
        /// list's elements that are double
        /// </summary>
        /// <param name="data">Represents the list of double</param>
        /// <returns>Method StandardDeviation returns the median of the set of numbers in the list</returns>
        public static double StandardDeviation(List<double> data)
        {
            if (data.Count <= 1)
            {
                throw new ArgumentException("Size of array must be greater than 1");
            }

            int n = data.Count;
            double sumOfSquares = 0;
            double average = Average(data, true);

            for (int i = 0; i < n; i++)
            {
                double value = data[i];
                sumOfSquares += Math.Pow(value - average, 2);
            }
            double standardDeviation = Math.Sqrt(sumOfSquares / (n - 1));
            return standardDeviation;
        }

        // Simple set of tests that confirm that functions operate correctly
        static void Main(string[] args)
        {
            List<Double> testDataD = new List<Double> { 3.2, -4.3, 62.2, 57.5, -60.2, 11.1 };

            Console.WriteLine("The sum of the array = {0}", Sum(testDataD, false));

            Console.WriteLine("The average of the array = {0}", Average(testDataD, false));

            Console.WriteLine("The median value of the Double data set = {0}", Median(testDataD));

            Console.WriteLine("The sample standard deviation of the Double test set = {0}\n", StandardDeviation(testDataD));
        }
    }
}
